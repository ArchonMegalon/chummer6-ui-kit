from __future__ import annotations

import copy
import hashlib
import importlib.util
import json
import subprocess
import tempfile
import unittest
import zipfile
from pathlib import Path


REPO_ROOT = Path(__file__).resolve().parents[1]
MODULE_PATH = REPO_ROOT / "scripts/ai/verify_package_hygiene.py"
SPEC = importlib.util.spec_from_file_location("verify_package_hygiene", MODULE_PATH)
assert SPEC is not None and SPEC.loader is not None
MODULE = importlib.util.module_from_spec(SPEC)
SPEC.loader.exec_module(MODULE)


class PackageProjectTests(unittest.TestCase):
    def test_current_package_project_has_one_runtime_projection_and_explicit_license(self) -> None:
        errors = MODULE.validate_package_project(
            REPO_ROOT / "src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj"
        )

        self.assertEqual([], errors)

    def test_duplicate_runtime_identifier_property_fails_closed(self) -> None:
        original = (REPO_ROOT / "src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj").read_text(
            encoding="utf-8"
        )
        runtime_line = (
            "    <RuntimeIdentifiers Condition=\"'$(RuntimeIdentifiers)' == '' and "
            "'$(RuntimeIdentifier)' != ''\">$(RuntimeIdentifier)</RuntimeIdentifiers>\n"
        )
        self.assertEqual(1, original.count(runtime_line))
        with tempfile.TemporaryDirectory() as tmp:
            project = Path(tmp) / "Chummer.Ui.Kit.csproj"
            project.write_text(original.replace(runtime_line, runtime_line * 2), encoding="utf-8")

            errors = MODULE.validate_package_project(project)

        self.assertTrue(any("exactly one RuntimeIdentifiers" in error for error in errors))

    def test_license_expression_drift_fails_closed(self) -> None:
        original = (REPO_ROOT / "src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj").read_text(
            encoding="utf-8"
        )
        with tempfile.TemporaryDirectory() as tmp:
            project = Path(tmp) / "Chummer.Ui.Kit.csproj"
            project.write_text(
                original.replace("GPL-3.0-only", "MIT"),
                encoding="utf-8",
            )

            errors = MODULE.validate_package_project(project)

        self.assertTrue(any("PackageLicenseExpression" in error for error in errors))

    def test_package_coordinate_drift_fails_closed(self) -> None:
        original = (REPO_ROOT / "src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj").read_text(
            encoding="utf-8"
        )
        with tempfile.TemporaryDirectory() as tmp:
            project = Path(tmp) / "Chummer.Ui.Kit.csproj"
            project.write_text(
                original.replace("0.1.0-preview", "1.0.0"),
                encoding="utf-8",
            )

            errors = MODULE.validate_package_project(project)

        self.assertTrue(any("PackageVersion" in error for error in errors))

    def test_missing_package_readme_declaration_fails_closed(self) -> None:
        original = (REPO_ROOT / "src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj").read_text(
            encoding="utf-8"
        )
        with tempfile.TemporaryDirectory() as tmp:
            project = Path(tmp) / "Chummer.Ui.Kit.csproj"
            project.write_text(
                original.replace("    <PackageReadmeFile>README.md</PackageReadmeFile>\n", ""),
                encoding="utf-8",
            )

            errors = MODULE.validate_package_project(project)

        self.assertTrue(any("PackageReadmeFile" in error for error in errors))


class DownstreamManifestTests(unittest.TestCase):
    def setUp(self) -> None:
        self.manifest_path = REPO_ROOT / "tests/compatibility/downstream-pins.json"
        self.payload = json.loads(self.manifest_path.read_text(encoding="utf-8"))

    def validate_mutation(self, payload: dict[str, object]) -> list[str]:
        with tempfile.TemporaryDirectory() as tmp:
            path = Path(tmp) / "downstream-pins.json"
            path.write_text(json.dumps(payload), encoding="utf-8")
            _, errors = MODULE.load_and_validate_manifest(REPO_ROOT, path)
        return errors

    def test_current_manifest_binds_both_exact_consumer_commits_and_fixtures(self) -> None:
        _, errors = MODULE.load_and_validate_manifest(REPO_ROOT, self.manifest_path)

        self.assertEqual([], errors)

    def test_moving_consumer_ref_fails_closed(self) -> None:
        payload = copy.deepcopy(self.payload)
        payload["consumers"][0]["source_commit"] = "main"

        errors = self.validate_mutation(payload)

        self.assertTrue(any("full immutable 40-character SHA" in error for error in errors))

    def test_consumer_package_version_drift_fails_closed(self) -> None:
        payload = copy.deepcopy(self.payload)
        payload["consumers"][1]["package_version"] = "1.0.0"

        errors = self.validate_mutation(payload)

        self.assertTrue(any("package_version must be pinned" in error for error in errors))

    def test_duplicate_consumer_identity_fails_closed(self) -> None:
        payload = copy.deepcopy(self.payload)
        payload["consumers"][1]["id"] = payload["consumers"][0]["id"]

        errors = self.validate_mutation(payload)

        self.assertTrue(any("exactly ['chummer6-mobile', 'chummer6-ui']" in error for error in errors))

    def test_consumer_authority_paths_cannot_be_cross_wired(self) -> None:
        payload = copy.deepcopy(self.payload)
        payload["consumers"][0]["repository"] = "https://github.com/ArchonMegalon/chummer6-mobile.git"

        errors = self.validate_mutation(payload)

        self.assertTrue(any("repository must be 'https://github.com/ArchonMegalon/chummer6-ui.git'" in error for error in errors))

    def test_mobile_representative_contract_cannot_masquerade_as_exact_source(self) -> None:
        payload = copy.deepcopy(self.payload)
        payload["consumers"][1]["compatibility_mode"] = "exact_source_snapshot"

        errors = self.validate_mutation(payload)

        self.assertTrue(any("compatibility_mode must be 'package_reference_plus_representative_surface'" in error for error in errors))

    def test_fixture_digest_drift_fails_closed(self) -> None:
        payload = copy.deepcopy(self.payload)
        payload["consumers"][0]["compatibility_source_sha256"] = "0" * 64

        errors = self.validate_mutation(payload)

        self.assertTrue(any("compatibility source digest drifted" in error for error in errors))


class CompatibilityProjectTests(unittest.TestCase):
    def test_sibling_project_reference_fails_closed(self) -> None:
        original = (
            REPO_ROOT
            / "tests/compatibility/chummer6-mobile/Chummer.Ui.Kit.Downstream.Mobile.csproj"
        ).read_text(encoding="utf-8")
        with tempfile.TemporaryDirectory() as tmp:
            project = Path(tmp) / "Compatibility.csproj"
            project.write_text(
                original.replace(
                    "</Project>",
                    "  <ItemGroup><ProjectReference Include=\"../../src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj\" /></ItemGroup>\n</Project>",
                ),
                encoding="utf-8",
            )

            errors = MODULE.validate_fixture_project(project, "0.1.0-preview")

        self.assertTrue(any("must not use sibling/source ProjectReference" in error for error in errors))


class AuthorityRepositoryTests(unittest.TestCase):
    def run_git(self, *args: str, cwd: Path | None = None) -> str:
        completed = subprocess.run(
            ["git", *args],
            cwd=cwd,
            check=True,
            stdout=subprocess.PIPE,
            stderr=subprocess.PIPE,
            text=True,
        )
        return completed.stdout.strip()

    def build_authorities(
        self,
        root: Path,
    ) -> tuple[Path, dict[str, object], dict[str, Path]]:
        fixture_root = root / "fixture-root"
        payload = json.loads(
            (REPO_ROOT / "tests/compatibility/downstream-pins.json").read_text(encoding="utf-8")
        )
        authorities: dict[str, Path] = {}

        for consumer in payload["consumers"]:
            consumer_id = consumer["id"]
            source_repo = root / f"source-{consumer_id}"
            source_repo.mkdir()
            self.run_git("init", "--quiet", cwd=source_repo)
            self.run_git("config", "user.name", "UI Kit Tests", cwd=source_repo)
            self.run_git("config", "user.email", "ui-kit-tests@example.invalid", cwd=source_repo)

            version_bytes = f"{consumer_id} version authority\n".encode()
            project_bytes = f"{consumer_id} project authority\n".encode()
            version_path = source_repo / consumer["version_declaration"]
            project_path = source_repo / consumer["consumer_project"]
            version_path.parent.mkdir(parents=True, exist_ok=True)
            project_path.parent.mkdir(parents=True, exist_ok=True)
            version_path.write_bytes(version_bytes)
            project_path.write_bytes(project_bytes)
            consumer["version_declaration_sha256"] = hashlib.sha256(version_bytes).hexdigest()
            consumer["consumer_project_sha256"] = hashlib.sha256(project_bytes).hexdigest()

            if consumer["compatibility_mode"] == "exact_source_snapshot":
                fixture_source = fixture_root / consumer["compatibility_source"]
                fixture_source.parent.mkdir(parents=True, exist_ok=True)
                fixture_bytes = (
                    REPO_ROOT / consumer["compatibility_source"]
                ).read_bytes()
                fixture_source.write_bytes(fixture_bytes)
                authority_source = source_repo / consumer["authority_source"]
                authority_source.parent.mkdir(parents=True, exist_ok=True)
                authority_source.write_bytes(fixture_bytes)
                digest = hashlib.sha256(fixture_bytes).hexdigest()
                consumer["compatibility_source_sha256"] = digest
                consumer["authority_source_sha256"] = digest

            self.run_git("add", ".", cwd=source_repo)
            self.run_git("commit", "--quiet", "-m", f"fixture {consumer_id}", cwd=source_repo)
            source_commit = self.run_git("rev-parse", "HEAD", cwd=source_repo)
            consumer["source_commit"] = source_commit

            authority_repo = root / f"authority-{consumer_id}.git"
            self.run_git("init", "--quiet", "--bare", str(authority_repo))
            self.run_git(
                f"--git-dir={authority_repo}",
                "fetch",
                "--quiet",
                "--no-tags",
                str(source_repo),
                source_commit,
            )
            self.run_git(
                f"--git-dir={authority_repo}",
                "remote",
                "add",
                "origin",
                consumer["repository"],
            )
            authorities[consumer_id] = authority_repo

        return fixture_root, payload, authorities

    def test_exact_pinned_authority_bytes_pass(self) -> None:
        with tempfile.TemporaryDirectory() as tmp:
            fixture_root, payload, authorities = self.build_authorities(Path(tmp))

            errors = MODULE.validate_authority_repositories(
                fixture_root,
                payload,
                authorities,
            )

        self.assertEqual([], errors)

    def test_forged_authority_hashes_fail_against_acquired_commit_bytes(self) -> None:
        with tempfile.TemporaryDirectory() as tmp:
            fixture_root, payload, authorities = self.build_authorities(Path(tmp))
            payload["consumers"][0]["version_declaration_sha256"] = "0" * 64
            payload["consumers"][1]["consumer_project_sha256"] = "f" * 64

            errors = MODULE.validate_authority_repositories(
                fixture_root,
                payload,
                authorities,
            )

        self.assertTrue(any("version_declaration digest mismatch" in error for error in errors))
        self.assertTrue(any("consumer_project digest mismatch" in error for error in errors))

    def test_forged_ui_fixture_fails_byte_for_byte_authority_comparison(self) -> None:
        with tempfile.TemporaryDirectory() as tmp:
            fixture_root, payload, authorities = self.build_authorities(Path(tmp))
            ui = next(item for item in payload["consumers"] if item["id"] == "chummer6-ui")
            (fixture_root / ui["compatibility_source"]).write_text(
                "forged local fixture\n",
                encoding="utf-8",
            )

            errors = MODULE.validate_authority_repositories(
                fixture_root,
                payload,
                authorities,
            )

        self.assertTrue(any("fixture bytes do not match" in error for error in errors))

    def test_changed_pin_fails_against_acquired_fetch_head(self) -> None:
        with tempfile.TemporaryDirectory() as tmp:
            fixture_root, payload, authorities = self.build_authorities(Path(tmp))
            payload["consumers"][0]["source_commit"] = "0" * 40

            errors = MODULE.validate_authority_repositories(
                fixture_root,
                payload,
                authorities,
            )

        self.assertTrue(any("does not match pin" in error for error in errors))


class PackedMetadataTests(unittest.TestCase):
    def write_nupkg(self, path: Path, license_expression: str) -> None:
        nuspec = f"""<?xml version=\"1.0\"?>
<package xmlns=\"http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd\">
  <metadata>
    <id>Chummer.Ui.Kit</id>
    <version>0.1.0-preview</version>
    <license type=\"expression\">{license_expression}</license>
  </metadata>
</package>
"""
        with zipfile.ZipFile(path, "w") as archive:
            archive.writestr("Chummer.Ui.Kit.nuspec", nuspec)
            archive.writestr("lib/net10.0/Chummer.Ui.Kit.dll", b"fixture")
            archive.writestr("README.md", "fixture")

    def test_expected_packed_license_metadata_passes(self) -> None:
        with tempfile.TemporaryDirectory() as tmp:
            nupkg = Path(tmp) / "Chummer.Ui.Kit.0.1.0-preview.nupkg"
            self.write_nupkg(nupkg, "GPL-3.0-only")

            errors = MODULE.validate_nupkg(nupkg)

        self.assertEqual([], errors)

    def test_packed_license_metadata_drift_fails_closed(self) -> None:
        with tempfile.TemporaryDirectory() as tmp:
            nupkg = Path(tmp) / "Chummer.Ui.Kit.0.1.0-preview.nupkg"
            self.write_nupkg(nupkg, "MIT")

            errors = MODULE.validate_nupkg(nupkg)

        self.assertTrue(any("package license" in error for error in errors))


if __name__ == "__main__":
    unittest.main()
