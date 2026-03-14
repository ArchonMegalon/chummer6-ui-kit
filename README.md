# chummer6-ui-kit

Shared design system package for Chummer6.

This repo is a real boundary, not a trophy seed.

Current seed includes:

- token canon for UI-only design values
- theme compilation to CSS custom properties
- shell chrome, badges, banners, and accessibility primitives
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

Adapter entry points:

- Blazor: `AdaptShellChrome`, `AdaptBanner`, `AdaptStaleStateBadge`, `AdaptApprovalChip`, `AdaptOfflineBanner`, `AdaptAccessibilityState`
- Avalonia: `AdaptShellChrome`, `AdaptBanner`, `AdaptStaleStateBadge`, `AdaptApprovalChip`, `AdaptOfflineBanner`, `AdaptAccessibilityState`

Deterministic contract checks for all listed adapter methods run in `tests/Chummer.Ui.Kit.Tests/Program.cs` via `scripts/ai/verify.sh`.

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
- the proof is not finished until UI and mobile consume it without source-copied drift
