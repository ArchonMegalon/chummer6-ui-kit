#!/usr/bin/env bash
set -euo pipefail
repo_root="$(cd "$(dirname "${BASH_SOURCE[0]}")/../.." && pwd)"
dotnet_home="/tmp/chummer-ui-kit-dotnet"

mkdir -p "$dotnet_home"

export DOTNET_CLI_HOME="$dotnet_home"
export HOME="$dotnet_home"
export NUGET_PACKAGES="$dotnet_home/.nuget/packages"
export DOTNET_SKIP_FIRST_TIME_EXPERIENCE=1
export DOTNET_CLI_TELEMETRY_OPTOUT=1

task_local_telemetry_path="$(
python3 - <<'PY'
from pathlib import Path

runs_root = Path("/var/lib/codex-fleet/chummer_design_supervisor/shard-2/runs")
markers = (
    "next90-m142-ui-kit-bind-dense-workbench-and-noise-budget-proof-for-these-families-into-t",
    "1971223526",
    '"milestone_id": 142',
    '"repo": "chummer6-ui-kit"',
    '"title": "Bind dense-workbench and noise-budget proof for these families into the flagship preset and fail-close on stale chrome regressions."',
)

for candidate in sorted(runs_root.glob("*/TASK_LOCAL_TELEMETRY.generated.json"), key=lambda path: path.parent.name, reverse=True):
    try:
        text = candidate.read_text(encoding="utf-8")
    except OSError:
        continue
    if all(marker in text for marker in markers):
        print(candidate)
        raise SystemExit(0)

raise SystemExit(1)
PY
)"
task_local_run_id="$(basename "$(dirname "$task_local_telemetry_path")")"
task_local_telemetry_selector='latest matching worker receipt under /var/lib/codex-fleet/chummer_design_supervisor/shard-2/runs/*/TASK_LOCAL_TELEMETRY.generated.json'
runtime_handoff_rule='ACTIVE_RUN_HANDOFF.generated.md must expose the current frontier id, run id, and prompt path for the latest matching worker receipt.'

test -f "$repo_root/docs/SHARED_SURFACE_SIGNOFF.md"
rg -n 'scripts/ai/verify\.sh|Blazor|Avalonia|accessibility|localization|performance|dotnet pack' \
  "$repo_root/docs/SHARED_SURFACE_SIGNOFF.md" >/dev/null
test -f "$repo_root/docs/m121-live-action-economy-evidence.md"
rg -n 'ActionBudgetBar|ConditionEffectChip|SourceAnchorDrawer|RunboardCard|action_budget_bars|condition_effect_chips|source_anchor_drawers|runboard_primitives' \
  "$repo_root/docs/m121-live-action-economy-evidence.md" >/dev/null
rg -n 'public sealed class ActionBudgetBar|public sealed class ConditionEffectChip|public sealed class SourceAnchorDrawer|public sealed class RunboardCard' \
  "$repo_root/src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs" >/dev/null
rg -n 'AdaptActionBudgetBar|AdaptConditionEffectChip|AdaptSourceAnchorDrawer|AdaptRunboardCard' \
  "$repo_root/src/Chummer.Ui.Kit/Adapters/Blazor/BlazorUiKitAdapter.cs" \
  "$repo_root/src/Chummer.Ui.Kit/Adapters/Avalonia/AvaloniaUiKitAdapter.cs" >/dev/null
rg -n 'action_budget_bars|condition_effect_chips|source_anchor_drawers|runboard_primitives' \
  "$repo_root/src/Chummer.Ui.Kit/Preview/PreviewGalleryManifest.cs" >/dev/null
rg -n 'action\.budget\.bar\.root\.class|condition\.effect\.chip\.root\.class|source\.anchor\.drawer\.root\.class|runboard\.card\.root\.class' \
  "$repo_root/src/Chummer.Ui.Kit/Tokens/TokenCanon.cs" >/dev/null
rg -n 'DefaultCanonContainsRunboardAndSourceAnchorTokens|ActionBudgetBar|ConditionEffectChip|SourceAnchorDrawer|RunboardCard' \
  "$repo_root/tests/Chummer.Ui.Kit.Tests/Program.cs" >/dev/null
test -f "$repo_root/tests/Chummer.Ui.Kit.Tests/Snapshots/blazor.action-budget-bar.snapshot"
test -f "$repo_root/tests/Chummer.Ui.Kit.Tests/Snapshots/blazor.condition-effect-chip.snapshot"
test -f "$repo_root/tests/Chummer.Ui.Kit.Tests/Snapshots/blazor.source-anchor-drawer.snapshot"
test -f "$repo_root/tests/Chummer.Ui.Kit.Tests/Snapshots/blazor.runboard-card.snapshot"
test -f "$repo_root/tests/Chummer.Ui.Kit.Tests/Snapshots/avalonia.action-budget-bar.snapshot"
test -f "$repo_root/tests/Chummer.Ui.Kit.Tests/Snapshots/avalonia.condition-effect-chip.snapshot"
test -f "$repo_root/tests/Chummer.Ui.Kit.Tests/Snapshots/avalonia.source-anchor-drawer.snapshot"
test -f "$repo_root/tests/Chummer.Ui.Kit.Tests/Snapshots/avalonia.runboard-card.snapshot"
test -f "$repo_root/docs/m142-classic-dense-workbench-evidence.md"
rg -n 'classic_dense_workbench|M142|family:dense_builder_and_career_workflows|family:dice_initiative_and_table_utilities|family:identity_contacts_lifestyles_history|hero-banner max height|dashboard-tile max count|decorative landing chrome max count|FlagshipDesktopDefault|stale chrome' \
  "$repo_root/docs/m142-classic-dense-workbench-evidence.md" >/dev/null
rg -n 'next90-m142-ui-kit-bind-dense-workbench-and-noise-budget-proof-for-these-families-into-t|142\.2|1752713026|1971223526|Worker-safe closure rule' \
  "$repo_root/docs/m142-classic-dense-workbench-evidence.md" >/dev/null
rg -n "next90-m142-ui-kit-bind-dense-workbench-and-noise-budget-proof-for-these-families-into-t|work_task_id: '142\\.2'|1752713026|milestone_id: 142|wave: W22P|repo: chummer6-ui-kit|bind_dense_workbench_and_noise_budget_proof_for_these_fa:ui_kit" \
  /docker/fleet/.codex-studio/published/NEXT_90_DAY_QUEUE_STAGING.generated.yaml >/dev/null
rg -n "    - id: '142\\.2'|      owner: chummer6-ui-kit|      title: Bind dense-workbench and noise-budget proof for these families into the flagship preset and fail-close on stale chrome regressions\." \
  /docker/chummercomplete/chummer-design/products/chummer/NEXT_90_DAY_PRODUCT_ADVANCE_REGISTRY.yaml >/dev/null
rg -n 'next90-m142-ui-kit-bind-dense-workbench-and-noise-budget-proof-for-these-families-into-t|1971223526|"milestone_id": 142|"repo": "chummer6-ui-kit"|Bind dense-workbench and noise-budget proof for these families into the flagship preset and fail-close on stale chrome regressions\.' \
  "$task_local_telemetry_path" >/dev/null
rg -F "$task_local_telemetry_selector" \
  "$repo_root/docs/m142-classic-dense-workbench-evidence.md" \
  "$repo_root/.codex-studio/published/UI_KIT_LOCAL_RELEASE_PROOF.generated.json" >/dev/null
rg -F "$runtime_handoff_rule" \
  "$repo_root/docs/m142-classic-dense-workbench-evidence.md" \
  "$repo_root/.codex-studio/published/UI_KIT_LOCAL_RELEASE_PROOF.generated.json" >/dev/null
rg -n "Frontier ids: 1971223526|Run id: ${task_local_run_id}|Prompt path: /var/lib/codex-fleet/chummer_design_supervisor/shard-2/runs/${task_local_run_id}/prompt.txt" \
  /var/lib/codex-fleet/chummer_design_supervisor/shard-2/ACTIVE_RUN_HANDOFF.generated.md >/dev/null
rg -n 'menu height max|toolstrip height max|persistent banner count max|persistent secondary badge-cluster max|card-nesting depth max|row spacing max|input padding horizontal/vertical max|left-navigation and right-inspector width bounds|header-to-content ratio max' \
  "$repo_root/docs/m142-classic-dense-workbench-evidence.md" >/dev/null
rg -n 'public sealed class ClassicDenseWorkbenchPreset|CreateFlagshipDesktopDefault|private ClassicDenseWorkbenchPreset\(TokenCanon tokenCanon\)|RequiredProofFamilyIds|BuildExpectedChromeRegressionSentinels|NormalizeExactContractIdList' \
  "$repo_root/src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs" >/dev/null
rg -n 'AdaptClassicDenseWorkbenchPreset|data-proof-family-ids|data-chrome-regression-sentinels|data-flagship-default-avalonia|proof-family-ids|chrome-regression-sentinels|flagship-default-avalonia' \
  "$repo_root/src/Chummer.Ui.Kit/Adapters/Blazor/BlazorUiKitAdapter.cs" \
  "$repo_root/src/Chummer.Ui.Kit/Adapters/Avalonia/AvaloniaUiKitAdapter.cs" >/dev/null
rg -n 'classic_dense_workbench' \
  "$repo_root/src/Chummer.Ui.Kit/Preview/PreviewGalleryManifest.cs" >/dev/null
rg -n 'classic\.dense\.workbench\.preset\.id|classic\.dense\.workbench\.proof\.family\.ids|classic\.dense\.workbench\.chrome\.regression\.sentinels|noise\.budget\.decorative\.landing\.chrome\.max|workbench\.visible\.dense\.list\.row\.min|workbench\.visible\.dense\.detail\.group\.field\.min' \
  "$repo_root/src/Chummer.Ui.Kit/Tokens/TokenCanon.cs" >/dev/null
rg -n 'DefaultCanonContainsClassicDenseWorkbenchTokens|FlagshipClassicDenseWorkbenchDefaultIsTokenBacked|classic dense-workbench missing required proof family ids fails closed|classic dense-workbench missing required chrome sentinel fails closed|classic dense-workbench stale chrome sentinel list fails closed|classic dense-workbench non-canonical proof family broadening fails closed|blazor classic dense-workbench payload|avalonia classic dense-workbench payload|FlagshipDesktopDefault' \
  "$repo_root/tests/Chummer.Ui.Kit.Tests/Program.cs" >/dev/null
test -f "$repo_root/tests/Chummer.Ui.Kit.Tests/Snapshots/blazor.classic-dense-workbench.snapshot"
test -f "$repo_root/tests/Chummer.Ui.Kit.Tests/Snapshots/avalonia.classic-dense-workbench.snapshot"
rg -n '84c56492|306f5bf3|f134092|6b57e12|0\.1\.0-preview|chummer6-ui|chummer6-mobile|drift status: `none`' \
  "$repo_root/docs/u7-u8-release-adoption-evidence.md" >/dev/null
test -f "$repo_root/docs/onboarding-action-adoption-evidence.md"
rg -n 'chummer6-ui|chummer6-mobile|GuidanceState|LongRunningActionControls|AdaptGuidanceState|AdaptLongRunningActionControls' \
  "$repo_root/docs/onboarding-action-adoption-evidence.md" >/dev/null
rg -n '\[x\] `presentation` \+ `play`: Consume published package version and record deletion of source-copied UI primitives that the release replaces\.' \
  "$repo_root/WORKLIST.md" >/dev/null
rg -n '\[x\] `presentation` \+ `play`: Add/keep guard checks preventing reintroduction of repo-local copies for catalog-covered primitives\.' \
  "$repo_root/WORKLIST.md" >/dev/null
rg -n '\[x\] `ui-kit`: Add adoption and CI guard checks for new onboarding/action primitives in `chummer6-ui` and `chummer6-mobile` to prevent source-copy reintroduction\.' \
  "$repo_root/WORKLIST.md" >/dev/null
rg -n '\[x\] Bound the M142 flagship families directly into the preset contract' \
  "$repo_root/WORKLIST.md" >/dev/null
rg -n '\[x\] Expanded the preset contract to carry split chrome-height, width-bound, banner/badge-cluster, card-nesting, and row-spacing budget fields directly in UI Kit' \
  "$repo_root/WORKLIST.md" >/dev/null
rg -n 'System re-entry evidence update \(2026-05-06, M142 successor closure pass\):|next90-m142-ui-kit-bind-dense-workbench-and-noise-budget-proof-for-these-families-into-t|1752713026|1971223526' \
  "$repo_root/WORKLIST.md" >/dev/null

dotnet build "$repo_root/src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj" --nologo
dotnet build "$repo_root/tests/Chummer.Ui.Kit.Tests/Chummer.Ui.Kit.Tests.csproj" --nologo
dotnet pack "$repo_root/src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj" -c Release --nologo
dotnet run --project "$repo_root/tests/Chummer.Ui.Kit.Tests/Chummer.Ui.Kit.Tests.csproj" --no-build --nologo
python3 -m unittest "$repo_root/tests/test_materialize_ui_kit_release_proof.py"
python3 "$repo_root/scripts/ai/materialize_ui_kit_release_proof.py" \
  --repo-root "$repo_root" \
  --check \
  --out "$repo_root/.codex-studio/published/UI_KIT_LOCAL_RELEASE_PROOF.generated.json"
