# GitHub Codex Review

PR: https://github.com/ArchonMegalon/chummer6-ui-kit/pull/4

Findings:
- [high] src/Chummer.Ui.Kit/Adapters/Blazor/BlazorUiKitAdapter.cs [correctness] a11y-dense-header-aria-sort-on-unsortable
Blazor dense header always derives `aria-sort` from `SortDirection` and always emits `chummer-dense-sort-{direction}` even when `data-sortable=false` (lines 10-25), so unsortable headers can still present sorted state.; Avalonia dense header always emits `DenseSort{direction}` and `sort-direction` regardless of `sortable` (lines 10-18), so non-sortable headers can still carry sort affordance classes/state.; Tests cover sortable-desc and unsortable-none (Program.cs lines 189-223), but there is no deterministic test for unsortable headers with non-None direction to prevent this regression.
Expected fix: Normalize unsortable headers to neutral semantics (no sorted ARIA state/affordance when `Sortable=false`, or coerce output direction to none), and add explicit Blazor+Avalonia tests for unsortable + Asc/Desc inputs.
