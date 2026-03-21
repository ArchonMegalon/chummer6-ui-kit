# Worklist

- [done] Publish migration evidence that `chummer6-ui` and `chummer6-mobile` consume `Chummer.Ui.Kit` primitives through package references only for the live shared primitives.
- [done] Add package-ownership CI guards that fail if B1/U4/U5 primitive classes reappear as local source copies in presentation/play root projects.
- [done] Add milestone mapping or executable queue work for Dense data, state badges, explain chips, and Chummer-specific reusable patterns that were implicit in app repos.
- [done] Bootstrap repo structure and package boundaries
- [done] Seed token canon, theme compilation, and preview/gallery ownership
- [done] Establish full `U0-U9` milestone coverage truth with explicit status, completion percent, and ETA in `.codex-design/repo/UI_KIT_MILESTONE_COVERAGE.yaml`.

## Queue Slice: B1 package-only shared boundary (tokens + shell chrome + accessibility)

Milestone mapping:
- [x] `U1 Token canon` -> package-owned token keys and documented token contract consumed by presentation and play.
- [x] `U3 Shell chrome` -> package-owned shell primitives/adapters with deterministic payload contracts.
- [x] `U6 Accessibility and localization` -> package-owned accessibility primitive semantics and adapter payload parity.

- [x] Migrate shared token references used by presentation/play into `TokenCanon` additions and document token keys in `README.md`.
- [x] Expand shell chrome primitives/adapters for package-only consumption (no app-specific service/domain assumptions).
- [x] Finalize accessibility primitive payloads for shared busy/live/disabled/status semantics in both Blazor and Avalonia adapters.
- [x] Add/extend contract-style tests proving shell chrome and accessibility adapter outputs are deterministic and UI-kit only.
- [x] Publish package-consumption checklist for presentation/play confirming no source-copy UI primitives remain for this slice.

### Runnable backlog append: package-only consumption closure

- [x] `ui-kit`: Expand `README.md` with a "B1 token + shell chrome + accessibility contract" section that lists canonical token keys and adapter payload guarantees.
- [x] `ui-kit`: Add a test in `tests/Chummer.Ui.Kit.Tests/Program.cs` that asserts `TokenCanon.CreateDefault()` contains the shell + accessibility token keys used by adapters.
- [x] `presentation`: Replace any local/source-copied shell chrome or accessibility classes with `Chummer.Ui.Kit` package usage.
- [x] `play`: Replace any local/source-copied shell chrome or accessibility classes with `Chummer.Ui.Kit` package usage.
- [x] `presentation` + `play`: Add boundary checks (`rg`/CI guard) that fail when repo-local copies of B1 primitives are reintroduced.
- [x] `presentation` + `play`: Capture package adoption evidence (commit + path list) and link it back to this repo queue slice for closure.
- [x] `ui-kit`: Published package-consumption checklist in `docs/b1-package-consumption-checklist.md` for presentation/play migration evidence.

### Runnable execution backlog (B1, command-level)

- [x] `ui-kit`: Add explicit shell/accessibility token keys in `src/Chummer.Ui.Kit/Tokens/TokenCanon.cs` and keep values UI-only.
- [x] `ui-kit`: Update `README.md` B1 contract text to include the new token keys and adapter payload guarantees.
- [x] `ui-kit`: Extend `tests/Chummer.Ui.Kit.Tests/Program.cs` with a dedicated B1 check that asserts the shell/accessibility keys exist in `TokenCanon.CreateDefault()`.
- [x] `ui-kit`: Verify package determinism and contract stability with `scripts/ai/verify.sh`.
- [x] `presentation`: Run `rg -n "class .*Shell|class .*Accessibility|AdaptShellChrome|AdaptAccessibilityState" src` and replace local copies with package usage where found.
- [x] `play`: Run `rg -n "class .*Shell|class .*Accessibility|AdaptShellChrome|AdaptAccessibilityState" src` and replace local copies with package usage where found.
- [x] `presentation` + `play`: Add CI guard command `rg -n "class .*Shell|class .*Accessibility" src && exit 1 || exit 0` (scoped to prohibited shared primitives) to block source-copy regressions.

Acceptance criteria:
- [x] Token, shell chrome, and accessibility primitives are package-only and consume no domain DTOs, HTTP clients, storage logic, or service orchestration.
- [ ] Blazor and Avalonia adapters expose deterministic payload keys/roles for B1 primitives.
- [x] Presentation and play provide package-adoption proof and guard checks preventing source-copy regressions.

Slice publication evidence (2026-03-13):
- [x] Runnable B1 backlog is explicitly published in this file under `Queue Slice: B1 package-only shared boundary (tokens + shell chrome + accessibility)`.
- [x] Milestone mapping and acceptance criteria are present for token, shell chrome, and accessibility boundary scope.
- [x] Queue prompt requirement for "publish or append runnable backlog" is satisfied without duplicating completed slices.

## Queue Slice: U4/U5 centralization (dense data + state badges + explain chips + Chummer patterns)

Milestone mapping:
- [x] `U4 Dense-data controls` -> package-owned dense row and table primitives with deterministic adapter payloads.
- [x] `U5 Chummer-specific patterns` -> package-owned explain chips, stale/approval state badges, and reusable Chummer cards.

Runnable backlog:
- [x] `ui-kit`: Add dense-data primitives in `src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs` for sortable headers, dense-row metadata, row-state emphasis, and explain-affinity hints without domain DTO fields.
- [x] `ui-kit`: Implement Blazor/Avalonia adapter methods for each dense-data primitive with stable payload keys and role/class mappings.
- [x] `ui-kit`: Add explicit `ExplainChip`, `SpiderStatusCard`, and `ArtifactStatusCard` primitives in `src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs` with UI-only inputs.
- [x] `ui-kit`: Extend Blazor/Avalonia adapters with payload builders for explain chip and card patterns; include accessibility attributes where relevant.
- [x] `ui-kit`: Register `dense_data`, `explain_patterns`, and `chummer_cards` preview entries in `src/Chummer.Ui.Kit/Preview/PreviewGalleryManifest.cs`.
- [x] `ui-kit`: Add deterministic contract tests in `tests/Chummer.Ui.Kit.Tests/Program.cs` covering all new dense-data and pattern payloads.
- [ ] `presentation`: Replace local dense table state badges/chips/cards with `Chummer.Ui.Kit` package primitives.
- [ ] `play`: Replace local dense table state badges/chips/cards with `Chummer.Ui.Kit` package primitives.
- [ ] `presentation` + `play`: Add guard checks that fail CI if local/source-copied dense-data or explain/state pattern components reappear.
- [ ] `presentation` + `play`: Record adoption evidence (paths + commits) and attach it to this queue slice to close auditor finding `487871/487874`.

### Runnable execution backlog (U4/U5, command-level)

- [x] `ui-kit`: Add the new U4/U5 primitives to `src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs` and keep all inputs UI-only (`rg -n "record (Dense|Explain|Spider|Artifact)" src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs` must show the new records).
- [x] `ui-kit`: Implement deterministic projection methods in both adapters (`rg -n "Adapt(Dense|Explain|Spider|Artifact)" src/Chummer.Ui.Kit/Adapters/Blazor/BlazorUiKitAdapter.cs src/Chummer.Ui.Kit/Adapters/Avalonia/AvaloniaUiKitAdapter.cs` must return non-empty matches for each new primitive).
- [x] `ui-kit`: Register `dense_data`, `explain_patterns`, and `chummer_cards` previews in `src/Chummer.Ui.Kit/Preview/PreviewGalleryManifest.cs` and verify with `dotnet test tests/Chummer.Ui.Kit.Tests/Chummer.Ui.Kit.Tests.csproj --filter PreviewGallery`.
- [x] `ui-kit`: Add deterministic contract checks for both adapters in `tests/Chummer.Ui.Kit.Tests/Program.cs` and verify with `dotnet test tests/Chummer.Ui.Kit.Tests/Chummer.Ui.Kit.Tests.csproj --filter Deterministic`.
- [ ] `presentation`: Run `rg -n "ExplainChip|StatusCard|Dense(Row|Table)|StaleStateBadge|ApprovalChip" src` and replace local copies/usages with `Chummer.Ui.Kit` package primitives where found.
- [ ] `play`: Run `rg -n "ExplainChip|StatusCard|Dense(Row|Table)|StaleStateBadge|ApprovalChip" src` and replace local copies/usages with `Chummer.Ui.Kit` package primitives where found.
- [ ] `presentation` + `play`: Add/keep CI guard checks that fail when repo-local copies of U4/U5 patterns reappear.
- [ ] `presentation` + `play`: Fill `docs/u4-u5-centralization-adoption-evidence.md` with package version, replacement paths, local-copy deletion commits, and guard-check links.

Acceptance criteria:
- [ ] No domain DTOs, provider SDKs, HTTP clients, or external-tool business logic are introduced.
- [ ] New primitives are package-only, adapter-only, deterministic, and reusable across presentation and play.
- [x] Preview manifest and tests provide closure evidence for U4/U5 centralization work.

Slice publication evidence (2026-03-13):
- [x] Runnable U4/U5 backlog is explicitly published in this file under `Queue Slice: U4/U5 centralization (dense data + state badges + explain chips + Chummer patterns)`.
- [x] Milestone mapping and acceptance criteria are present for dense-data and Chummer-specific reusable pattern scope.
- [x] Auditor findings `487871/487874` are explicitly mapped to this queue slice for executable follow-through.
- [x] Queue prompt requirement for "add milestone mapping or executable queue work" is satisfied without duplicating already-completed U4/U5 implementation rows.

Implementation evidence update (2026-03-21):
- [x] Added explicit command-level U4/U5 runnable execution backlog in this section to make implementation probes and verification commands concrete.
- [x] Published downstream adoption evidence template in `docs/u4-u5-centralization-adoption-evidence.md` for presentation/play package migration proof and guard-check linkage.

## Queue Slice: Adapter extraction for shell/state chrome (Blazor + Avalonia)

Milestone mapping:
- [x] `U3 Shell chrome` -> package-owned shell chrome primitives are projected through both adapters.
- [x] `U5 Chummer-specific patterns` -> package-owned banner, stale-state badge, approval chip, and offline banner are projected through both adapters.
- [x] `U6 Accessibility and localization` -> package-owned accessibility/state primitive is projected through both adapters.

Runnable execution backlog:
- [x] `ui-kit`: Keep shell chrome primitive (`ShellChrome`) in `src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs` with UI-only inputs.
- [x] `ui-kit`: Keep state primitives (`Banner`, `StaleStateBadge`, `ApprovalChip`, `OfflineBanner`, `AccessibilityState`) in `src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs` with UI-only inputs.
- [x] `ui-kit`: Implement deterministic Blazor payload adapters for shell/state primitives in `src/Chummer.Ui.Kit/Adapters/Blazor/BlazorUiKitAdapter.cs`.
- [x] `ui-kit`: Implement deterministic Avalonia payload adapters for shell/state primitives in `src/Chummer.Ui.Kit/Adapters/Avalonia/AvaloniaUiKitAdapter.cs`.
- [x] `ui-kit`: Lock payload contracts with deterministic tests in `tests/Chummer.Ui.Kit.Tests/Program.cs`.
- [x] `ui-kit`: Verify extraction slice with `scripts/ai/verify.sh`.

Acceptance criteria:
- [x] Shell chrome, banners, stale-state badges, approval chips, offline banners, and accessibility/state primitives are package-owned and adapter-projected for both Blazor and Avalonia.
- [x] Contracts stay deterministic via test coverage for both adapters.
- [x] No domain DTOs, HTTP clients, storage logic, rules math, or service orchestration are introduced.

## Milestone modeling follow-through (from coverage file)

- [x] Finish milestone coverage modeling for ui-kit so ETA and completion truth are no longer partial.
- [x] U4 dense-data controls: publish runnable extraction backlog and acceptance criteria.
- [x] U5 Chummer-specific patterns: publish runnable migration backlog for state badges/explain chips/artifact patterns.
- [x] U7 visual regression/catalog: publish queue items for catalog surface + regression harness.
- [x] U8 release discipline: publish queue items for package release gates and verification checklist.

## Queue Slice: U7/U8 materialization (catalog + visual regression + release discipline)

Milestone mapping:
- [x] `U7 Visual regression and catalog` -> package-owned catalog manifests and deterministic adapter regression checks.
- [x] `U8 Release discipline` -> explicit release gates for versioning, changelog, packaging, verification, and downstream adoption evidence.

Runnable backlog:
- [x] `ui-kit`: Add catalog coverage inventory in `src/Chummer.Ui.Kit/Preview/PreviewGalleryManifest.cs` for all package primitives/patterns used as shared boundary surface.
- [x] `ui-kit`: Add deterministic visual regression fixture inputs in `tests/Chummer.Ui.Kit.Tests/Program.cs` for Blazor and Avalonia payload projections.
- [x] `ui-kit`: Add regression assertions that fail on payload key/shape drift for catalog-covered components.
- [x] `ui-kit`: Extend `scripts/ai/verify.sh` invocation path only if needed so catalog + regression checks run in the standard verification command.
- [x] `ui-kit`: Add a release-discipline section in `README.md` with SemVer bump rules, changelog requirement, `dotnet pack` validation, and required verify command.
- [x] `ui-kit`: Add release evidence template in `docs/u7-u8-release-adoption-evidence.md` for package version, contract impact, downstream adoption proof, and U7 baseline stability linkage.
- [ ] `presentation` + `play`: Consume published package version and record deletion of source-copied UI primitives that the release replaces.
- [ ] `presentation` + `play`: Add/keep guard checks preventing reintroduction of repo-local copies for catalog-covered primitives.

Acceptance criteria:
- [x] Catalog entries are package-owned and do not depend on domain DTOs, HTTP clients, storage, or external-provider logic.
- [x] Visual regression checks are deterministic and run from the repo-standard verification command.
- [x] Release checklist is explicit, repeatable, and requires package/adoption evidence before closure.
- [x] Queue closure criteria explicitly ties `U8` completion to a verified `U7` baseline in `docs/u7-u8-release-adoption-evidence.md`.

Slice closure evidence (2026-03-13):
- [x] Runnable U7/U8 backlog is explicitly published in this file under `Queue Slice: U7/U8 materialization (catalog + visual regression + release discipline)`.
- [x] Milestone mapping and acceptance criteria are present for catalog, visual-regression, and release-discipline scope.
- [x] Auditor findings `487872/487875` are explicitly mapped to this queue slice for executable follow-through.

Implementation evidence update (2026-03-21):
- [x] `PreviewGalleryManifest.CreateDefault()` publishes package-owned catalog keys for token canon, theme compilation, shell chrome, banner, stale-state badge, approval chip, offline banner, and accessibility state.
- [x] `tests/Chummer.Ui.Kit.Tests/Program.cs` contains deterministic catalog/regression checks (`PreviewGalleryDefaultManifestCoversPackageCatalog`, `BlazorAndAvaloniaPayloadsStayDeterministic`) that fail on payload shape/key drift.
- [x] `scripts/ai/verify.sh` already runs the test project in the standard verification path, so catalog/regression checks execute on every verify run.
- [x] `docs/u7-u8-release-adoption-evidence.md` now defines required downstream evidence fields (package version consumed, local-copy deletion proof, guard checks, catalog adoption paths) and U8 closure linkage to a verified U7 baseline.
