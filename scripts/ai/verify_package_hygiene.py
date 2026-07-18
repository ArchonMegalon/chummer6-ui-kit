#!/usr/bin/env python3
from __future__ import annotations

import argparse
import hashlib
import json
import re
import sys
import xml.etree.ElementTree as ET
import zipfile
from pathlib import Path
from typing import Any


MANIFEST_CONTRACT = "chummer6-ui-kit.downstream-compatibility/v1"
PACKAGE_ID = "Chummer.Ui.Kit"
PACKAGE_VERSION = "0.1.0-preview"
LICENSE_EXPRESSION = "GPL-3.0-only"
TARGET_FRAMEWORK = "net10.0"
EXPECTED_CONSUMERS = {"chummer6-mobile", "chummer6-ui"}
CONSUMER_AUTHORITIES = {
    "chummer6-ui": {
        "repository": "https://github.com/ArchonMegalon/chummer6-ui.git",
        "version_declaration": "Directory.Build.props",
        "consumer_project": "Chummer.Presentation/Chummer.Presentation.csproj",
        "compatibility_mode": "exact_source_snapshot",
    },
    "chummer6-mobile": {
        "repository": "https://github.com/ArchonMegalon/chummer6-mobile.git",
        "version_declaration": "Directory.Packages.props",
        "consumer_project": "src/Chummer.Play.Components/Chummer.Play.Components.csproj",
        "compatibility_mode": "package_reference_plus_representative_surface",
    },
}
SHA1_PATTERN = re.compile(r"[0-9a-f]{40}")
SHA256_PATTERN = re.compile(r"[0-9a-f]{64}")

MANIFEST_KEYS = {"contract", "package", "consumers"}
PACKAGE_KEYS = {"id", "license_expression", "target_framework", "version"}
CONSUMER_KEYS = {
    "compatibility_project",
    "compatibility_project_sha256",
    "compatibility_mode",
    "compatibility_source",
    "compatibility_source_sha256",
    "consumer_project",
    "consumer_project_sha256",
    "id",
    "package_version",
    "repository",
    "source_commit",
    "version_declaration",
    "version_declaration_sha256",
}


def local_name(tag: str) -> str:
    return tag.rsplit("}", 1)[-1]


def elements_named(root: ET.Element, name: str) -> list[ET.Element]:
    return [element for element in root.iter() if local_name(element.tag) == name]


def property_values(root: ET.Element, name: str) -> list[str]:
    return [(element.text or "").strip() for element in elements_named(root, name)]


def sha256_file(path: Path) -> str:
    digest = hashlib.sha256()
    with path.open("rb") as handle:
        for chunk in iter(lambda: handle.read(1024 * 1024), b""):
            digest.update(chunk)
    return digest.hexdigest()


def require_exact_keys(payload: dict[str, Any], expected: set[str], label: str, errors: list[str]) -> None:
    actual = set(payload)
    if actual != expected:
        missing = sorted(expected - actual)
        extra = sorted(actual - expected)
        errors.append(f"{label} keys drifted (missing={missing}, extra={extra})")


def require_single_property(
    root: ET.Element,
    name: str,
    expected: str,
    errors: list[str],
) -> None:
    values = property_values(root, name)
    if len(values) != 1:
        errors.append(f"project must contain exactly one {name} property; found {len(values)}")
        return
    if values[0] != expected:
        errors.append(f"project {name} must be {expected!r}; found {values[0]!r}")


def validate_package_project(project_path: Path) -> list[str]:
    errors: list[str] = []
    try:
        root = ET.parse(project_path).getroot()
    except (OSError, ET.ParseError) as exc:
        return [f"cannot parse package project {project_path}: {exc}"]

    require_single_property(root, "PackageId", PACKAGE_ID, errors)
    require_single_property(root, "PackageVersion", PACKAGE_VERSION, errors)
    require_single_property(root, "PackageLicenseExpression", LICENSE_EXPRESSION, errors)
    require_single_property(root, "PackageReadmeFile", "README.md", errors)
    require_single_property(root, "RuntimeIdentifiers", "$(RuntimeIdentifier)", errors)

    runtime_elements = elements_named(root, "RuntimeIdentifiers")
    if len(runtime_elements) == 1:
        expected_condition = "'$(RuntimeIdentifiers)' == '' and '$(RuntimeIdentifier)' != ''"
        if runtime_elements[0].get("Condition") != expected_condition:
            errors.append("RuntimeIdentifiers must retain the guarded RuntimeIdentifier propagation condition")

    if elements_named(root, "PackageLicenseFile"):
        errors.append("PackageLicenseFile must not compete with PackageLicenseExpression")
    if elements_named(root, "PackageReference") or elements_named(root, "ProjectReference"):
        errors.append("the UI Kit package project must remain free of package and project dependencies")
    return errors


def safe_repo_path(repo_root: Path, value: object, label: str, errors: list[str]) -> Path | None:
    if not isinstance(value, str) or not value or Path(value).is_absolute():
        errors.append(f"{label} must be a non-empty repo-relative path")
        return None
    candidate = (repo_root / value).resolve()
    try:
        candidate.relative_to(repo_root.resolve())
    except ValueError:
        errors.append(f"{label} escapes the repository root")
        return None
    return candidate


def validate_fixture_project(path: Path, expected_version: str) -> list[str]:
    errors: list[str] = []
    try:
        root = ET.parse(path).getroot()
    except (OSError, ET.ParseError) as exc:
        return [f"cannot parse compatibility project {path}: {exc}"]

    require_single_property(root, "TargetFramework", TARGET_FRAMEWORK, errors)
    require_single_property(root, "ChummerUiKitPackageVersion", expected_version, errors)
    package_references = elements_named(root, "PackageReference")
    if len(package_references) != 1:
        errors.append(f"compatibility project must contain exactly one PackageReference; found {len(package_references)}")
    elif (
        package_references[0].get("Include") != PACKAGE_ID
        or package_references[0].get("Version") != "$(ChummerUiKitPackageVersion)"
    ):
        errors.append("compatibility project must reference only the pinned Chummer.Ui.Kit coordinate")
    if elements_named(root, "ProjectReference"):
        errors.append("compatibility project must not use sibling/source ProjectReference inputs")
    return errors


def load_and_validate_manifest(repo_root: Path, manifest_path: Path) -> tuple[dict[str, Any] | None, list[str]]:
    errors: list[str] = []
    try:
        payload = json.loads(manifest_path.read_text(encoding="utf-8"))
    except (OSError, json.JSONDecodeError) as exc:
        return None, [f"cannot parse compatibility manifest {manifest_path}: {exc}"]
    if not isinstance(payload, dict):
        return None, ["compatibility manifest root must be an object"]

    require_exact_keys(payload, MANIFEST_KEYS, "manifest", errors)
    if payload.get("contract") != MANIFEST_CONTRACT:
        errors.append(f"manifest contract must be {MANIFEST_CONTRACT}")

    package = payload.get("package")
    if not isinstance(package, dict):
        errors.append("manifest package must be an object")
    else:
        require_exact_keys(package, PACKAGE_KEYS, "manifest package", errors)
        expected_package = {
            "id": PACKAGE_ID,
            "version": PACKAGE_VERSION,
            "license_expression": LICENSE_EXPRESSION,
            "target_framework": TARGET_FRAMEWORK,
        }
        if package != expected_package:
            errors.append(f"manifest package coordinate must be {expected_package}")

    consumers = payload.get("consumers")
    if not isinstance(consumers, list):
        errors.append("manifest consumers must be an array")
        return payload, errors

    ids: list[str] = []
    for index, consumer in enumerate(consumers):
        label = f"consumer[{index}]"
        if not isinstance(consumer, dict):
            errors.append(f"{label} must be an object")
            continue
        require_exact_keys(consumer, CONSUMER_KEYS, label, errors)
        consumer_id = consumer.get("id")
        if isinstance(consumer_id, str):
            ids.append(consumer_id)
        else:
            errors.append(f"{label} id must be a string")
        if consumer.get("package_version") != PACKAGE_VERSION:
            errors.append(f"{label} package_version must be pinned to {PACKAGE_VERSION}")
        source_commit = consumer.get("source_commit")
        if not isinstance(source_commit, str) or SHA1_PATTERN.fullmatch(source_commit) is None:
            errors.append(f"{label} source_commit must be a full immutable 40-character SHA")
        repository = consumer.get("repository")
        if not isinstance(repository, str) or not repository.startswith("https://github.com/ArchonMegalon/") or not repository.endswith(".git"):
            errors.append(f"{label} repository must be the canonical HTTPS Git repository")
        if isinstance(consumer_id, str) and consumer_id in CONSUMER_AUTHORITIES:
            authority = CONSUMER_AUTHORITIES[consumer_id]
            for key, expected in authority.items():
                if consumer.get(key) != expected:
                    errors.append(f"{label} {key} must be {expected!r}")
        for hash_key in (
            "compatibility_project_sha256",
            "compatibility_source_sha256",
            "consumer_project_sha256",
            "version_declaration_sha256",
        ):
            value = consumer.get(hash_key)
            if not isinstance(value, str) or SHA256_PATTERN.fullmatch(value) is None:
                errors.append(f"{label} {hash_key} must be a lowercase SHA256 digest")

        fixture_project = safe_repo_path(repo_root, consumer.get("compatibility_project"), f"{label} compatibility_project", errors)
        fixture_source = safe_repo_path(repo_root, consumer.get("compatibility_source"), f"{label} compatibility_source", errors)
        if fixture_project is not None:
            if not fixture_project.is_file():
                errors.append(f"{label} compatibility project is missing: {fixture_project}")
            else:
                errors.extend(validate_fixture_project(fixture_project, PACKAGE_VERSION))
                expected_digest = consumer.get("compatibility_project_sha256")
                if isinstance(expected_digest, str) and SHA256_PATTERN.fullmatch(expected_digest) and sha256_file(fixture_project) != expected_digest:
                    errors.append(f"{label} compatibility project digest drifted")
        if fixture_source is not None:
            if not fixture_source.is_file():
                errors.append(f"{label} compatibility source is missing: {fixture_source}")
            else:
                expected_digest = consumer.get("compatibility_source_sha256")
                if isinstance(expected_digest, str) and SHA256_PATTERN.fullmatch(expected_digest) and sha256_file(fixture_source) != expected_digest:
                    errors.append(f"{label} compatibility source digest drifted")

    if set(ids) != EXPECTED_CONSUMERS or len(ids) != len(EXPECTED_CONSUMERS):
        errors.append(f"manifest consumers must contain exactly {sorted(EXPECTED_CONSUMERS)} once each")
    return payload, errors


def validate_nupkg(nupkg_path: Path) -> list[str]:
    errors: list[str] = []
    try:
        with zipfile.ZipFile(nupkg_path) as archive:
            names = archive.namelist()
            nuspec_names = [name for name in names if name.endswith(".nuspec") and "/" not in name]
            if len(nuspec_names) != 1:
                return [f"package must contain exactly one root nuspec; found {len(nuspec_names)}"]
            root = ET.fromstring(archive.read(nuspec_names[0]))
            metadata_nodes = elements_named(root, "metadata")
            if len(metadata_nodes) != 1:
                return [f"package nuspec must contain exactly one metadata node; found {len(metadata_nodes)}"]
            metadata = metadata_nodes[0]
            require_single_property(metadata, "id", PACKAGE_ID, errors)
            require_single_property(metadata, "version", PACKAGE_VERSION, errors)
            license_nodes = elements_named(metadata, "license")
            if len(license_nodes) != 1:
                errors.append(f"package nuspec must contain exactly one license element; found {len(license_nodes)}")
            elif license_nodes[0].get("type") != "expression" or (license_nodes[0].text or "").strip() != LICENSE_EXPRESSION:
                errors.append(f"package license must be expression {LICENSE_EXPRESSION}")
            expected_library = f"lib/{TARGET_FRAMEWORK}/{PACKAGE_ID}.dll"
            if expected_library not in names:
                errors.append(f"package is missing {expected_library}")
            if "README.md" not in names:
                errors.append("package is missing its declared README.md")
    except (OSError, zipfile.BadZipFile, ET.ParseError) as exc:
        return [f"cannot inspect package {nupkg_path}: {exc}"]
    return errors


def parse_args(argv: list[str] | None = None) -> argparse.Namespace:
    parser = argparse.ArgumentParser(description="Verify UI Kit package metadata and pinned downstream compatibility inputs.")
    parser.add_argument("--repo-root", default=str(Path(__file__).resolve().parents[2]))
    parser.add_argument("--manifest", default="tests/compatibility/downstream-pins.json")
    parser.add_argument("--nupkg")
    return parser.parse_args(argv)


def main(argv: list[str] | None = None) -> int:
    args = parse_args(argv)
    repo_root = Path(args.repo_root).resolve()
    manifest_path = Path(args.manifest)
    if not manifest_path.is_absolute():
        manifest_path = repo_root / manifest_path

    errors = validate_package_project(repo_root / "src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj")
    _, manifest_errors = load_and_validate_manifest(repo_root, manifest_path)
    errors.extend(manifest_errors)
    if args.nupkg:
        errors.extend(validate_nupkg(Path(args.nupkg).resolve()))

    if errors:
        for error in errors:
            print(f"package hygiene: FAIL: {error}", file=sys.stderr)
        return 1
    print("package hygiene: PASS")
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
