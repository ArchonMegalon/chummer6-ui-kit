# U4/U5 Centralization Adoption Evidence

Use this template to close the U4/U5 queue slice:

`Queue Slice: U4/U5 centralization (dense data + state badges + explain chips + Chummer patterns)`

Auditor findings mapped: `487871`, `487874`

## Required evidence blocks

1. Package version consumed
- `Chummer.Ui.Kit` version in `chummer6-ui`: `0.1.0-preview` from `Directory.Build.props`.
- `Chummer.Ui.Kit` version in `chummer6-mobile`: `0.1.0-preview` from `Directory.Packages.props`.
- Link(s) to package-bump commits: none in this closure slice; both downstream repos were already on the shared package plane.

2. Local-copy replacement proof (`chummer6-ui`)
- Paths where dense-data/explain/chummer-pattern local components were removed: no standalone source-copy primitive files remained; replacement happened at consumer call sites.
- Paths now consuming package primitives:
  - `Chummer.Presentation/UiKit/ChummerPatternBoundary.cs`
  - `Chummer.Blazor/Components/Shared/BuildLabHandoffPanel.razor`
  - `Chummer.Blazor/Components/Shared/RulesNavigatorPanel.razor`
  - `Chummer.Blazor/Components/Shared/NpcPersonaStudioPanel.razor`
  - `Chummer.Blazor/Components/Shared/GmBoardFeed.razor`
  - `Chummer.Blazor/Components/Shared/RuntimeInspectorPanel.razor`
  - `Chummer.Tests/Compliance/MigrationComplianceTests.cs`
  - `Chummer.Tests/Presentation/CampaignSpineShowcaseComponentTests.cs`
  - `Chummer.Tests/Presentation/BlazorShellComponentTests.cs`
  - `scripts/ai/verify.sh`
- Commit(s): `chummer6-ui@306f5bf3` (`Adopt ui-kit dense and explain patterns`)

3. Local-copy replacement proof (`chummer6-mobile`)
- Paths where dense-data/explain/chummer-pattern local components were removed: none; repo scan returned no local U4/U5 primitive copies under `src/`.
- Paths now consuming package primitives: package-only guard maintained in `scripts/ai/verify.sh`; runtime proof refreshed in `.codex-studio/published/MOBILE_LOCAL_RELEASE_PROOF.generated.json`.
- Commit(s): `chummer6-mobile@6b57e12` (`Harden mobile ui-kit pattern guardrails`)

4. Guard checks (both repos)
- CI job/check name that blocks local reintroduction: repo-local `scripts/ai/verify.sh` in both downstream repos.
- Guard command(s):
  - `cd /docker/chummercomplete/chummer6-ui && bash scripts/ai/verify.sh`
  - `cd /docker/chummercomplete/chummer-play && bash scripts/ai/verify.sh`
- Link(s) to passing CI run(s): local repo verification only; mobile proof artifact refreshed at `.codex-studio/published/MOBILE_LOCAL_RELEASE_PROOF.generated.json`.

5. Contract compatibility note
- Any payload/role/class key changes from prior local components: downstream consumers now rely on UI-kit adapter payload keys/classes (`chummer-dense-header`, `chummer-dense-row`, `chummer-explain-chip`, `chummer-chip-approved`, `chummer-badge-stale`, `chummer-card-spider`, `chummer-card-artifact`) through `ChummerPatternBoundary`.
- Confirmation that no domain DTO/service logic was introduced into UI-kit: confirmed; the new boundary and guards only wrap UI-kit adapter payloads and do not add domain/service logic to the package.

6. Verification linkage
- `scripts/ai/verify.sh` run in `chummer-ui-kit` for U4/U5 changes: rerun locally on 2026-03-28 and passed.
- Downstream verify/build command(s) run in `chummer6-ui` and `chummer6-mobile`:
  - `cd /docker/chummercomplete/chummer6-ui && bash scripts/ai/verify.sh`
  - `cd /docker/chummercomplete/chummer6-ui && dotnet build Chummer.Blazor/Chummer.Blazor.csproj --nologo`
  - `cd /docker/chummercomplete/chummer-play && bash scripts/ai/verify.sh`
- Link(s) to logs/artifacts: local command output plus `.codex-studio/published/MOBILE_LOCAL_RELEASE_PROOF.generated.json`.

## Closure gate

U4/U5 is ready to mark complete only when all six evidence blocks are populated for both downstream repos and linked back into `WORKLIST.md`.
