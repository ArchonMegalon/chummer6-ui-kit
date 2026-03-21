# Package-Only Consumption Checklist (Presentation + Play)

This checklist closes the `ui-kit` side of the package-only migration slice and provides executable proof requirements for `chummer6-ui` (presentation) and `chummer6-mobile` (play).

## Goal

Confirm presentation and play consume `Chummer.Ui.Kit` as a package-only dependency for shared tokens, themes, and components, and have removed local source copies.

## Required shared surfaces (must come from package)

- Token canon via `TokenCanon` (no repo-local duplicated token classes/files).
- Theme compilation via `ThemeDefinition` + `ThemeCompiler` (no repo-local duplicated theme compiler/definition classes/files).
- Shared components/primitives exposed by ui-kit adapters and records (for example `ShellChrome`, `Banner`, `StaleStateBadge`, `ApprovalChip`, `OfflineBanner`, `AccessibilityState`, dense-data and explain/card primitives).

## Repo execution checklist

1. Update project/package references to consume published `Chummer.Ui.Kit` package version.
2. Remove local/shared source copies of token/theme/component equivalents.
3. Run duplicate scans:
   - Token/theme duplicates:
     - `rg -n "class .*Token|class .*Theme|TokenCanon|ThemeCompiler|ThemeDefinition" src`
   - Component/adapter duplicates:
     - `rg -n "class .*Shell|class .*Accessibility|class .*Banner|class .*Badge|class .*Chip|class .*Dense|class .*Card|AdaptShellChrome|AdaptAccessibilityState|AdaptBanner|AdaptStaleStateBadge|AdaptApprovalChip|AdaptOfflineBanner|AdaptDense|AdaptExplain|AdaptSpider|AdaptArtifact" src`
4. Add CI guards to fail on reintroduced local copies:
   - `rg -n "class .*Token|class .*Theme|TokenCanon|ThemeCompiler|ThemeDefinition" src && exit 1 || exit 0`
   - `rg -n "class .*Shell|class .*Accessibility|class .*Banner|class .*Badge|class .*Chip|class .*Dense|class .*Card|AdaptShellChrome|AdaptAccessibilityState|AdaptBanner|AdaptStaleStateBadge|AdaptApprovalChip|AdaptOfflineBanner|AdaptDense|AdaptExplain|AdaptSpider|AdaptArtifact" src && exit 1 || exit 0`
5. Record migration evidence:
   - repo name
   - commit SHA
   - deleted/replaced path list
   - package version consumed
   - guard command location in CI

## Acceptance evidence

Current consuming-repo proof for the B1 subset is executable instead of narrative-only:

| Repo | Package Version | Removed/Guarded Paths | Guard Location | Status |
| --- | --- | --- | --- | --- |
| `chummer6-ui` | `0.1.0-preview` | `Chummer.Presentation`, `Chummer.Blazor`, `Chummer.Avalonia`, `Chummer.Tests` are scanned for repo-local shared primitive drift | `chummer6-ui/scripts/ai/verify.sh` | `done` |
| `chummer6-mobile` | `0.1.0-preview` | `src/` is scanned for repo-local shared primitive drift while package references stay mandatory | `chummer6-mobile/scripts/ai/verify.sh` | `done` |

Token/theme/component-wide migration evidence for the broader slice should be added in `docs/package-only-migration-evidence.md`.

## Scope note

`chummer6-ui-kit` still does not own the downstream repos, but package-only migration closure now rests on executable verify paths and explicit evidence blocks rather than narrative-only claims.
