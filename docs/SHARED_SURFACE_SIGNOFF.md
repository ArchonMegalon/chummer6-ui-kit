# Shared Surface Signoff

Purpose: keep the `chummer6-ui-kit` share of `F0` explicit.

## Current release bar

`Chummer.Ui.Kit` is treated as release-ready for the active shared boundary when `scripts/ai/verify.sh` continues to prove all of the following:

- package build, pack, and deterministic test execution stay green
- shell chrome, banner, stale-state, approval, offline, and accessibility primitives remain package-owned
- both Blazor and Avalonia adapters keep deterministic payload shape for the shared primitives
- milestone `121` action-budget bars, condition/effect chips, source-anchor drawers, and Runboard cards remain package-owned with shared token and snapshot evidence
- milestone `142` classic dense-workbench preset remains package-owned, binds the direct flagship family ids, and keeps stale-chrome/noise-budget sentinels fail-closed across chrome heights, banner/badge clusters, card nesting, and center-pane dominance
- preview/gallery metadata stays package-owned instead of drifting into downstream repos

## Accessibility and localization posture

- Accessibility semantics are package-owned through deterministic adapter payloads for shell and status primitives.
- Localization safety remains package-owned by keeping UI-kit primitives UI-only and caller-text-driven; the package must not absorb domain copy, provider text, or hidden content authority.

## Performance posture

- Shared primitives remain payload-only and deterministic; they must not acquire HTTP clients, provider SDKs, storage seams, or orchestration logic.
- The release path requires normal `dotnet build`, `dotnet pack`, and test execution to stay fast-path green under `scripts/ai/verify.sh`.

## Exit statement

The shared boundary is release-ready for the active token/theme/shell/state contract, including the milestone `121` live action-economy and Runboard primitives plus the milestone `142` classic dense-workbench flagship preset. Future dense-data and catalog expansion remain additive package evolution, not a blocker on current cross-head hardening closure.
