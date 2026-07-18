from __future__ import annotations

import copy
import importlib.util
import json
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
