# chummer6-ui-kit

Shared design system package for Chummer6.

This repo is a real boundary, not a trophy seed.

Current seed includes:

- token canon for UI-only design values
- theme compilation to CSS custom properties
- shell chrome, badges, banners, and accessibility primitives
- role-transition, progress-toast, and resume-affordance patterns for accessibility-first long-running flows
- guidance-state patterns for onboarding, error, empty, recovery, and first-run flows
- preview/gallery metadata kept inside `Chummer.Ui.Kit`

Excluded by design:

- domain DTOs
- HTTP clients
- rules math

## B1 Token + Shell Chrome + Accessibility Contract

Canonical B1 token keys in `TokenCanon.CreateDefault()`:

- `shell.chrome.root.class`
- `shell.chrome.role`
- `shell.chrome.default.tone`
- `shell.chrome.default.compact`
- `accessibility.state.root.class`
- `accessibility.state.role`
- `accessibility.state.live.default`
- `accessibility.state.busy.default`
- `accessibility.state.disabled.default`

Adapter payload guarantees:

- `BlazorUiKitAdapter.AdaptShellChrome` and `AvaloniaUiKitAdapter.AdaptShellChrome` emit deterministic shell payload keys and values (`role`/`aria-*`/`data-*` for Blazor; `part`/`classes`/`title`/`body` for Avalonia).
- `BlazorUiKitAdapter.AdaptAccessibilityState` and `AvaloniaUiKitAdapter.AdaptAccessibilityState` emit deterministic accessibility payload keys and values for `busy`, `disabled`, and live-region semantics.
- B1 primitives remain UI-only and package-only: no domain DTOs, HTTP clients, storage logic, rules math, or service orchestration.

## Adapter Contract: Shell + State Primitives

Shared primitives are defined in `Adapters/UiKitAdapterPrimitives.cs` and projected through both adapters:

- `ShellChrome`
- `Banner`
- `StaleStateBadge`
- `ApprovalChip`
- `OfflineBanner`
- `AccessibilityState`
- `RoleTransition`
- `ProgressToast`
- `ResumeAffordance`

Adapter entry points:

- Blazor: `AdaptShellChrome`, `AdaptBanner`, `AdaptStaleStateBadge`, `AdaptApprovalChip`, `AdaptOfflineBanner`, `AdaptAccessibilityState`
- Avalonia: `AdaptShellChrome`, `AdaptBanner`, `AdaptStaleStateBadge`, `AdaptApprovalChip`, `AdaptOfflineBanner`, `AdaptAccessibilityState`
- Blazor long-running/accessibility patterns: `AdaptRoleTransition`, `AdaptProgressToast`, `AdaptResumeAffordance`
- Avalonia long-running/accessibility patterns: `AdaptRoleTransition`, `AdaptProgressToast`, `AdaptResumeAffordance`
- Blazor classic dense workbench preset: `AdaptClassicDenseWorkbenchPreset`
- Avalonia classic dense workbench preset: `AdaptClassicDenseWorkbenchPreset` (default flagship desktop posture marker)

Deterministic contract checks for all listed adapter methods run in `tests/Chummer.Ui.Kit.Tests/Program.cs` via `scripts/ai/verify.sh`.

## Classic Dense Workbench Preset

`TokenCanon.CreateDefault()` now includes the package-owned `classic_dense_workbench` preset, its design-owned budget version, and dense noise-budget tokens for:

- compact spacing scale
- compact header scale
- row-spacing max
- card-padding max
- input-padding horizontal/vertical max
- banner-height ceiling
- badge-density ceiling
- persistent-banner max count
- persistent secondary badge-cluster max
- compact field height
- compact button height
- compact button min-height max
- compact icon-button size max
- hero-banner max height
- card-nesting depth max
- dashboard-tile max count in the toolstrip
- decorative landing chrome max count in the workbench
- menu-height max
- toolstrip-height max
- menu/toolstrip combined height max
- workspace-context strip required
- dense tab-strip height max
- left-navigation and right-inspector width bounds
- status-strip height max
- header-to-content ratio max
- dense list-row height max
- dense-list and detail-group minimum visible density
- builder-route minimum visible rows at `1440x900` and `1366x768`

The preset contract captures top menu bar, toolstrip, workspace-context strip, dense tab strip, compact list/detail panes, compact inspector forms, permanent status-strip posture, explicit center-pane dominance, the M142 family bindings for dense builder/career, dice/initiative, and identity/contacts/lifestyles/history, and fail-closed stale-chrome sentinels that keep hero banners, dashboard tiles, decorative landing chrome, inflated chrome heights, persistent badge clusters, and nested-card drift out of the promoted workbench. Avalonia projections include a `FlagshipDesktopDefault` class marker so flagship desktop consumers can treat this preset as the default posture unless explicitly overridden.

Release-proof evidence for that preset is explicit in `docs/m142-classic-dense-workbench-evidence.md`, and `scripts/ai/verify.sh` now fails if the M142 family bindings or stale-chrome sentinel documentation drifts out of the repo-local release proof.

## Release Discipline Gates (U8)

Do not cut or tag a `Chummer.Ui.Kit` release unless all gates pass.

1. `SemVer` gate:
   - `MAJOR`: breaking token key, adapter payload key, or preview manifest contract change.
   - `MINOR`: additive token, primitive, preview, or adapter payload field.
   - `PATCH`: docs/build/test/internal-only fixes with no public contract change.
2. Changelog gate:
   - Update release notes with contract-impact summary (tokens/adapters/previews changed or explicitly unchanged).
3. Packaging gate:
   - `dotnet pack src/Chummer.Ui.Kit/Chummer.Ui.Kit.csproj -c Release --nologo`
4. Verify gate:
   - `scripts/ai/verify.sh`
5. Downstream adoption evidence gate:
   - Include proof for both `chummer6-ui` and `chummer6-mobile` before release closure.

## Current maturity note

- the boundary is clear
- the contract is usable
- UI and mobile now prove package-only shell/state consumption through repo-local verification guards
- release signoff for the active shared boundary is explicit in `docs/SHARED_SURFACE_SIGNOFF.md`
