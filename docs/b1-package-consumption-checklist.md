# B1 Package Consumption Checklist

This checklist closes the `ui-kit` side of the B1 queue item and provides executable proof requirements for `chummer6-ui` (presentation) and `chummer6-mobile` (play).

## Goal

Confirm presentation and play consume `Chummer.Ui.Kit` as a package-only dependency for B1 primitives and have removed local source copies.

## Required primitives (must come from package)

- `ShellChrome`
- `AccessibilityState`
- `BlazorUiKitAdapter.AdaptShellChrome`
- `BlazorUiKitAdapter.AdaptAccessibilityState`
- `AvaloniaUiKitAdapter.AdaptShellChrome`
- `AvaloniaUiKitAdapter.AdaptAccessibilityState`

## Repo execution checklist

1. Update project/package references to consume published `Chummer.Ui.Kit` package version.
2. Remove local/shared source copies of shell/accessibility primitives and adapter equivalents.
3. Run duplicate scan:
   - `rg -n "class .*Shell|class .*Accessibility|AdaptShellChrome|AdaptAccessibilityState" src`
4. Add CI guard to fail on reintroduced local copies:
   - `rg -n "class .*Shell|class .*Accessibility|AdaptShellChrome|AdaptAccessibilityState" src && exit 1 || exit 0`
5. Record migration evidence:
   - repo name
   - commit SHA
   - deleted/replaced path list
   - package version consumed
   - guard command location in CI

## Acceptance evidence

Current consuming-repo proof is executable instead of narrative-only:

| Repo | Package Version | Removed/Guarded Paths | Guard Location | Status |
| --- | --- | --- | --- | --- |
| `chummer6-ui` | `0.1.0-preview` | `Chummer.Presentation`, `Chummer.Blazor`, `Chummer.Avalonia`, `Chummer.Tests` are scanned for repo-local shared primitive drift | `chummer6-ui/scripts/ai/verify.sh` | `done` |
| `chummer6-mobile` | `0.1.0-preview` | `src/` is scanned for repo-local shared primitive drift while package references stay mandatory | `chummer6-mobile/scripts/ai/verify.sh` | `done` |

## Scope note

`chummer6-ui-kit` still does not own the downstream repos, but B1 closure now rests on their executable verify paths rather than a future manual evidence pass.
