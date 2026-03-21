# GitHub Codex Review

PR: https://github.com/ArchonMegalon/chummer6-ui-kit/pull/3

Findings:
- [high] src/Chummer.Ui.Kit/Adapters/Avalonia/AvaloniaUiKitAdapter.cs [contracts] avalonia-rootclass-contract-break
Compared to `main`, `AdaptShellChrome` changed payload root class from `ShellRoot` to `chummer-shell` and `AdaptAccessibilityState` changed from `AccessibilityState` to `chummer-accessibility`.; The updated tests now enforce the new root classes, but only add legacy aliases in `attributes["classes"]`; consumers binding to `UiAdapterPayload.RootClass` (templates/selectors) will still break.; This is a payload contract drift with likely downstream UI/rendering impact and no explicit compatibility migration evidence in this repo.
Expected fix: Restore legacy Avalonia `RootClass` values for compatibility, or provide an explicit non-breaking bridge plus documented/versioned migration (and tests proving both legacy and new selector paths remain valid).
