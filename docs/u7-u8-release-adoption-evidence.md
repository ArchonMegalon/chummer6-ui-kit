# U7/U8 Adoption Evidence Template

Use this template when closing the shared UI-kit `U7`/`U8` queue slice in downstream repos (`chummer6-ui` and `chummer6-mobile`).

## Required evidence fields

- Repo: `chummer6-ui` or `chummer6-mobile`
- Date (UTC): `YYYY-MM-DD`
- Ui-kit package version consumed: `Chummer.Ui.Kit x.y.z`
- Commit proving package update: `<sha>`
- Commit proving local source-copy deletion for catalog-covered primitives: `<sha>`
- Guard check proof: command + commit/path showing guard in CI (`rg`-style or equivalent)
- Catalog adoption proof: path list showing package-consumed catalog usage and no repo-local preview fork for the covered primitives
- U7 baseline stability proof:
  - Latest `scripts/ai/verify.sh` run in `chummer-ui-kit` is green for this release candidate
  - No adapter payload-key or preview-manifest drift since that baseline

## Submission block

Copy and fill this block per downstream repo:

```md
### U7/U8 downstream adoption evidence
- Repo: <repo-name>
- Date (UTC): <yyyy-mm-dd>
- Ui-kit package version consumed: <version>
- Package update commit: <sha>
- Source-copy deletion commit: <sha>
- Guard check proof: <command + path/CI reference>
- Catalog adoption paths:
  - <path 1>
  - <path 2>
- U7 baseline stability proof:
  - verify run: <reference/date>
  - drift status: <none|describe>
```

## Closure rule

`U8` cannot be closed until:

1. Both downstream repos submit complete evidence blocks.
2. The submitted package version maps to a verified `U7` baseline (green verify run, no drift).

## Submitted evidence

### U7/U8 downstream adoption evidence
- Repo: `chummer6-ui`
- Date (UTC): `2026-03-28`
- Ui-kit package version consumed: `0.1.0-preview`
- Package update commit: `84c56492`
- Source-copy deletion commit: `306f5bf3`
- Guard check proof: `cd /docker/chummercomplete/chummer6-ui && bash scripts/ai/verify.sh` enforces `rg -n '\b(class|record)\s+(TokenCanon|ThemeCompiler|ShellChrome|AccessibilityState|Banner|StaleStateBadge|ApprovalChip|OfflineBanner|DenseTableHeader|DenseRowMetadata|ExplainChip|SpiderStatusCard|ArtifactStatusCard)\b|\b(static\s+)?UiAdapterPayload\s+Adapt(ShellChrome|AccessibilityState|Banner|StaleStateBadge|ApprovalChip|OfflineBanner|DenseTableHeader|DenseRowMetadata|ExplainChip|SpiderStatusCard|ArtifactStatusCard)\s*\(' Chummer.Presentation Chummer.Blazor Chummer.Avalonia Chummer.Tests -g '*.cs'` as a fail-on-match boundary guard.
- Catalog adoption paths:
  - `Chummer.Presentation/UiKit/ChummerPatternBoundary.cs`
  - `Chummer.Blazor/Components/Shared/BuildLabHandoffPanel.razor`
  - `Chummer.Blazor/Components/Shared/RulesNavigatorPanel.razor`
  - `Chummer.Blazor/Components/Shared/CreatorPublicationPanel.razor`
  - `Chummer.Blazor/Components/Shared/RuntimeInspectorPanel.razor`
  - `Chummer.Blazor/Components/Shared/GmBoardFeed.razor`
  - `Chummer.Blazor/Components/Shared/NpcPersonaStudioPanel.razor`
- U7 baseline stability proof:
  - verify run: `cd /docker/chummercomplete/chummer-ui-kit && bash scripts/ai/verify.sh` rerun locally on `2026-03-28`; downstream verification also rerun with `cd /docker/chummercomplete/chummer6-ui && bash scripts/ai/verify.sh`.
  - drift status: `none`

### U7/U8 downstream adoption evidence
- Repo: `chummer6-mobile`
- Date (UTC): `2026-03-28`
- Ui-kit package version consumed: `0.1.0-preview`
- Package update commit: `f134092`
- Source-copy deletion commit: `6b57e12`
- Guard check proof: `cd /docker/chummercomplete/chummer6-mobile && bash scripts/ai/verify.sh` enforces `rg -n '\b(class|record)\s+(TokenCanon|ThemeCompiler|ShellChrome|AccessibilityState|Banner|StaleStateBadge|ApprovalChip|OfflineBanner|DenseTableHeader|DenseRowMetadata|ExplainChip|SpiderStatusCard|ArtifactStatusCard)\b|\b(static\s+)?UiAdapterPayload\s+Adapt(ShellChrome|AccessibilityState|Banner|StaleStateBadge|ApprovalChip|OfflineBanner|DenseTableHeader|DenseRowMetadata|ExplainChip|SpiderStatusCard|ArtifactStatusCard)\s*\(' src -g '*.cs'` as a fail-on-match boundary guard.
- Catalog adoption paths:
  - `Directory.Packages.props`
  - `src/Chummer.Play.Components/Chummer.Play.Components.csproj`
  - `scripts/ai/verify.sh`
  - `docs/PLAY_RELEASE_SIGNOFF.md`
- U7 baseline stability proof:
  - verify run: `cd /docker/chummercomplete/chummer-ui-kit && bash scripts/ai/verify.sh` rerun locally on `2026-03-28`; downstream verification also rerun with `cd /docker/chummercomplete/chummer6-mobile && bash scripts/ai/verify.sh`.
  - drift status: `none`
