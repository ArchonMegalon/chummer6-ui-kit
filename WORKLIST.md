# Worklist

- [done] Publish migration evidence that `chummer6-ui` and `chummer6-mobile` consume `Chummer.Ui.Kit` primitives through package references only for the live shared primitives.
- [done] Publish executable migration checklist/template for presentation and play to consume `Chummer.Ui.Kit` as package-only and remove duplicate local token/theme/component copies.
- [done] Add package-ownership CI guards that fail if B1/U4/U5 primitive classes reappear as local source copies in presentation/play root projects.
- [done] Add milestone mapping or executable queue work for Dense data, state badges, explain chips, and Chummer-specific reusable patterns that were implicit in app repos.
- [done] Sync the approved Chummer design bundle into `.codex-design/` and refresh repo-local implementation/review context.
- [done] Publish or append runnable backlog for Shared token, shell chrome, and accessibility primitives as a package-only boundary consumed by presentation and play.
- [done] Add milestone mapping or executable queue work for Shared token, shell chrome, and accessibility primitives that were not yet modeled as a package-only boundary consumed by presentation and play.
- [done] Bootstrap repo structure and package boundaries
- [done] Seed token canon, theme compilation, and preview/gallery ownership
- [done] Establish full `U0-U9` milestone coverage truth with explicit status, completion percent, and ETA in `.codex-design/repo/UI_KIT_MILESTONE_COVERAGE.yaml`.

## Queue Slice: Design mirror sync and review context refresh

System re-entry evidence update (2026-04-12):
- [x] Revalidated queue title `Sync the approved Chummer design bundle into \`ui-kit\` under \`.codex-design/\` and refresh repo-local review context.` against `.codex-studio/published/QUEUE.generated.yaml`.
- [x] Re-synced `.codex-design/product` to the approved `chummer6-ui-kit` manifest subset from `products/chummer/sync/sync-manifest.yaml` (`publish_subset_only: true`, `prune_stale_product_files: true`) and pruned stale mirror files.
- [x] Revalidated mirror parity post-sync: expected subset files present with no missing/stale/extra drift for this repo.
- [x] Revalidated `.codex-design/repo/IMPLEMENTATION_SCOPE.md` matches `products/chummer/projects/ui-kit.md`.
- [x] Revalidated `.codex-design/review/REVIEW_CONTEXT.md` matches `products/chummer/review/ui-kit.AGENTS.template.md`.

## Queue Slice: B1 package-only shared boundary (tokens + shell chrome + accessibility)

## Fleet execution sequence (cross-shard)

- P0 foundation: complete `core/WL-200` first, then run `DR-120` and launch trust/recovery surface parity slices in parallel (`ui/WL-240`, `hub/WL-240`, `mobile/WL-027`, `hub-registry/WL-260`, `media/MF-014`).
- P1 hardening: after `WL-200` is stable, execute `core/WL-201` then the follow-on clarity/visibility slices (`ui/WL-241`, `hub/WL-241`, `hub-registry/WL-261`, `hub-registry/WL-262`, `mobile/WL-028`, `media/MF-015`).
- P2 quality finish: gate on `design/DR-121` and `design/DR-122` before closure on `design/DR-123`; complete ui-kit flagship reliability slice in the same cycle after cross-shard copy/state parity settles.

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
- [x] Blazor and Avalonia adapters expose deterministic payload keys/roles for B1 primitives.
- [x] Presentation and play provide package-adoption proof and guard checks preventing source-copy regressions.

Slice publication evidence (2026-03-13):
- [x] Runnable B1 backlog is explicitly published in this file under `Queue Slice: B1 package-only shared boundary (tokens + shell chrome + accessibility)`.
- [x] Milestone mapping and acceptance criteria are present for token, shell chrome, and accessibility boundary scope.
- [x] Queue prompt requirement for "publish or append runnable backlog" is satisfied without duplicating completed slices.

System re-entry evidence update (2026-03-21):
- [x] Revalidated queue title `Publish or append runnable backlog for Shared token, shell chrome, and accessibility primitives are still not a real package-only boundary consumed by presentation and play..` against this section.
- [x] Confirmed runnable backlog, milestone mapping, and acceptance criteria for this B1 slice are already present and remain the active closure artifact.
- [x] No duplicate backlog rows were added for this slice during re-entry.
- [x] Revalidated queue title `Add milestone mapping or executable queue work for Shared token, shell chrome, and accessibility primitives are still not a real package-only boundary consumed by presentation and play..` against this section and confirmed closure evidence is already captured by the B1 milestone mapping and runnable execution backlog.

Implementation evidence update (2026-03-21):
- [x] Deterministic payload contract tests for both adapters are present in `tests/Chummer.Ui.Kit.Tests/Program.cs` (`AdapterDefaultsStayAlignedWithTokenCanon`, `BlazorAndAvaloniaPayloadsStayDeterministic`) and cover B1 shell/accessibility payload key and role stability.
- [x] Expanded `docs/b1-package-consumption-checklist.md` to cover token/theme/component duplicate-removal scans and CI guard patterns in addition to B1 primitives.
- [x] Added `docs/package-only-migration-evidence.md` with required downstream evidence blocks for `chummer6-ui` and `chummer6-mobile`.
- [x] Added downstream commit-level evidence from `chummer6-ui` and `chummer6-mobile` in `docs/package-only-migration-evidence.md` (package refs, guard wiring, and verify run references) to close cross-repo migration execution.

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
- [x] `presentation`: Replace local dense table state badges/chips/cards with `Chummer.Ui.Kit` package primitives through `ChummerPatternBoundary` and downstream showcase consumers.
- [x] `play`: Confirm no repo-local dense table state badges/chips/cards remain and extend the package-only guard to block U4/U5 source-copy reintroduction.
- [x] `presentation` + `play`: Add guard checks that fail CI if local/source-copied dense-data or explain/state pattern components reappear.
- [x] `presentation` + `play`: Record adoption evidence (paths + commits) and attach it to this queue slice to close auditor finding `487871/487874`.

### Runnable execution backlog (U4/U5, command-level)

- [x] `ui-kit`: Add the new U4/U5 primitives to `src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs` and keep all inputs UI-only (`rg -n "record (Dense|Explain|Spider|Artifact)" src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs` must show the new records).
- [x] `ui-kit`: Implement deterministic projection methods in both adapters (`rg -n "Adapt(Dense|Explain|Spider|Artifact)" src/Chummer.Ui.Kit/Adapters/Blazor/BlazorUiKitAdapter.cs src/Chummer.Ui.Kit/Adapters/Avalonia/AvaloniaUiKitAdapter.cs` must return non-empty matches for each new primitive).
- [x] `ui-kit`: Register `dense_data`, `explain_patterns`, and `chummer_cards` previews in `src/Chummer.Ui.Kit/Preview/PreviewGalleryManifest.cs` and verify with `dotnet test tests/Chummer.Ui.Kit.Tests/Chummer.Ui.Kit.Tests.csproj --filter PreviewGallery`.
- [x] `ui-kit`: Add deterministic contract checks for both adapters in `tests/Chummer.Ui.Kit.Tests/Program.cs` and verify with `dotnet test tests/Chummer.Ui.Kit.Tests/Chummer.Ui.Kit.Tests.csproj --filter Deterministic`.
- [x] `presentation`: Run `rg -n "ExplainChip|StatusCard|Dense(Row|Table)|StaleStateBadge|ApprovalChip" src` and replace local copies/usages with `Chummer.Ui.Kit` package primitives where found.
- [x] `play`: Run `rg -n "ExplainChip|StatusCard|Dense(Row|Table)|StaleStateBadge|ApprovalChip" src`; no repo-local copies remained, and `scripts/ai/verify.sh` now blocks reintroduction of U4/U5 source copies.
- [x] `presentation` + `play`: Add/keep CI guard checks that fail when repo-local copies of U4/U5 patterns reappear.
- [x] `presentation` + `play`: Fill `docs/u4-u5-centralization-adoption-evidence.md` with package version, replacement paths, local-copy deletion commits, and guard-check links.

Acceptance criteria:
- [x] No domain DTOs, provider SDKs, HTTP clients, or external-tool business logic are introduced.
- [x] New primitives are package-only, adapter-only, deterministic, and reusable across presentation and play.
- [x] Preview manifest and tests provide closure evidence for U4/U5 centralization work.

Slice publication evidence (2026-03-13):
- [x] Runnable U4/U5 backlog is explicitly published in this file under `Queue Slice: U4/U5 centralization (dense data + state badges + explain chips + Chummer patterns)`.
- [x] Milestone mapping and acceptance criteria are present for dense-data and Chummer-specific reusable pattern scope.
- [x] Auditor findings `487871/487874` are explicitly mapped to this queue slice for executable follow-through.
- [x] Queue prompt requirement for "add milestone mapping or executable queue work" is satisfied without duplicating already-completed U4/U5 implementation rows.

System re-entry evidence update (2026-04-12):
- [x] Revalidated queue title `Publish or append runnable backlog for Dense data, state badges, explain chips, and Chummer-specific reusable patterns are still implicit in app repos instead of centralized here..` against this section.
- [x] Revalidated queue title `Add milestone mapping or executable queue work for Dense data, state badges, explain chips, and Chummer-specific reusable patterns are still implicit in app repos instead of centralized here..` against this section.
- [x] Confirmed runnable backlog, milestone mapping, and acceptance criteria are already published here; no duplicate backlog rows were added during re-entry.

Implementation evidence update (2026-03-21):
- [x] Added explicit command-level U4/U5 runnable execution backlog in this section to make implementation probes and verification commands concrete.
- [x] Published downstream adoption evidence template in `docs/u4-u5-centralization-adoption-evidence.md` for presentation/play package migration proof and guard-check linkage.
- [x] Closed downstream adoption with `chummer6-ui@306f5bf3` and `chummer6-mobile@6b57e12`, including repo-local verification and guardrail updates.

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

System re-entry evidence update (2026-04-12):
- [x] Revalidated queue title `Finish milestone coverage modeling for ui-kit so ETA and completion truth are no longer partial.` against this section and `.codex-design/repo/UI_KIT_MILESTONE_COVERAGE.yaml`.
- [x] Reconciled stale in-progress U1-U8 entries in `.codex-design/repo/UI_KIT_MILESTONE_COVERAGE.yaml` to complete where implemented evidence and verify gates are already present.
- [x] Updated coverage rollup/status counts so completion truth remains explicit and non-partial with full ETA coverage.

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
- [x] `presentation` + `play`: Consume published package version and record deletion of source-copied UI primitives that the release replaces.
- [x] `presentation` + `play`: Add/keep guard checks preventing reintroduction of repo-local copies for catalog-covered primitives.

Acceptance criteria:
- [x] Catalog entries are package-owned and do not depend on domain DTOs, HTTP clients, storage, or external-provider logic.
- [x] Visual regression checks are deterministic and run from the repo-standard verification command.
- [x] Release checklist is explicit, repeatable, and requires package/adoption evidence before closure.
- [x] Queue closure criteria explicitly ties `U8` completion to a verified `U7` baseline in `docs/u7-u8-release-adoption-evidence.md`.

Slice closure evidence (2026-03-13):
- [x] Runnable U7/U8 backlog is explicitly published in this file under `Queue Slice: U7/U8 materialization (catalog + visual regression + release discipline)`.
- [x] Milestone mapping and acceptance criteria are present for catalog, visual-regression, and release-discipline scope.
- [x] Auditor findings `487872/487875` are explicitly mapped to this queue slice for executable follow-through.

System re-entry evidence update (2026-04-10):
- [x] Revalidated queue title `Publish or append runnable backlog for Catalog, visual-regression, and release discipline for the shared kit are not yet materialized..` against this section.
- [x] Revalidated queue title `Add milestone mapping or executable queue work for Catalog, visual-regression, and release discipline for the shared kit are not yet materialized..` against this section.
- [x] Confirmed runnable backlog, milestone mapping, and acceptance criteria are already published here; no duplicate backlog rows were added during re-entry.

System re-entry evidence update (2026-04-15):
- [x] Revalidated queue title `Publish or append runnable backlog for Catalog, visual-regression, and release discipline for the shared kit are not yet materialized..` against this section and `.codex-studio/published/QUEUE.generated.yaml`.
- [x] Confirmed U7/U8 catalog, visual-regression, and release-discipline backlog remains materialized with complete milestone mapping, acceptance criteria, downstream evidence template, and implementation evidence.
- [x] Processed feedback `feedback/2026-04-12-114601-audit-task-11711.md`, `feedback/2026-04-13-210205-audit-task-11711.md`, `feedback/2026-04-13-222212-audit-task-11711.md`, and `feedback/2026-04-14-104610-audit-task-11711.md` in order; all four publish the separate design-mirror refresh queue item, which is already represented in `.codex-studio/published/QUEUE.generated.yaml` and separately closed in the design mirror sync section.
- [x] Processed feedback `feedback/2026-04-14-110921-audit-task-11711.md` and `feedback/2026-04-14-124320-audit-task-11711.md` in order; both are duplicate publications of the same separate design-mirror refresh queue item and do not change the U7/U8 backlog/materialization slice.
- [x] Processed feedback `feedback/2026-04-14-162939-audit-task-11711.md`, `feedback/2026-04-14-171134-audit-task-11711.md`, `feedback/2026-04-15-021121-audit-task-11711.md`, `feedback/2026-04-15-025948-audit-task-11711.md`, and `feedback/2026-04-15-033529-audit-task-11711.md` in order; all five republish the separate design-mirror refresh queue item and do not change the U7/U8 backlog/materialization slice.
- [x] No duplicate U7/U8 backlog rows were added during re-entry.

System re-entry evidence update (2026-04-18):
- [x] Revalidated queue title `Publish or append runnable backlog for Catalog, visual-regression, and release discipline for the shared kit are not yet materialized..` against this section, `README.md`, `src/Chummer.Ui.Kit/Preview/PreviewGalleryManifest.cs`, `tests/Chummer.Ui.Kit.Tests/Program.cs`, and `docs/u7-u8-release-adoption-evidence.md`.
- [x] Confirmed the slice remains already complete in repo state: catalog keys are materialized in `PreviewGalleryManifest.CreateDefault()`, deterministic regression coverage exists in `tests/Chummer.Ui.Kit.Tests/Program.cs`, and release-discipline/adoption evidence remains published in `README.md` and `docs/u7-u8-release-adoption-evidence.md`.
- [x] Processed unread feedback `feedback/2026-04-15-061327-audit-task-11711.md`; it republishes the separate design-mirror refresh queue item and does not reopen or change this U7/U8 backlog/materialization slice.
- [x] No duplicate backlog rows were added for this slice during the 2026-04-18 re-entry pass.

System re-entry evidence update (2026-04-21):
- [x] Revalidated queue title `Publish or append runnable backlog for Catalog, visual-regression, and release discipline for the shared kit are not yet materialized..` against this section, `.codex-studio/published/QUEUE.generated.yaml`, `README.md`, `src/Chummer.Ui.Kit/Preview/PreviewGalleryManifest.cs`, `tests/Chummer.Ui.Kit.Tests/Program.cs`, and `docs/u7-u8-release-adoption-evidence.md`.
- [x] Confirmed the slice remains already complete in repo state; no new runnable backlog or milestone mapping rows are needed because U7/U8 catalog coverage, deterministic regression checks, and release-discipline evidence are still materialized.
- [x] Processed unread feedback `feedback/2026-04-18-193912-audit-task-11711.md`; it republishes the separate design-mirror refresh queue item and does not reopen or change this U7/U8 backlog/materialization slice.
- [x] Processed unread feedback `feedback/2026-04-21-133747-audit-task-11711.md`; it republishes the separate design-mirror parity hygiene queue item already present in `.codex-studio/published/QUEUE.generated.yaml` and does not reopen or change this U7/U8 backlog/materialization slice.
- [x] No duplicate backlog rows were added for this slice during the 2026-04-21 re-entry pass.

System re-entry evidence update (2026-04-21, current pass):
- [x] Re-read the required design mirror, repo scope, review context, queue overlay, and current repository state before taking action on this slice.
- [x] Reconfirmed that `Publish or append runnable backlog for Catalog, visual-regression, and release discipline for the shared kit are not yet materialized..` is already satisfied by this U7/U8 section plus `README.md`, `src/Chummer.Ui.Kit/Preview/PreviewGalleryManifest.cs`, `tests/Chummer.Ui.Kit.Tests/Program.cs`, and `docs/u7-u8-release-adoption-evidence.md`.
- [x] Reconfirmed that the newer queue item `Auto-detect and repair recurring \`ui-kit\` mirror drift after 6373 repeated audit observations; keep one bounded queue slice for the affected local design mirror bundle instead of reopening one-off mirror refresh work.` is a separate design-mirror hygiene slice and does not justify reopening or duplicating the already-closed U7/U8 backlog/materialization slice.
- [x] No U7/U8 backlog, milestone, or acceptance rows were added or changed beyond this re-entry evidence note.

Implementation evidence update (2026-03-21):
- [x] `PreviewGalleryManifest.CreateDefault()` publishes package-owned catalog keys for token canon, theme compilation, shell chrome, banner, stale-state badge, approval chip, offline banner, and accessibility state.
- [x] `tests/Chummer.Ui.Kit.Tests/Program.cs` contains deterministic catalog/regression checks (`PreviewGalleryDefaultManifestCoversPackageCatalog`, `BlazorAndAvaloniaPayloadsStayDeterministic`) that fail on payload shape/key drift.
- [x] `scripts/ai/verify.sh` already runs the test project in the standard verification path, so catalog/regression checks execute on every verify run.
- [x] `docs/u7-u8-release-adoption-evidence.md` now defines required downstream evidence fields (package version consumed, local-copy deletion proof, guard checks, catalog adoption paths) and U8 closure linkage to a verified U7 baseline.
- [x] `docs/u7-u8-release-adoption-evidence.md` now contains populated downstream evidence for `chummer6-ui` (`84c56492`, `306f5bf3`) and `chummer6-mobile` (`f134092`, `6b57e12`), including package version `0.1.0-preview`, fail-on-match guard commands, and current 2026-03-28 verify references.

## Queue Slice: Flagship UX parity and reliability primitives

- [x] `ui-kit`: Add canonical UX pattern definitions for onboarding, error, and empty states in `TokenCanon` so app consumers can render consistent user guidance.
- [done] `ui-kit`: Publish a reusable accessibility-first pattern package for role transitions, progress-toasts, and resume affordances used by shell and mobile consumers.
- [done] `ui-kit`: Add deterministic payload snapshots for the new UX state patterns and require them in shared adapter tests.
- [x] `presentation` + `play`: Consume and verify the new patterns without source-copy reintroductions, and add regression assertions for fallback readability/contrast.

## Queue Slice: Onboarding and long-running state primitives

- [x] `ui-kit`: Add shared pattern tokens for onboarding, empty-state, recovery, and first-run states so desktop, mobile, and hosted surfaces can use one canonical UX contract.
  - Owner: `ui-kit`
  - Implemented-by: `chummer6-ui`, `chummer6-mobile`
  - Acceptance checks: (1) deterministic token/state snapshots for onboarding/empty-state/recovery payloads are present; (2) no divergence across desktop/mobile consumer labels for the same action; (3) payload keys are stable under contract tests.
- [x] `ui-kit`: Add shared long-running action control patterns for retry, cancel, rollback, and safe continuation, plus tests that enforce locale-safe labels and a single no-loss path.
  - Owner: `ui-kit`
  - Implemented-by: `chummer6-ui`, `chummer6-mobile`
  - Acceptance checks: (1) payload snapshots cover retry/cancel/rollback/continue-per-run actions in both Blazor and Avalonia adapters; (2) accessibility-focused states preserve readable contrast and focus order; (3) design/DR-129 action-class dictionary is referenced by dependent shards before merge.
- [x] `ui-kit`: Add adoption and CI guard checks for new onboarding/action primitives in `chummer6-ui` and `chummer6-mobile` to prevent source-copy reintroduction.
  - Owner: `ui-kit` + hosts
  - Implemented-by: `chummer6-ui`, `chummer6-mobile`
  - Acceptance checks: (1) guard commands confirm no local source copy of onboarding/action primitives; (2) downstream queues in presentation/mobile still point to implemented `ui-kit` primitives; (3) all guard failures are localized to actionable paths.

Implementation evidence update (2026-04-08):
- [x] Added package-owned `RoleTransition`, `ProgressToast`, and `ResumeAffordance` primitives in `src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs`.
- [x] Added deterministic Blazor and Avalonia adapter projections for all three patterns with accessibility-focused roles/live-region/progress attributes.
- [x] Added canonical token keys for transition, toast, and resume defaults in `src/Chummer.Ui.Kit/Tokens/TokenCanon.cs`.
- [x] Added preview manifest coverage key `transition_patterns` and deterministic test assertions in `tests/Chummer.Ui.Kit.Tests/Program.cs`.
- [x] Added file-backed deterministic payload snapshots for `RoleTransition`, `ProgressToast`, and `ResumeAffordance` in `tests/Chummer.Ui.Kit.Tests/Snapshots/*.snapshot`.
- [x] Updated shared adapter tests in `tests/Chummer.Ui.Kit.Tests/Program.cs` to require those snapshots so adapter payload drift fails verification.

Implementation evidence update (2026-04-10):
- [x] Added `DefaultFallbackContrastRemainsReadable` in `tests/Chummer.Ui.Kit.Tests/Program.cs` to assert WCAG-style fallback contrast floors for canonical text/background token pairs (`color.text.primary`/`color.text.muted` against `color.background.panel`/`color.background.canvas`).
- [x] Kept deterministic snapshot assertions for `RoleTransition`, `ProgressToast`, and `ResumeAffordance` as the regression guard against source-copy drift while downstream presentation/play continue package-only consumption checks.

Implementation evidence update (2026-04-10, onboarding/action controls closure):
- [x] Added canonical token keys in `src/Chummer.Ui.Kit/Tokens/TokenCanon.cs` for onboarding, empty-state, recovery, first-run, and long-running action-control defaults, including the `design/DR-129` action dictionary reference token.
- [x] Added package-owned `GuidanceState` and `LongRunningActionControls` primitives in `src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs` with locale-safe label guards and enforced single no-loss-path semantics.
- [x] Added deterministic Blazor/Avalonia adapter projections and payload snapshots for onboarding, empty-state, recovery, first-run, and retry/cancel/rollback/safe-continuation action controls.
- [x] Extended preview manifest and shared deterministic tests to require `guidance_states` and `long_running_actions` contract coverage.

Implementation evidence update (2026-04-10, onboarding/action adoption + CI guard closure):
- [x] Updated `chummer6-ui/scripts/ai/verify.sh` guard scan to fail on local source-copy reintroduction of `GuidanceState`, `LongRunningActionControls`, `AdaptGuidanceState(...)`, and `AdaptLongRunningActionControls(...)`.
- [x] Updated `chummer6-mobile/scripts/ai/verify.sh` guard scan with the same onboarding/action primitive fail-on-match coverage.
- [x] Added downstream adoption evidence and localized guard-scope proof in `docs/onboarding-action-adoption-evidence.md`.
- [x] Extended `scripts/ai/verify.sh` in this repo to require onboarding/action adoption evidence and queued-slice closure status before passing.

Implementation evidence update (2026-04-15, completion recovery closure):
- [x] Added the missing canonical `error.state.*` token pair in `src/Chummer.Ui.Kit/Tokens/TokenCanon.cs` so the guidance-state contract now fully covers onboarding, error, empty-state, recovery, and first-run.
- [x] Extended `GuidanceStateKind`, Blazor contract-case mapping, and assertive live-region routing so `error` guidance payloads are deterministic alongside recovery-state payloads.
- [x] Added token checks, adapter payload assertions, and new Blazor/Avalonia snapshots for the error-state guidance variant in `tests/Chummer.Ui.Kit.Tests/Program.cs` and `tests/Chummer.Ui.Kit.Tests/Snapshots/`.

## Queue Slice: Classic dense workbench preset (flagship Avalonia default)

Milestone mapping:
- [x] `U1 Token canon` -> add compact/noise-budget token keys for dense flagship desktop posture.
- [x] `U3 Shell chrome` -> encode top menu, toolstrip, dense tab strip, and permanent status strip posture in package-owned preset payload.
- [x] `U4 Dense-data controls` -> encode compact list/detail panes, compact inspector forms, and compact data grid posture as preset defaults.
- [x] `U7 Visual regression and catalog` -> add dense-workbench layout regression fixtures/proofs beyond generic shell polish.

Runnable backlog:
- [x] `ui-kit`: Add a `classic_dense_workbench` preset contract in `src/Chummer.Ui.Kit/Tokens/TokenCanon.cs` for compact spacing, compact header scale, banner-height ceiling, badge-density ceiling, compact field height, and compact button height tokens.
- [x] `ui-kit`: Add preset payload primitive(s) in `src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs` for menu bar, toolstrip, tab strip, list/detail pane density, inspector compactness, and permanent status strip posture.
- [x] `ui-kit`: Add Blazor/Avalonia adapter projection methods for the dense-workbench preset in `src/Chummer.Ui.Kit/Adapters/Blazor/BlazorUiKitAdapter.cs` and `src/Chummer.Ui.Kit/Adapters/Avalonia/AvaloniaUiKitAdapter.cs` with deterministic payload keys.
- [x] `ui-kit`: Wire Avalonia defaults to `classic_dense_workbench` so flagship desktop consumers receive the dense preset unless explicitly overridden.
- [x] `ui-kit`: Register a dedicated preview/catalog key in `src/Chummer.Ui.Kit/Preview/PreviewGalleryManifest.cs` for dense workbench posture proof.
- [x] `ui-kit`: Add deterministic tests and snapshot fixtures in `tests/Chummer.Ui.Kit.Tests/Program.cs` and `tests/Chummer.Ui.Kit.Tests/Snapshots/` that assert compact/noise-budget token presence and stable dense-workbench payload projections.
- [x] `ui-kit`: Extend visual-regression checks to include dense workbench layout measurements (menu/toolstrip/tab/list-detail/inspector/status strip density assertions), not only shell/badge primitives.
- [x] `ui-kit`: Add release evidence capture in `docs/u7-u8-release-adoption-evidence.md` tying U8 closure to verified dense-workbench U7 baseline for Avalonia flagship defaults.

Acceptance criteria:
- [x] A package-owned classic dense-workbench preset exists and is the default flagship theme pack for Avalonia surfaces.
- [x] Noise-budget token set explicitly covers compact spacing/header scale/banner ceiling/badge ceiling/field height/button height with deterministic names.
- [x] Visual regression evidence includes dense-workbench layout measurements and fails on density regressions.
- [x] Accessibility posture remains explicit and does not rely on blanket spaciousness or loud chrome.

Feedback incorporation evidence (2026-04-11):
- [x] Processed unread feedback in order: `feedback/2026-04-11-201723-dense-workbench-preset.md`, then `feedback/2026-04-11-204118-classic-dense-workbench-preset.md`.
- [x] Added this runnable queue slice to materialize dense-workbench preset, noise-budget tokens, flagship Avalonia default posture, and dense visual-regression proof requirements.

Feedback incorporation evidence (2026-04-12):
- [x] Processed `feedback/2026-04-12-github-review-pr.md`; confirmed the current slice is the U7/U8 catalog, visual-regression, and release-discipline backlog/materialization slice rather than the `.codex-design`-only mirror-sync queue item.
- [x] Processed `feedback/2026-04-12-dense-preset-default-and-noise-budget.md`; confirmed the classic dense-workbench preset is the flagship Avalonia default, covers menu/toolstrip/status/tab/list-detail/grid/inspector posture, keeps explicit compact/noise-budget tokens testable, and has dense layout regression snapshots/assertions.

Implementation evidence update (2026-04-11, classic dense workbench closure):
- [x] Added package-owned `classic_dense_workbench` and dense noise-budget tokens in `src/Chummer.Ui.Kit/Tokens/TokenCanon.cs`.
- [x] Added package-owned `ClassicDenseWorkbenchPreset` primitive in `src/Chummer.Ui.Kit/Adapters/UiKitAdapterPrimitives.cs`.
- [x] Added deterministic Blazor/Avalonia preset projections in `src/Chummer.Ui.Kit/Adapters/Blazor/BlazorUiKitAdapter.cs` and `src/Chummer.Ui.Kit/Adapters/Avalonia/AvaloniaUiKitAdapter.cs`, including `FlagshipDesktopDefault` Avalonia posture.
- [x] Added catalog entry `classic_dense_workbench` in `src/Chummer.Ui.Kit/Preview/PreviewGalleryManifest.cs`.
- [x] Added deterministic token/payload/snapshot/density-budget assertions in `tests/Chummer.Ui.Kit.Tests/Program.cs` and `tests/Chummer.Ui.Kit.Tests/Snapshots/{blazor,avalonia}.classic-dense-workbench.snapshot`.
