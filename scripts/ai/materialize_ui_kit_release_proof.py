#!/usr/bin/env python3
from __future__ import annotations

import argparse
import datetime as dt
import json
from pathlib import Path

UTC = dt.timezone.utc
M142_PACKAGE_ID = "next90-m142-ui-kit-bind-dense-workbench-and-noise-budget-proof-for-these-families-into-t"
M142_WORK_TASK_ID = "142.2"
M142_CANONICAL_QUEUE_FRONTIER_ID = "1752713026"
M142_TASK_LOCAL_HANDOFF_FRONTIER_ID = "1971223526"
SUCCESSOR_QUEUE_PATH = Path("/docker/fleet/.codex-studio/published/NEXT_90_DAY_QUEUE_STAGING.generated.yaml")
SUCCESSOR_REGISTRY_PATH = Path("/docker/chummercomplete/chummer-design/products/chummer/NEXT_90_DAY_PRODUCT_ADVANCE_REGISTRY.yaml")
TASK_LOCAL_TELEMETRY_RUNS_ROOT = Path("/var/lib/codex-fleet/chummer_design_supervisor/shard-2/runs")
RUNTIME_HANDOFF_PATH = Path("/var/lib/codex-fleet/chummer_design_supervisor/shard-2/ACTIVE_RUN_HANDOFF.generated.md")
TASK_LOCAL_TELEMETRY_SELECTOR = (
    f"latest matching worker receipt under {TASK_LOCAL_TELEMETRY_RUNS_ROOT}/*/TASK_LOCAL_TELEMETRY.generated.json"
)

M121_DOC_MARKERS = (
    "ActionBudgetBar",
    "ConditionEffectChip",
    "SourceAnchorDrawer",
    "RunboardCard",
    "scripts/ai/materialize_ui_kit_release_proof.py",
)

M121_SOURCE_MARKERS = {
    "src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs": (
        "public sealed class ActionBudgetBar",
        "public sealed class ConditionEffectChip",
        "public sealed class SourceAnchorDrawer",
        "public sealed class RunboardCard",
    ),
    "src/Chummer.Ui.Kit/Adapters/Blazor/BlazorUiKitAdapter.cs": (
        "public static UiAdapterPayload AdaptActionBudgetBar(ActionBudgetBar budget)",
        "public static UiAdapterPayload AdaptConditionEffectChip(ConditionEffectChip chip)",
        "public static UiAdapterPayload AdaptSourceAnchorDrawer(SourceAnchorDrawer drawer)",
        "public static UiAdapterPayload AdaptRunboardCard(RunboardCard card)",
    ),
    "src/Chummer.Ui.Kit/Adapters/Avalonia/AvaloniaUiKitAdapter.cs": (
        "public static UiAdapterPayload AdaptActionBudgetBar(ActionBudgetBar budget)",
        "public static UiAdapterPayload AdaptConditionEffectChip(ConditionEffectChip chip)",
        "public static UiAdapterPayload AdaptSourceAnchorDrawer(SourceAnchorDrawer drawer)",
        "public static UiAdapterPayload AdaptRunboardCard(RunboardCard card)",
    ),
    "src/Chummer.Ui.Kit/Preview/PreviewGalleryManifest.cs": (
        "[\"action_budget_bars\"]",
        "[\"condition_effect_chips\"]",
        "[\"source_anchor_drawers\"]",
        "[\"runboard_primitives\"]",
    ),
    "src/Chummer.Ui.Kit/Tokens/TokenCanon.cs": (
        "\"action.budget.bar.root.class\"",
        "\"condition.effect.chip.root.class\"",
        "\"source.anchor.drawer.root.class\"",
        "\"runboard.card.root.class\"",
    ),
    "tests/Chummer.Ui.Kit.Tests/Program.cs": (
        "ActionBudgetBar",
        "ConditionEffectChip",
        "SourceAnchorDrawer",
        "RunboardCard",
        "DefaultCanonContainsRunboardAndSourceAnchorTokens",
        "BlazorAndAvaloniaPayloadsStayDeterministic",
    ),
}

M121_SNAPSHOT_PATHS = (
    "tests/Chummer.Ui.Kit.Tests/Snapshots/blazor.action-budget-bar.snapshot",
    "tests/Chummer.Ui.Kit.Tests/Snapshots/blazor.condition-effect-chip.snapshot",
    "tests/Chummer.Ui.Kit.Tests/Snapshots/blazor.source-anchor-drawer.snapshot",
    "tests/Chummer.Ui.Kit.Tests/Snapshots/blazor.runboard-card.snapshot",
    "tests/Chummer.Ui.Kit.Tests/Snapshots/avalonia.action-budget-bar.snapshot",
    "tests/Chummer.Ui.Kit.Tests/Snapshots/avalonia.condition-effect-chip.snapshot",
    "tests/Chummer.Ui.Kit.Tests/Snapshots/avalonia.source-anchor-drawer.snapshot",
    "tests/Chummer.Ui.Kit.Tests/Snapshots/avalonia.runboard-card.snapshot",
)

M142_DOC_MARKERS = (
    M142_PACKAGE_ID,
    M142_WORK_TASK_ID,
    M142_CANONICAL_QUEUE_FRONTIER_ID,
    M142_TASK_LOCAL_HANDOFF_FRONTIER_ID,
    TASK_LOCAL_TELEMETRY_SELECTOR,
    "ACTIVE_RUN_HANDOFF.generated.md",
    "classic_dense_workbench",
    "family:dense_builder_and_career_workflows",
    "family:dice_initiative_and_table_utilities",
    "family:identity_contacts_lifestyles_history",
    "hero-banner max height",
    "dashboard-tile max count in the toolstrip",
    "decorative landing chrome max count in the workbench",
    "menu/toolstrip combined height max",
    "FlagshipDesktopDefault",
)

M142_QUEUE_MARKERS = (
    M142_PACKAGE_ID,
    "work_task_id: '142.2'",
    M142_CANONICAL_QUEUE_FRONTIER_ID,
    "milestone_id: 142",
    "wave: W22P",
    "repo: chummer6-ui-kit",
    "bind_dense_workbench_and_noise_budget_proof_for_these_fa:ui_kit",
)

M142_REGISTRY_MARKERS = (
    "    - id: '142.2'",
    "      owner: chummer6-ui-kit",
    "      title: Bind dense-workbench and noise-budget proof for these families into the flagship preset and fail-close on stale chrome regressions.",
)

M142_SOURCE_MARKERS = {
    "src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs": (
        "public sealed class ClassicDenseWorkbenchPreset",
        "private static readonly string[] RequiredProofFamilyIds",
        "BuildExpectedChromeRegressionSentinels(",
        "PrimitiveGuards.NormalizeExactContractIdList(",
    ),
    "src/Chummer.Ui.Kit/Adapters/Blazor/BlazorUiKitAdapter.cs": (
        "public static UiAdapterPayload AdaptClassicDenseWorkbenchPreset(ClassicDenseWorkbenchPreset preset)",
        "\"data-proof-family-ids\"",
        "\"data-chrome-regression-sentinels\"",
        "\"data-flagship-default-avalonia\"",
    ),
    "src/Chummer.Ui.Kit/Adapters/Avalonia/AvaloniaUiKitAdapter.cs": (
        "public static UiAdapterPayload AdaptClassicDenseWorkbenchPreset(ClassicDenseWorkbenchPreset preset)",
        "\"proof-family-ids\"",
        "\"chrome-regression-sentinels\"",
        "\"flagship-default-avalonia\"",
    ),
    "src/Chummer.Ui.Kit/Preview/PreviewGalleryManifest.cs": (
        "[\"classic_dense_workbench\"]",
    ),
    "src/Chummer.Ui.Kit/Tokens/TokenCanon.cs": (
        "\"classic.dense.workbench.preset.id\"",
        "\"classic.dense.workbench.proof.family.ids\"",
        "\"classic.dense.workbench.chrome.regression.sentinels\"",
        "\"noise.budget.decorative.landing.chrome.max\"",
        "\"workbench.visible.dense.list.row.min\"",
        "\"workbench.visible.dense.detail.group.field.min\"",
    ),
    "tests/Chummer.Ui.Kit.Tests/Program.cs": (
        "DefaultCanonContainsClassicDenseWorkbenchTokens",
        "FlagshipClassicDenseWorkbenchDefaultIsTokenBacked",
        "classic dense-workbench missing required proof family ids fails closed",
        "classic dense-workbench missing required chrome sentinel fails closed",
        "classic dense-workbench stale chrome sentinel list fails closed",
        "classic dense-workbench non-canonical proof family broadening fails closed",
        "blazor classic dense-workbench payload",
        "avalonia classic dense-workbench payload",
        "FlagshipDesktopDefault",
    ),
}

M142_SNAPSHOT_PATHS = (
    "tests/Chummer.Ui.Kit.Tests/Snapshots/blazor.classic-dense-workbench.snapshot",
    "tests/Chummer.Ui.Kit.Tests/Snapshots/avalonia.classic-dense-workbench.snapshot",
)

VERIFY_SCRIPT_MARKERS = (
    "docs/m121-live-action-economy-evidence.md",
    "docs/m142-classic-dense-workbench-evidence.md",
    "TASK_LOCAL_TELEMETRY.generated.json",
    "ACTIVE_RUN_HANDOFF.generated.md",
    "family:dense_builder_and_career_workflows",
    "family:dice_initiative_and_table_utilities",
    "family:identity_contacts_lifestyles_history",
    "FlagshipClassicDenseWorkbenchDefaultIsTokenBacked",
    "classic dense-workbench stale chrome sentinel list fails closed",
    "classic dense-workbench non-canonical proof family broadening fails closed",
    "hero-banner max height",
    "menu/toolstrip combined height max",
    "persistent secondary badge-cluster max",
)

WORKLIST_MARKERS = (
    "Implementation evidence update (2026-05-05, M142 dense-workbench proof binding):",
    "[x] Bound the M142 flagship families directly into the preset contract",
    "[x] Extended deterministic Blazor/Avalonia payloads and snapshots so stale chrome regressions fail on package contract drift before downstream desktop proof is republished.",
    "[x] Re-ran `bash scripts/ai/verify.sh` and `python3 scripts/ai/materialize_ui_kit_release_proof.py --check` on 2026-05-05;",
    "System re-entry evidence update (2026-05-06, M142 successor closure pass):",
    M142_PACKAGE_ID,
    M142_CANONICAL_QUEUE_FRONTIER_ID,
    M142_TASK_LOCAL_HANDOFF_FRONTIER_ID,
)

TASK_LOCAL_TELEMETRY_MARKERS = (
    M142_PACKAGE_ID,
    M142_TASK_LOCAL_HANDOFF_FRONTIER_ID,
    '"milestone_id": 142',
    '"repo": "chummer6-ui-kit"',
    '"title": "Bind dense-workbench and noise-budget proof for these families into the flagship preset and fail-close on stale chrome regressions."',
)

def _iso_now() -> str:
    return dt.datetime.now(UTC).replace(microsecond=0).isoformat().replace("+00:00", "Z")


def parse_args() -> argparse.Namespace:
    parser = argparse.ArgumentParser(description="Materialize UI kit local release proof artifact.")
    parser.add_argument("--repo-root", default="/docker/chummercomplete/chummer-ui-kit")
    parser.add_argument(
        "--out",
        default="/docker/chummercomplete/chummer-ui-kit/.codex-studio/published/UI_KIT_LOCAL_RELEASE_PROOF.generated.json",
    )
    parser.add_argument(
        "--check",
        action="store_true",
        help="Validate the tracked artifact is up to date without writing it.",
    )
    return parser.parse_args()


def require_file(path: Path, reason: str, reasons: list[str]) -> bool:
    if path.is_file():
        return True

    reasons.append(reason)
    return False


def require_markers(path: Path, markers: tuple[str, ...], reason_prefix: str, reasons: list[str]) -> None:
    text = path.read_text(encoding="utf-8")
    missing = [marker for marker in markers if marker not in text]
    if missing:
        reasons.append(f"{reason_prefix}: missing {', '.join(missing)}")


def resolve_task_local_telemetry_path(runs_root: Path) -> Path | None:
    if not runs_root.is_dir():
        return None

    candidates = sorted(
        runs_root.glob("*/TASK_LOCAL_TELEMETRY.generated.json"),
        key=lambda path: path.parent.name,
        reverse=True,
    )

    for candidate in candidates:
        try:
            text = candidate.read_text(encoding="utf-8")
        except OSError:
            continue

        if all(marker in text for marker in TASK_LOCAL_TELEMETRY_MARKERS):
            return candidate

    return None


def build_runtime_handoff_markers(task_local_telemetry_path: Path) -> tuple[str, ...]:
    run_id = task_local_telemetry_path.parent.name
    return (
        f"Frontier ids: {M142_TASK_LOCAL_HANDOFF_FRONTIER_ID}",
        f"Run id: {run_id}",
        f"Prompt path: /var/lib/codex-fleet/chummer_design_supervisor/shard-2/runs/{run_id}/prompt.txt",
    )


def build_runtime_handoff_rule() -> str:
    return (
        "ACTIVE_RUN_HANDOFF.generated.md must expose the current frontier id, run id, "
        "and prompt path for the latest matching worker receipt."
    )


def main() -> int:
    args = parse_args()
    repo_root = Path(args.repo_root).resolve()
    out_path = Path(args.out).resolve()

    signoff_doc = repo_root / "docs" / "SHARED_SURFACE_SIGNOFF.md"
    adoption_doc = repo_root / "docs" / "u7-u8-release-adoption-evidence.md"
    milestone_121_doc = repo_root / "docs" / "m121-live-action-economy-evidence.md"
    milestone_142_doc = repo_root / "docs" / "m142-classic-dense-workbench-evidence.md"
    verify_script = repo_root / "scripts" / "ai" / "verify.sh"
    worklist_path = repo_root / "WORKLIST.md"

    reasons: list[str] = []

    if require_file(signoff_doc, "Missing shared-surface signoff document.", reasons):
        require_markers(
            signoff_doc,
            ("milestone `121`", "milestone `142` classic dense-workbench flagship preset"),
            "Shared-surface signoff drifted away from milestone evidence closure",
            reasons,
        )
    if require_file(adoption_doc, "Missing U7/U8 release adoption evidence document.", reasons):
        require_markers(
            adoption_doc,
            ("classic_dense_workbench", "blazor.classic-dense-workbench.snapshot", "avalonia.classic-dense-workbench.snapshot"),
            "U7/U8 release adoption evidence drifted away from dense-workbench proof anchors",
            reasons,
        )
    if require_file(milestone_121_doc, "Missing milestone 121 live action-economy evidence document.", reasons):
        require_markers(
            milestone_121_doc,
            M121_DOC_MARKERS,
            "Milestone 121 evidence drifted away from the required shared primitive anchors",
            reasons,
        )
    for relative_path, markers in M121_SOURCE_MARKERS.items():
        source_path = repo_root / relative_path
        if require_file(source_path, f"Missing milestone 121 source anchor: {relative_path}", reasons):
            require_markers(
                source_path,
                markers,
                f"Milestone 121 source anchor drifted: {relative_path}",
                reasons,
            )
    for relative_path in M121_SNAPSHOT_PATHS:
        require_file(
            repo_root / relative_path,
            f"Missing milestone 121 snapshot anchor: {relative_path}",
            reasons,
        )
    if require_file(milestone_142_doc, "Missing milestone 142 classic dense-workbench evidence document.", reasons):
        require_markers(
            milestone_142_doc,
            M142_DOC_MARKERS,
            "Milestone 142 evidence drifted away from the required dense-workbench proof anchors",
            reasons,
        )
    for relative_path, markers in M142_SOURCE_MARKERS.items():
        source_path = repo_root / relative_path
        if require_file(source_path, f"Missing milestone 142 source anchor: {relative_path}", reasons):
            require_markers(
                source_path,
                markers,
                f"Milestone 142 source anchor drifted: {relative_path}",
                reasons,
            )
    for relative_path in M142_SNAPSHOT_PATHS:
        require_file(
            repo_root / relative_path,
            f"Missing milestone 142 snapshot anchor: {relative_path}",
            reasons,
        )
    if require_file(SUCCESSOR_QUEUE_PATH, f"Missing canonical successor queue mirror: {SUCCESSOR_QUEUE_PATH}", reasons):
        require_markers(
            SUCCESSOR_QUEUE_PATH,
            M142_QUEUE_MARKERS,
            "Canonical successor queue mirror drifted away from the M142 ui-kit package row",
            reasons,
        )
    if require_file(SUCCESSOR_REGISTRY_PATH, f"Missing canonical successor registry: {SUCCESSOR_REGISTRY_PATH}", reasons):
        require_markers(
            SUCCESSOR_REGISTRY_PATH,
            M142_REGISTRY_MARKERS,
            "Canonical successor registry drifted away from the M142 ui-kit work-task row",
            reasons,
        )
    task_local_telemetry_path = resolve_task_local_telemetry_path(TASK_LOCAL_TELEMETRY_RUNS_ROOT)
    if task_local_telemetry_path is None:
        reasons.append(
            f"Missing task-local telemetry snapshot under {TASK_LOCAL_TELEMETRY_RUNS_ROOT} for the current M142 ui-kit worker package receipt."
        )
    else:
        require_markers(
            task_local_telemetry_path,
            TASK_LOCAL_TELEMETRY_MARKERS,
            "Task-local telemetry drifted away from the M142 ui-kit worker package receipt",
            reasons,
        )
        require_markers(
            milestone_142_doc,
            (TASK_LOCAL_TELEMETRY_SELECTOR, build_runtime_handoff_rule()),
            "Milestone 142 evidence drifted away from the dynamic worker-receipt closure rule",
            reasons,
        )
    if require_file(RUNTIME_HANDOFF_PATH, f"Missing runtime handoff snapshot: {RUNTIME_HANDOFF_PATH}", reasons):
        if task_local_telemetry_path is None:
            require_markers(
                RUNTIME_HANDOFF_PATH,
                (f"Frontier ids: {M142_TASK_LOCAL_HANDOFF_FRONTIER_ID}",),
                "Runtime handoff drifted away from the M142 ui-kit frontier receipt",
                reasons,
            )
        else:
            require_markers(
                RUNTIME_HANDOFF_PATH,
                build_runtime_handoff_markers(task_local_telemetry_path),
                "Runtime handoff drifted away from the current M142 ui-kit worker receipt",
                reasons,
            )
    if require_file(verify_script, "Missing ui-kit verify lane script.", reasons):
        require_markers(
            verify_script,
            VERIFY_SCRIPT_MARKERS,
            "Verify lane drifted away from the required dense-workbench fail-close markers",
            reasons,
        )
    if require_file(worklist_path, "Missing ui-kit worklist.", reasons):
        require_markers(
            worklist_path,
            WORKLIST_MARKERS,
            "Worklist drifted away from the recorded milestone 142 closure evidence",
            reasons,
        )

    status = "passed" if not reasons else "failed"

    payload = {
        "contract_name": "chummer6-ui-kit.local_release_proof",
        "schema_version": 1,
        "generated_at": _iso_now() if not args.check else "CHECK_MODE_STABLE_TIMESTAMP",
        "status": status,
        "repo_root": str(repo_root),
        "evidence": {
            "m142_successor_package_id": M142_PACKAGE_ID,
            "m142_work_task_id": M142_WORK_TASK_ID,
            "m142_canonical_queue_frontier_id": M142_CANONICAL_QUEUE_FRONTIER_ID,
            "m142_task_local_handoff_frontier_id": M142_TASK_LOCAL_HANDOFF_FRONTIER_ID,
            "shared_surface_signoff_path": str(signoff_doc),
            "u7_u8_release_adoption_evidence_path": str(adoption_doc),
            "m121_live_action_economy_evidence_path": str(milestone_121_doc),
            "m121_source_anchor_paths": [str((repo_root / relative_path).resolve()) for relative_path in M121_SOURCE_MARKERS],
            "m121_snapshot_anchor_paths": [str((repo_root / relative_path).resolve()) for relative_path in M121_SNAPSHOT_PATHS],
            "m142_classic_dense_workbench_evidence_path": str(milestone_142_doc),
            "m142_source_anchor_paths": [str((repo_root / relative_path).resolve()) for relative_path in M142_SOURCE_MARKERS],
            "m142_snapshot_anchor_paths": [str((repo_root / relative_path).resolve()) for relative_path in M142_SNAPSHOT_PATHS],
            "m142_successor_queue_path": str(SUCCESSOR_QUEUE_PATH),
            "m142_successor_registry_path": str(SUCCESSOR_REGISTRY_PATH),
            "task_local_telemetry_runs_root": str(TASK_LOCAL_TELEMETRY_RUNS_ROOT),
            "task_local_telemetry_selector": TASK_LOCAL_TELEMETRY_SELECTOR,
            "runtime_handoff_path": str(RUNTIME_HANDOFF_PATH),
            "runtime_handoff_receipt_rule": build_runtime_handoff_rule(),
            "verify_script_path": str(verify_script),
            "worklist_path": str(worklist_path),
        },
        "reasons": reasons,
    }

    serialized = json.dumps(payload, indent=2, sort_keys=True) + "\n"

    if args.check:
        if not out_path.is_file():
            print(f"ui-kit local release proof missing: {out_path}")
            return 1
        existing = out_path.read_text(encoding="utf-8")
        # Ignore generated_at when verifying deterministic content.
        current_payload = json.loads(existing)
        expected_payload = json.loads(serialized)
        current_payload["generated_at"] = "<ignored>"
        expected_payload["generated_at"] = "<ignored>"
        current = json.dumps(current_payload, indent=2, sort_keys=True) + "\n"
        expected = json.dumps(expected_payload, indent=2, sort_keys=True) + "\n"
        if current != expected:
            print(f"ui-kit local release proof out of date: {out_path}")
            return 1
        print(f"ui-kit local release proof is up to date: {out_path}")
        return 0 if status == "passed" else 1

    out_path.parent.mkdir(parents=True, exist_ok=True)
    out_path.write_text(serialized, encoding="utf-8")
    print(f"wrote ui-kit local release proof: {out_path}")
    return 0 if status == "passed" else 1


if __name__ == "__main__":
    raise SystemExit(main())
