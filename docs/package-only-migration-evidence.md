# Package-Only Migration Evidence

Use this template to close:

`Migrate presentation and play to consume Chummer.Ui.Kit as a package-only dependency and delete duplicate local token/theme/component copies.`

## Required evidence per downstream repo

1. Package reference proof
- Repo:
- `Chummer.Ui.Kit` version:
- Commit SHA:

2. Duplicate-removal proof
- Deleted/replaced local token paths:
- Deleted/replaced local theme paths:
- Deleted/replaced local shared component paths:
- Commit SHA(s):

3. Guard proof
- CI job/check name:
- Guard command(s):
- Commit/path for guard wiring:

4. Verification proof
- Verify/build command(s) run:
- Link/reference to passing run:

## Submission block

```md
### Package-only migration evidence
- Repo: <repo>
- Date (UTC): <yyyy-mm-dd>
- Package version: <x.y.z>
- Package update commit: <sha>
- Local token copies removed:
  - <path>
- Local theme copies removed:
  - <path>
- Local shared component copies removed:
  - <path>
- Guard check: <command + ci path>
- Guard wiring commit: <sha>
- Verification commands: <command list>
- Passing run reference: <link or run id>
```

## Closure gate

The slice is complete only when both `chummer6-ui` and `chummer6-mobile` submit populated evidence blocks and link them from `WORKLIST.md`.

### Package-only migration evidence
- Repo: `chummer6-ui` (`/docker/chummercomplete/chummer6-ui`)
- Date (UTC): `2026-03-21`
- Package version: `0.1.0-preview`
- Package update commit: `84c56492` (`Chummer.Presentation/Chummer.Presentation.csproj`, `Directory.Build.props`)
- Local token copies removed:
  - No local token-copy classes detected in guarded roots: `Chummer.Presentation`, `Chummer.Blazor`, `Chummer.Avalonia`, `Chummer.Tests` (enforced by verify guard).
- Local theme copies removed:
  - No local theme-copy classes detected in guarded roots: `Chummer.Presentation`, `Chummer.Blazor`, `Chummer.Avalonia`, `Chummer.Tests` (enforced by verify guard).
- Local shared component copies removed:
  - No local shared shell/accessibility primitive copies detected in guarded roots: `Chummer.Presentation`, `Chummer.Blazor`, `Chummer.Avalonia`, `Chummer.Tests` (enforced by verify guard).
- Guard check: `rg -n '\b(class|record)\s+(TokenCanon|ThemeCompiler|ShellChrome|AccessibilityState|Banner|StaleStateBadge|ApprovalChip|OfflineBanner)\b|\b(static\s+)?UiAdapterPayload\s+Adapt(ShellChrome|AccessibilityState|Banner|StaleStateBadge|ApprovalChip|OfflineBanner)\s*\(' Chummer.Presentation Chummer.Blazor Chummer.Avalonia Chummer.Tests -g '*.cs'` (fail when matched) in `scripts/ai/verify.sh`
- Guard wiring commit: `6d435cbd`
- Verification commands: `scripts/ai/verify.sh`
- Passing run reference: local run on `2026-03-21` (exit 0, `[verify] PASS`)

### Package-only migration evidence
- Repo: `chummer6-mobile` (`/docker/chummercomplete/chummer6-mobile`)
- Date (UTC): `2026-03-21`
- Package version: `0.1.0-preview`
- Package update commit: `f134092` (`Directory.Build.props`, `Directory.Packages.props`, `src/Chummer.Play.Components/Chummer.Play.Components.csproj`)
- Local token copies removed:
  - No local token-copy classes detected in guarded root `src/` (enforced by verify guard).
- Local theme copies removed:
  - No local theme-copy classes detected in guarded root `src/` (enforced by verify guard).
- Local shared component copies removed:
  - No local shared shell/accessibility primitive copies detected in guarded root `src/` (enforced by verify guard).
- Guard check: `rg -n '\\b(class|record)\\s+(TokenCanon|ThemeCompiler|ShellChrome|AccessibilityState|Banner|StaleStateBadge|ApprovalChip|OfflineBanner)\\b|\\b(static\\s+)?UiAdapterPayload\\s+Adapt(ShellChrome|AccessibilityState|Banner|StaleStateBadge|ApprovalChip|OfflineBanner)\\s*\\(' src -g '*.cs'` (fail when matched) in `scripts/ai/verify.sh`
- Guard wiring commit: `a6bd75c`
- Verification commands: `scripts/ai/verify.sh`
- Passing run reference: local run on `2026-03-21` (exit 0, `chummer6-mobile verify ok`)
