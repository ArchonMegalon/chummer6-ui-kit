# GitHub Codex Review

PR: https://github.com/ArchonMegalon/chummer6-ui-kit/pull/6

Findings:
- [high] src/Chummer.Ui.Kit/Adapters/Blazor/BlazorUiKitAdapter.cs [correctness] a11y-progress-toast-role-mismatch
Blazor progress toast emits role="status" together with aria-valuemin/aria-valuemax/aria-valuenow (BlazorUiKitAdapter.cs:227-231).; Deterministic tests lock that same payload shape (Program.cs:683-687).; Snapshot also bakes in the same combination (blazor.progress-toast.snapshot includes role=status and aria-valuenow/min/max).
Expected fix: Model progress with a valid accessibility contract (e.g., progressbar semantics with proper naming, or separate status/live message from numeric progress attrs) and update tests/snapshots to enforce it.
- [high] src/Chummer.Ui.Kit/Adapters/Blazor/BlazorUiKitAdapter.cs [tests] a11y-unnamed-region-landmarks
Blazor ResumeAffordance and GuidanceState use role="region" without aria-label/aria-labelledby (BlazorUiKitAdapter.cs:248-255, 270-277).; Tests/snapshots assert those region payloads but do not require accessible naming (Program.cs:721-847 and related snapshots).; Unnamed regions reduce landmark navigation quality and can cause ambiguous assistive-tech navigation when multiple regions exist.
Expected fix: Require accessible naming for region roles (explicit aria-label or aria-labelledby derived from title) and add deterministic assertions/snapshots that fail when region naming is absent.
- [medium] src/Chummer.Ui.Kit/Tokens/TokenCanon.cs [contracts] contract-no-loss-token-format-drift
Token canon default is "safecontinuation" (TokenCanon.cs:67).; Blazor emitted contract path is "safe-continuation" via ToContractCase mapping (BlazorUiKitAdapter.cs:294, 333-336).; Tests assert each independently but do not enforce canonical alignment between token default and emitted contract key shape (Program.cs:127, 893, 922).
Expected fix: Choose one canonical format for no-loss path (token + adapter outputs) and add an explicit alignment assertion so drift is caught automatically.
