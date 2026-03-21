# GitHub Codex Review

PR: https://github.com/ArchonMegalon/chummer6-ui-kit/pull/5

Findings:
- [high] src/Chummer.Ui.Kit/Adapters/Blazor/BlazorUiKitAdapter.cs [correctness] dense-header-aria-sort-unsortable
Blazor adapter computes `aria-sort` solely from `header.SortDirection` (lines 11-16, 24) and does not gate it on `header.Sortable`.; DenseTableHeader constructor allows `sortable: false` with `sortDirection: Asc/Desc` (lines 144-150), so unsortable headers can still emit `aria-sort=ascending|descending`.; Current tests cover sortable+desc and default unsortable+none (Program.cs lines 189-223), but do not cover unsortable+desc/asc to prevent this a11y drift.
Expected fix: Normalize sort state for unsortable headers (force `aria-sort` and exposed sort-direction to `none` when `Sortable` is false, or reject invalid constructor combinations), and add deterministic tests for the unsortable+non-none input case.
