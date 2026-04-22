# chummer6-ui-kit

Shared design system package for Chummer6.

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

This package-owned boundary exists so `chummer6-ui` and `chummer6-mobile` can consume the same shared chrome and accessibility primitives without source-copying UI classes.

Canonical token keys currently required by the B1 shell/accessibility surface:

- `color.background.canvas`
- `color.background.panel`
- `color.border.subtle`
- `color.text.primary`
- `color.text.muted`
- `color.accent.primary`
- `space.100`
- `space.200`
- `space.400`
- `radius.sm`
- `radius.md`
- `font.family.base`
- `font.size.body`
- `font.size.title`

Adapter payload guarantees for this slice:

- `ShellChrome`, `Banner`, `StaleStateBadge`, `ApprovalChip`, `OfflineBanner`, and `AccessibilityState` remain UI-only primitives with no domain DTO or service dependencies.
- Blazor payload keys stay deterministic across runs: `role`, `aria-*`, `data-*`, and `class`.
- Avalonia payload keys stay deterministic across runs: `part`, `classes`, semantic text fields, and explicit state booleans.
- Accessibility payloads keep shared busy/live/disabled semantics in both adapter families.
- Any additive or breaking payload-key change must follow the release-discipline gates below.

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
