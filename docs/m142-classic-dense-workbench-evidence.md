# M142 Classic Dense Workbench Evidence

Purpose: keep the `chummer6-ui-kit` share of the M142 dense-workbench flagship closeout explicit and fail-closed.

Successor-wave closure receipt:

- Package id: `next90-m142-ui-kit-bind-dense-workbench-and-noise-budget-proof-for-these-families-into-t`
- Registry work-task id: `142.2`
- Canonical staged-queue frontier id: `1752713026`
- Task-local handoff frontier id: `1971223526`
- Task-local telemetry selector: `latest matching worker receipt under /var/lib/codex-fleet/chummer_design_supervisor/shard-2/runs/*/TASK_LOCAL_TELEMETRY.generated.json`
- Active runtime handoff receipt: `/var/lib/codex-fleet/chummer_design_supervisor/shard-2/ACTIVE_RUN_HANDOFF.generated.md`
- Runtime handoff closure rule: `ACTIVE_RUN_HANDOFF.generated.md must expose the current frontier id, run id, and prompt path for the latest matching worker receipt.`
- Worker-safe closure rule: future shards should verify this repo-local proof bundle, the generated release proof artifact, and canonical queue/registry mirrors instead of reopening the UI-kit dense-workbench slice when those anchors are still current.

## Release evidence anchors

- Package-owned preset: `classic_dense_workbench`
- Shared primitive: `ClassicDenseWorkbenchPreset`
- Adapter projections:
  - `BlazorUiKitAdapter.AdaptClassicDenseWorkbenchPreset`
  - `AvaloniaUiKitAdapter.AdaptClassicDenseWorkbenchPreset`
- Deterministic payload snapshots:
  - `tests/Chummer.Ui.Kit.Tests/Snapshots/blazor.classic-dense-workbench.snapshot`
  - `tests/Chummer.Ui.Kit.Tests/Snapshots/avalonia.classic-dense-workbench.snapshot`

## Dense-workbench proof binding

The preset itself carries the direct M142 family proof ids instead of leaving dense-workbench closure to broad family prose:

- `family:dense_builder_and_career_workflows`
- `family:dice_initiative_and_table_utilities`
- `family:identity_contacts_lifestyles_history`

The flagship default is token-backed rather than a second hand-maintained literal bundle: `ClassicDenseWorkbenchPreset.CreateFlagshipDesktopDefault()` and the private `TokenCanon` constructor map the package-owned workbench and noise-budget tokens directly into the preset payload before the Blazor or Avalonia adapters materialize desktop proof.

The package contract also pins the design-owned dense budget version so downstream desktop proof can cite one exact preset payload instead of restating the posture in app-local prose.

## Fail-closed stale chrome sentinels

The preset contract must keep all of these stale chrome guards at or below the package-owned ceiling:

- hero-banner max height: `0`
- dashboard-tile max count in the toolstrip: `0`
- decorative landing chrome max count in the workbench: `0`
- menu height max: `32`
- toolstrip height max: `40`
- menu/toolstrip combined height max: `72`
- status-strip height max: `26`
- persistent banner count max: `1`
- persistent secondary badge-cluster max: `3`
- card-nesting depth max: `2`
- center-pane dominance: `true`

If any of those fields drift, the deterministic snapshots and shared test assertions in `tests/Chummer.Ui.Kit.Tests/Program.cs` must fail before downstream desktop proof is republished. `scripts/ai/verify.sh` and `scripts/ai/materialize_ui_kit_release_proof.py` also fail closed when the M142 source anchors or dense-workbench snapshots disappear, so closure cannot rest on prose markers alone.

The package constructor also fails closed if a caller supplies custom proof-family or chrome-sentinel lists that omit canonical M142 entries, broaden the proof-family set beyond the approved three families, or leave chrome sentinel text stale after changing the live preset budget fields.

## Noise-budget floor

`scripts/ai/verify.sh` is expected to keep the preset within the current noise-budget ceiling for:

- compact spacing scale
- compact header scale
- row spacing max
- card padding max
- input padding horizontal/vertical max
- banner height ceiling
- badge density ceiling
- persistent banner count max
- persistent secondary badge-cluster max
- compact field height
- compact button height
- compact button min-height max
- compact icon-button size max
- workspace-context strip requirement
- left-navigation and right-inspector width bounds
- tab-strip height max
- dense list-row height max
- header-to-content ratio max

## Avalonia flagship default

Avalonia projections expose the `FlagshipDesktopDefault` class marker so the promoted desktop route can consume `classic_dense_workbench` as the default flagship posture unless an explicit override is approved.

## Successor closure receipt

System re-entry evidence update (2026-05-06, M142 successor closure pass):

- Re-verified the repo-local M142 anchors against registry work-task `142.2`, the staged queue row for frontier `1752713026`, and the task-local handoff that selected this slice under frontier `1971223526`.
- Tightened worker-safe closure so `scripts/ai/verify.sh` and `.codex-studio/published/UI_KIT_LOCAL_RELEASE_PROOF.generated.json` must match the latest M142 worker receipt selected under `/var/lib/codex-fleet/chummer_design_supervisor/shard-2/runs` plus the frontier, run-id, and prompt-path markers actually emitted by `ACTIVE_RUN_HANDOFF.generated.md` instead of relying on copied frontier ids in prose alone.
- Replaced the per-run task-local telemetry citation with the stable selector and runtime-handoff closure rule so future shards verify the latest matching worker receipt dynamically instead of churning tracked evidence on every new run id.
- Confirmed the package-owned proof stays bound to `classic_dense_workbench`, the three direct family ids, and the stale-chrome/noise-budget sentinels in `TokenCanon`, `ClassicDenseWorkbenchPreset`, and both adapter payloads.
- Confirmed the flagship default constructor path now rehydrates the preset from `TokenCanon` so stale chrome or noise-budget drift fails in package tests before downstream desktop proof can close the slice.
- Tightened `ClassicDenseWorkbenchPreset` so proof-family lists must stay exactly canonical and chrome-regression sentinels are validated against the live preset field values instead of stale copied strings.
- Tightened the repo verifier and materialized proof floor so closure now also fails if `FlagshipClassicDenseWorkbenchDefaultIsTokenBacked`, `classic dense-workbench stale chrome sentinel list fails closed`, or `classic dense-workbench non-canonical proof family broadening fails closed` disappear from the executable package tests.
- Tightened `scripts/ai/verify.sh` and `scripts/ai/materialize_ui_kit_release_proof.py` so the local closure proof also fails when the canonical successor queue row or registry work-task row for this package drift away from the recorded `M142` contract.
- Re-ran `bash scripts/ai/verify.sh`, `python3 scripts/ai/materialize_ui_kit_release_proof.py --check`, and `dotnet run --project tests/Chummer.Ui.Kit.Tests/Chummer.Ui.Kit.Tests.csproj`; all passed on 2026-05-06 after refreshing the receipt-bound proof markers.
- Closure remains worker-safe through this repo-local receipt, `docs/SHARED_SURFACE_SIGNOFF.md`, and `.codex-studio/published/UI_KIT_LOCAL_RELEASE_PROOF.generated.json`; future shards should verify those anchors instead of reopening the UI-kit slice unless the package evidence changes.
