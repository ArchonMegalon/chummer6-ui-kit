# Milestone 121 UI Kit Evidence

Purpose: prove the `add_action_budget_bars_condition:ui_kit` package slice is package-owned and release-verifiable for milestone `121`.

## Shared primitives

- `ActionBudgetBar` models major/minor/reaction/edge action budgets with deterministic overdraw posture for desktop and mobile consumers.
- `ConditionEffectChip` models localized condition, effect, modifier, and warning chips with source-anchor-aware summary posture.
- `SourceAnchorDrawer` models sourcebook-backed follow-up drawers with excerpt, anchor, and conflict-warning payloads.
- `RunboardCard` models initiative, objective, opposition, heat, and resolution cards for GM Runboard consumers.

## Package-owned evidence

- Token canon owns the shared root classes and default posture for `action_budget_bars`, `condition_effect_chips`, `source_anchor_drawers`, and `runboard_primitives`.
- Preview gallery manifest lists `action_budget_bars`, `condition_effect_chips`, `source_anchor_drawers`, and `runboard_primitives` as package catalog entries.
- Blazor and Avalonia adapters expose deterministic payload snapshots for `ActionBudgetBar`, `ConditionEffectChip`, `SourceAnchorDrawer`, and `RunboardCard`.
- Constructor guard coverage in `tests/Chummer.Ui.Kit.Tests/Program.cs` fail-closes invalid counts and malformed source-anchor identifiers before downstream desktop or mobile consumers can project drifted payloads.
- Snapshot proofs live under `tests/Chummer.Ui.Kit.Tests/Snapshots/` and are exercised by `tests/Chummer.Ui.Kit.Tests/Program.cs`.

## Verification lane

- `scripts/ai/verify.sh` requires this evidence doc, package build/pack success, deterministic adapter tests, and current `UI_KIT_LOCAL_RELEASE_PROOF.generated.json`.
- `scripts/ai/materialize_ui_kit_release_proof.py` publishes this milestone evidence path into the generated local release proof artifact.
