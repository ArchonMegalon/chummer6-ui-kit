from __future__ import annotations

import importlib.util
import json
import tempfile
import unittest
from pathlib import Path


MODULE_PATH = Path(__file__).resolve().parents[1] / "scripts" / "ai" / "materialize_ui_kit_release_proof.py"
SPEC = importlib.util.spec_from_file_location("materialize_ui_kit_release_proof", MODULE_PATH)
assert SPEC is not None and SPEC.loader is not None
MODULE = importlib.util.module_from_spec(SPEC)
SPEC.loader.exec_module(MODULE)


class ResolveTaskLocalTelemetryPathTests(unittest.TestCase):
    def test_prefers_latest_matching_m142_receipt(self) -> None:
        with tempfile.TemporaryDirectory() as tmp:
            runs_root = Path(tmp)
            older_run = runs_root / "20260506T065325Z-shard-2"
            newer_nonmatching_run = runs_root / "20260506T070639Z-shard-2"
            newest_matching_run = runs_root / "20260506T071500Z-shard-2"

            older_run.mkdir()
            newer_nonmatching_run.mkdir()
            newest_matching_run.mkdir()

            (older_run / "TASK_LOCAL_TELEMETRY.generated.json").write_text(
                json.dumps(
                    {
                        "package_id": "next90-m142-ui-kit-bind-dense-workbench-and-noise-budget-proof-for-these-families-into-t",
                        "frontier": "1971223526",
                        "milestone_id": 142,
                        "repo": "chummer6-ui-kit",
                        "title": "Bind dense-workbench and noise-budget proof for these families into the flagship preset and fail-close on stale chrome regressions.",
                    }
                ),
                encoding="utf-8",
            )
            (newer_nonmatching_run / "TASK_LOCAL_TELEMETRY.generated.json").write_text(
                '{"package_id":"another-package","frontier":"1971223526"}',
                encoding="utf-8",
            )
            newest_path = newest_matching_run / "TASK_LOCAL_TELEMETRY.generated.json"
            newest_path.write_text(
                json.dumps(
                    {
                        "package_id": "next90-m142-ui-kit-bind-dense-workbench-and-noise-budget-proof-for-these-families-into-t",
                        "frontier": "1971223526",
                        "milestone_id": 142,
                        "repo": "chummer6-ui-kit",
                        "title": "Bind dense-workbench and noise-budget proof for these families into the flagship preset and fail-close on stale chrome regressions.",
                    }
                ),
                encoding="utf-8",
            )

            resolved = MODULE.resolve_task_local_telemetry_path(runs_root)

            self.assertEqual(newest_path, resolved)

    def test_returns_none_when_no_matching_receipt_exists(self) -> None:
        with tempfile.TemporaryDirectory() as tmp:
            runs_root = Path(tmp)
            run_dir = runs_root / "20260506T071500Z-shard-2"
            run_dir.mkdir()
            (run_dir / "TASK_LOCAL_TELEMETRY.generated.json").write_text(
                '{"package_id":"another-package","frontier":"1971223526"}',
                encoding="utf-8",
            )

            self.assertIsNone(MODULE.resolve_task_local_telemetry_path(runs_root))


class ProofFloorMarkerTests(unittest.TestCase):
    def test_m142_program_markers_require_stale_chrome_and_token_backed_guards(self) -> None:
        markers = MODULE.M142_SOURCE_MARKERS["tests/Chummer.Ui.Kit.Tests/Program.cs"]

        self.assertIn("FlagshipClassicDenseWorkbenchDefaultIsTokenBacked", markers)
        self.assertIn("classic dense-workbench stale chrome sentinel list fails closed", markers)
        self.assertIn("classic dense-workbench non-canonical proof family broadening fails closed", markers)

    def test_verify_script_markers_require_same_guard_floor(self) -> None:
        markers = MODULE.VERIFY_SCRIPT_MARKERS

        self.assertIn("FlagshipClassicDenseWorkbenchDefaultIsTokenBacked", markers)
        self.assertIn("classic dense-workbench stale chrome sentinel list fails closed", markers)
        self.assertIn("classic dense-workbench non-canonical proof family broadening fails closed", markers)


if __name__ == "__main__":
    unittest.main()
