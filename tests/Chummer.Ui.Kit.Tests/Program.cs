using Chummer.Ui.Kit.Preview;
using Chummer.Ui.Kit.Theming;
using Chummer.Ui.Kit.Tokens;
using Chummer.Ui.Kit.Adapters;
using Chummer.Ui.Kit.Blazor.Adapters;
using Chummer.Ui.Kit.Avalonia.Adapters;
using System.Text;

var checks = new Action[]
{
    DefaultCanonContainsExpectedTokens,
    DefaultCanonContainsB1ShellAndAccessibilityTokens,
    DefaultCanonContainsRoleTransitionAndResumeTokens,
    DefaultCanonContainsGuidanceAndLongRunningTokens,
    DefaultCanonContainsClassicDenseWorkbenchTokens,
    DefaultFallbackContrastRemainsReadable,
    AdapterDefaultsStayAlignedWithTokenCanon,
    AvaloniaCompatibilityAliasesRemainAvailable,
    CompilerProducesCssVariablesFromCanonAndOverrides,
    CompilerRejectsUnknownOverrideKeys,
    PreviewGalleryDefaultManifestCoversPackageCatalog,
    BlazorAndAvaloniaPayloadsStayDeterministic
};

foreach (var check in checks)
{
    check();
    Console.WriteLine($"PASS {check.Method.Name}");
}

return 0;

static void DefaultCanonContainsExpectedTokens()
{
    var canon = TokenCanon.CreateDefault();

    ExpectEqual("#F7F3EA", canon["color.background.canvas"], "canvas color");
    ExpectEqual("1rem", canon["space.400"], "space token");
    ExpectEqual("\"IBM Plex Sans\", \"Segoe UI\", sans-serif", canon["font.family.base"], "font family");
}

static void DefaultCanonContainsB1ShellAndAccessibilityTokens()
{
    var canon = TokenCanon.CreateDefault();
    var expectedKeys = new[]
    {
        "shell.chrome.root.class",
        "shell.chrome.role",
        "shell.chrome.default.tone",
        "shell.chrome.default.compact",
        "accessibility.state.root.class",
        "accessibility.state.role",
        "accessibility.state.live.default",
        "accessibility.state.busy.default",
        "accessibility.state.disabled.default"
    };

    foreach (var key in expectedKeys)
    {
        ExpectTrue(canon.Contains(key), $"default canon contains {key}");
    }

    ExpectEqual("chummer-shell", canon["shell.chrome.root.class"], "shell root class token");
    ExpectEqual("banner", canon["shell.chrome.role"], "shell role token");
    ExpectEqual("default", canon["shell.chrome.default.tone"], "shell default tone token");
    ExpectEqual("false", canon["shell.chrome.default.compact"], "shell compact default token");
    ExpectEqual("chummer-accessibility", canon["accessibility.state.root.class"], "accessibility root class token");
    ExpectEqual("status", canon["accessibility.state.role"], "accessibility role token");
    ExpectEqual("polite", canon["accessibility.state.live.default"], "accessibility live token");
    ExpectEqual("false", canon["accessibility.state.busy.default"], "accessibility busy default token");
    ExpectEqual("false", canon["accessibility.state.disabled.default"], "accessibility disabled default token");
}

static void DefaultCanonContainsRoleTransitionAndResumeTokens()
{
    var canon = TokenCanon.CreateDefault();
    var expectedKeys = new[]
    {
        "role.transition.root.class",
        "role.transition.phase.default",
        "progress.toast.root.class",
        "progress.toast.tone.default",
        "resume.affordance.root.class",
        "resume.affordance.recovery.default"
    };

    foreach (var key in expectedKeys)
    {
        ExpectTrue(canon.Contains(key), $"default canon contains {key}");
    }

    ExpectEqual("chummer-role-transition", canon["role.transition.root.class"], "role transition root class token");
    ExpectEqual("announced", canon["role.transition.phase.default"], "role transition phase token");
    ExpectEqual("chummer-progress-toast", canon["progress.toast.root.class"], "progress toast root class token");
    ExpectEqual("info", canon["progress.toast.tone.default"], "progress toast tone token");
    ExpectEqual("chummer-resume-affordance", canon["resume.affordance.root.class"], "resume affordance root class token");
    ExpectEqual("false", canon["resume.affordance.recovery.default"], "resume affordance recovery token");
}

static void DefaultCanonContainsGuidanceAndLongRunningTokens()
{
    var canon = TokenCanon.CreateDefault();
    var expectedKeys = new[]
    {
        "onboarding.state.root.class",
        "onboarding.state.primary.action.default",
        "empty.state.root.class",
        "empty.state.primary.action.default",
        "recovery.state.root.class",
        "recovery.state.primary.action.default",
        "first.run.state.root.class",
        "first.run.state.primary.action.default",
        "long.running.actions.root.class",
        "long.running.actions.no.loss.default",
        "long.running.actions.dictionary"
    };

    foreach (var key in expectedKeys)
    {
        ExpectTrue(canon.Contains(key), $"default canon contains {key}");
    }

    ExpectEqual("chummer-guidance-state", canon["onboarding.state.root.class"], "onboarding root class token");
    ExpectEqual("Create first item", canon["empty.state.primary.action.default"], "empty-state primary action token");
    ExpectEqual("Review recovery", canon["recovery.state.primary.action.default"], "recovery primary action token");
    ExpectEqual("Start walkthrough", canon["first.run.state.primary.action.default"], "first-run primary action token");
    ExpectEqual("chummer-action-controls", canon["long.running.actions.root.class"], "long-running actions root class token");
    ExpectEqual("safe-continuation", canon["long.running.actions.no.loss.default"], "long-running no-loss token");
    ExpectEqual("design/DR-129", canon["long.running.actions.dictionary"], "long-running dictionary token");
}

static void DefaultCanonContainsClassicDenseWorkbenchTokens()
{
    var canon = TokenCanon.CreateDefault();
    var expectedKeys = new[]
    {
        "classic.dense.workbench.preset.id",
        "classic.dense.workbench.flagship.avalonia.default",
        "noise.budget.compact.spacing.scale",
        "noise.budget.compact.header.scale",
        "noise.budget.banner.height.max",
        "noise.budget.badge.density.max",
        "noise.budget.field.height.compact",
        "noise.budget.button.height.compact",
        "workbench.layout.top.menu.enabled",
        "workbench.layout.toolstrip.enabled",
        "workbench.layout.tab.strip.density",
        "workbench.layout.list.detail.compact",
        "workbench.layout.inspector.forms.compact",
        "workbench.layout.status.strip.posture"
    };

    foreach (var key in expectedKeys)
    {
        ExpectTrue(canon.Contains(key), $"default canon contains {key}");
    }

    ExpectEqual("classic_dense_workbench", canon["classic.dense.workbench.preset.id"], "dense preset id token");
    ExpectEqual("true", canon["classic.dense.workbench.flagship.avalonia.default"], "avalonia flagship default token");
    ExpectEqual("compact", canon["workbench.layout.tab.strip.density"], "tab strip density token");
    ExpectEqual("permanent", canon["workbench.layout.status.strip.posture"], "status strip posture token");
}

static void DefaultFallbackContrastRemainsReadable()
{
    var canon = TokenCanon.CreateDefault();
    var panelBackground = canon["color.background.panel"];
    var canvasBackground = canon["color.background.canvas"];
    var primaryText = canon["color.text.primary"];
    var mutedText = canon["color.text.muted"];

    ExpectContrastAtLeast(primaryText, panelBackground, 7.0, "primary text on panel fallback contrast");
    ExpectContrastAtLeast(primaryText, canvasBackground, 7.0, "primary text on canvas fallback contrast");
    ExpectContrastAtLeast(mutedText, panelBackground, 4.5, "muted text on panel fallback contrast");
    ExpectContrastAtLeast(mutedText, canvasBackground, 4.5, "muted text on canvas fallback contrast");
}

static void AdapterDefaultsStayAlignedWithTokenCanon()
{
    var canon = TokenCanon.CreateDefault();

    var shell = new ShellChrome("Session", "Read only shell");
    var blazorShell = BlazorUiKitAdapter.AdaptShellChrome(shell);
    var avaloniaShell = AvaloniaUiKitAdapter.AdaptShellChrome(shell);

    ExpectEqual(canon["shell.chrome.root.class"], blazorShell.RootClass, "blazor shell root class aligns with canon");
    ExpectEqual("ShellRoot", avaloniaShell.RootClass, "avalonia shell root class preserves legacy contract");
    ExpectEqual(canon["shell.chrome.role"], blazorShell.Attributes["role"], "blazor shell role aligns with canon");
    ExpectEqual(canon["shell.chrome.default.tone"], blazorShell.Attributes["data-tone"], "blazor shell tone aligns with canon");
    ExpectEqual(canon["shell.chrome.default.compact"], blazorShell.Attributes["data-compact"], "blazor shell compact default aligns with canon");
    ExpectEqual(canon["shell.chrome.default.compact"], avaloniaShell.Attributes["compact"], "avalonia shell compact default aligns with canon");
    ExpectEqual("Default", avaloniaShell.Attributes["tone"], "avalonia shell tone aligns with canon");

    var accessibility = new AccessibilityState();
    var blazorA11y = BlazorUiKitAdapter.AdaptAccessibilityState(accessibility);
    var avaloniaA11y = AvaloniaUiKitAdapter.AdaptAccessibilityState(accessibility);

    ExpectEqual(canon["accessibility.state.root.class"], blazorA11y.RootClass, "blazor accessibility root class aligns with canon");
    ExpectEqual("AccessibilityState", avaloniaA11y.RootClass, "avalonia accessibility root class preserves legacy contract");
    ExpectEqual(canon["accessibility.state.role"], blazorA11y.Attributes["role"], "blazor accessibility role aligns with canon");
    ExpectEqual(canon["accessibility.state.role"], avaloniaA11y.Attributes["role"], "avalonia accessibility role aligns with canon");
    ExpectEqual(canon["accessibility.state.live.default"], blazorA11y.Attributes["aria-live"], "blazor accessibility live default aligns with canon");
    ExpectEqual(canon["accessibility.state.live.default"], avaloniaA11y.Attributes["live"], "avalonia accessibility live default aligns with canon");
    ExpectEqual(canon["accessibility.state.busy.default"], blazorA11y.Attributes["aria-busy"], "blazor accessibility busy default aligns with canon");
    ExpectEqual(canon["accessibility.state.busy.default"], avaloniaA11y.Attributes["is-busy"], "avalonia accessibility busy default aligns with canon");
    ExpectEqual(canon["accessibility.state.disabled.default"], blazorA11y.Attributes["aria-disabled"], "blazor accessibility disabled default aligns with canon");
    ExpectEqual(canon["accessibility.state.disabled.default"], avaloniaA11y.Attributes["is-disabled"], "avalonia accessibility disabled default aligns with canon");
}

static void AvaloniaCompatibilityAliasesRemainAvailable()
{
    var shell = AvaloniaUiKitAdapter.AdaptShellChrome(new ShellChrome("Session", "Body"));
    var accessibility = AvaloniaUiKitAdapter.AdaptAccessibilityState(new AccessibilityState());

    ExpectContains(shell.Attributes["classes"], "ShellRoot", "avalonia shell includes ShellRoot compatibility alias");
    ExpectContains(shell.Attributes["classes"], "ShellDefault", "avalonia shell includes tone selector classes");
    ExpectContains(accessibility.Attributes["classes"], "AccessibilityState", "avalonia accessibility includes AccessibilityState compatibility alias");
}

static void CompilerProducesCssVariablesFromCanonAndOverrides()
{
    var canon = TokenCanon.CreateDefault();
    var definition = new ThemeDefinition(
        "desert",
        canon,
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["color.accent.primary"] = "#A85C3B",
            ["radius.md"] = "0.75rem"
        });

    var compiled = new ThemeCompiler().Compile(definition);

    ExpectEqual("desert", compiled.Name, "theme name");
    ExpectContains(compiled.CssVariables, "--color-accent-primary: #A85C3B;", "accent css variable");
    ExpectContains(compiled.CssVariables, "--radius-md: 0.75rem;", "radius css variable");
    ExpectEqual("#A85C3B", compiled.ResolvedTokens["color.accent.primary"], "resolved accent token");
}

static void CompilerRejectsUnknownOverrideKeys()
{
    var canon = TokenCanon.CreateDefault();
    var definition = new ThemeDefinition(
        "broken",
        canon,
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["api.endpoint"] = "https://example.invalid"
        });

    try
    {
        _ = new ThemeCompiler().Compile(definition);
        throw new InvalidOperationException("Expected compiler to reject unknown override.");
    }
    catch (InvalidOperationException ex) when (ex.Message.Contains("Unknown token override", StringComparison.Ordinal))
    {
    }
}

static void PreviewGalleryDefaultManifestCoversPackageCatalog()
{
    var manifest = PreviewGalleryManifest.CreateDefault();
    var expectedCatalogKeys = new HashSet<string>(StringComparer.Ordinal)
    {
        "token_canon",
        "theme_compilation",
        "shell_chrome",
        "banner",
        "stale_state_badge",
        "approval_chip",
        "offline_banner",
        "accessibility_state",
        "dense_data",
        "explain_patterns",
        "chummer_cards",
        "transition_patterns",
        "guidance_states",
        "long_running_actions",
        "classic_dense_workbench"
    };

    ExpectEqual("Chummer.Ui.Kit", manifest.Ownership.Owner, "manifest owner");
    ExpectEqual("preview/gallery", manifest.Ownership.Route, "manifest route");
    ExpectContains(manifest.Ownership.Notes, "domain DTOs or HTTP clients", "ownership boundary");

    ExpectEqualInt(expectedCatalogKeys.Count, manifest.Previews.Count, "catalog key count");
    foreach (var key in expectedCatalogKeys)
    {
        ExpectTrue(manifest.Previews.ContainsKey(key), $"catalog preview registration for {key}");
    }
}

static void BlazorAndAvaloniaPayloadsStayDeterministic()
{
    var shell = new ShellChrome("Session", "Read only shell", ShellChromeTone.Warning, compact: true);
    var banner = new Banner("Read-only", "Data synced is paused.", BannerTone.Warning, pinned: true);
    var stale = new StaleStateBadge(StaleState.Failed, "Expired cache");
    var approval = new ApprovalChip(false, "Manager decision", "Alex");
    var offline = new OfflineBanner("Runtime Relay", isOffline: true);
    var accessibility = new AccessibilityState("assertive", busy: true, disabled: false, label: "Loading panel", describedBy: "panel-help");
    var denseHeader = new DenseTableHeader("initiative", "Initiative", sortable: true, sortDirection: DenseSortDirection.Desc);
    var denseHeaderDefault = new DenseTableHeader("name", "Name");
    var denseHeaderInvalidUnsortable = new DenseTableHeader("edge", "Edge", sortable: false, sortDirection: DenseSortDirection.Desc);
    var denseRow = new DenseRowMetadata("row-17", DenseRowEmphasis.Highlighted, selected: true, explainAffinity: true);
    var explainChip = new ExplainChip("Explain armor stack", ExplainChipTone.Info, active: true, hint: "Includes temporary modifiers");
    var spiderCard = new SpiderStatusCard("Spider Relay", "Pending Approval", "Awaiting reviewer action", stale: true);
    var artifactCard = new ArtifactStatusCard("Run Log 13", "Dossier", "Published", available: false);
    var roleTransition = new RoleTransition("Observer", "GM", RoleTransitionPhase.InProgress, requiresAcknowledgement: true, detail: "Awaiting owner handoff.");
    var progressToast = new ProgressToast("Syncing campaign", "Applying replay packets", 72, ProgressToastTone.Info, allowCancel: true, allowResume: true);
    var resumeAffordance = new ResumeAffordance("Resume run", "Checkpoint: Scene 4", "Resume from checkpoint", requiresRecovery: true, detail: "One conflict needs review.");
    var onboardingState = new GuidanceState(GuidanceStateKind.Onboarding, "Welcome to Chummer", "Connect your first campaign workspace.", "Start onboarding", "Skip for now");
    var emptyState = new GuidanceState(GuidanceStateKind.EmptyState, "No runs yet", "Create a run to begin tracking outcomes.", "Create run");
    var recoveryState = new GuidanceState(GuidanceStateKind.Recovery, "Recovery required", "A sync conflict needs review before publish.", "Review recovery", "Dismiss later", "Last sync stopped at packet 381.");
    var firstRunState = new GuidanceState(GuidanceStateKind.FirstRun, "First run checklist", "Confirm your profile, locale, and device role.", "Open checklist");
    var longRunningActions = new LongRunningActionControls(
        retryLabel: "Retry sync",
        cancelLabel: "Cancel run",
        rollbackLabel: "Rollback to checkpoint",
        safeContinuationLabel: "Continue safely",
        noLossPath: LongRunningControlId.SafeContinuation,
        retryEnabled: true,
        cancelEnabled: true,
        rollbackEnabled: true,
        safeContinuationEnabled: true,
        actionDictionaryReference: "design/DR-129",
        detail: "Prefer safe continuation when replay integrity is uncertain.");
    var classicDenseWorkbench = new ClassicDenseWorkbenchPreset();

    ExpectPayload(
        BlazorUiKitAdapter.AdaptDenseTableHeader(denseHeader),
        "chummer-dense-header",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "columnheader",
            ["data-key"] = "initiative",
            ["data-label"] = "Initiative",
            ["data-sortable"] = "true",
            ["data-sort-direction"] = "desc",
            ["aria-sort"] = "descending",
            ["class"] = "chummer-dense-header chummer-dense-header-sortable chummer-dense-sort-desc"
        },
        "blazor dense-header payload");
    ExpectPayload(
        BlazorUiKitAdapter.AdaptDenseTableHeader(denseHeaderDefault),
        "chummer-dense-header",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "columnheader",
            ["data-key"] = "name",
            ["data-label"] = "Name",
            ["data-sortable"] = "false",
            ["data-sort-direction"] = "none",
            ["aria-sort"] = "none",
            ["class"] = "chummer-dense-header chummer-dense-sort-none"
        },
        "blazor dense-header default payload");
    ExpectPayload(
        BlazorUiKitAdapter.AdaptDenseTableHeader(denseHeaderInvalidUnsortable),
        "chummer-dense-header",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "columnheader",
            ["data-key"] = "edge",
            ["data-label"] = "Edge",
            ["data-sortable"] = "false",
            ["data-sort-direction"] = "none",
            ["aria-sort"] = "none",
            ["class"] = "chummer-dense-header chummer-dense-sort-none"
        },
        "blazor dense-header unsortable-normalized payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptDenseTableHeader(denseHeader),
        "DenseHeader",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "dense-header",
            ["classes"] = "DenseHeader DenseHeaderSortable DenseSortDesc",
            ["key"] = "initiative",
            ["label"] = "Initiative",
            ["sortable"] = "true",
            ["sort-direction"] = "Desc"
        },
        "avalonia dense-header payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptDenseTableHeader(denseHeaderInvalidUnsortable),
        "DenseHeader",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "dense-header",
            ["classes"] = "DenseHeader DenseSortNone",
            ["key"] = "edge",
            ["label"] = "Edge",
            ["sortable"] = "false",
            ["sort-direction"] = "None"
        },
        "avalonia dense-header unsortable-normalized payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptDenseRowMetadata(denseRow),
        "chummer-dense-row",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "row",
            ["data-row-id"] = "row-17",
            ["data-emphasis"] = "highlighted",
            ["data-selected"] = "true",
            ["data-explain-affinity"] = "true",
            ["class"] = "chummer-dense-row chummer-dense-row-highlighted chummer-dense-row-selected chummer-dense-row-explain"
        },
        "blazor dense-row payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptDenseRowMetadata(denseRow),
        "DenseRow",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "dense-row",
            ["classes"] = "DenseRow DenseRowHighlighted DenseRowSelected DenseRowExplain",
            ["row-id"] = "row-17",
            ["emphasis"] = "Highlighted",
            ["selected"] = "true",
            ["explain-affinity"] = "true"
        },
        "avalonia dense-row payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptExplainChip(explainChip),
        "chummer-explain-chip",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "note",
            ["data-label"] = "Explain armor stack",
            ["data-tone"] = "info",
            ["data-active"] = "true",
            ["class"] = "chummer-explain-chip chummer-explain-chip-info chummer-explain-chip-active",
            ["aria-label"] = "Explain armor stack",
            ["data-hint"] = "Includes temporary modifiers"
        },
        "blazor explain-chip payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptExplainChip(explainChip),
        "ExplainChip",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "explain-chip",
            ["classes"] = "ExplainChip ExplainChipInfo ExplainChipActive",
            ["label"] = "Explain armor stack",
            ["tone"] = "Info",
            ["active"] = "true",
            ["hint"] = "Includes temporary modifiers"
        },
        "avalonia explain-chip payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptSpiderStatusCard(spiderCard),
        "chummer-card-spider",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "group",
            ["data-title"] = "Spider Relay",
            ["data-status"] = "Pending Approval",
            ["data-summary"] = "Awaiting reviewer action",
            ["data-stale"] = "true",
            ["class"] = "chummer-card chummer-card-spider chummer-card-stale",
            ["aria-label"] = "Spider Relay status card"
        },
        "blazor spider-card payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptSpiderStatusCard(spiderCard),
        "SpiderStatusCard",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "spider-card",
            ["classes"] = "SpiderStatusCard SpiderStatusCardStale",
            ["title"] = "Spider Relay",
            ["status"] = "Pending Approval",
            ["summary"] = "Awaiting reviewer action",
            ["stale"] = "true"
        },
        "avalonia spider-card payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptArtifactStatusCard(artifactCard),
        "chummer-card-artifact",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "group",
            ["data-title"] = "Run Log 13",
            ["data-artifact-type"] = "Dossier",
            ["data-status"] = "Published",
            ["data-available"] = "false",
            ["class"] = "chummer-card chummer-card-artifact chummer-card-unavailable",
            ["aria-label"] = "Run Log 13 artifact card"
        },
        "blazor artifact-card payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptArtifactStatusCard(artifactCard),
        "ArtifactStatusCard",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "artifact-card",
            ["classes"] = "ArtifactStatusCard ArtifactStatusCardUnavailable",
            ["title"] = "Run Log 13",
            ["artifact-type"] = "Dossier",
            ["status"] = "Published",
            ["available"] = "false"
        },
        "avalonia artifact-card payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptShellChrome(shell),
        "chummer-shell",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "banner",
            ["aria-label"] = "Session shell chrome",
            ["data-title"] = "Session",
            ["data-body"] = "Read only shell",
            ["data-tone"] = "warning",
            ["data-compact"] = "true",
            ["class"] = "chummer-shell chummer-shell-warning chummer-shell-compact"
        },
        "blazor shell payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptShellChrome(shell),
        "ShellRoot",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "shell",
            ["classes"] = "ShellRoot ShellWarning ShellCompact",
            ["title"] = "Session",
            ["body"] = "Read only shell",
            ["tone"] = "Warning",
            ["compact"] = "true"
        },
        "avalonia shell payload");

    var blazorBanner = BlazorUiKitAdapter.AdaptBanner(banner);
    var avaloniaBanner = AvaloniaUiKitAdapter.AdaptBanner(banner);
    ExpectPayload(
        blazorBanner,
        "chummer-banner chummer-banner-warning",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "status",
            ["data-tone"] = "warning",
            ["data-title"] = "Read-only",
            ["class"] = "chummer-banner chummer-banner-pinned",
            ["data-body"] = "Data synced is paused.",
            ["data-pinned"] = "true",
            ["aria-label"] = "Read-only"
        },
        "blazor banner payload");
    ExpectPayload(
        avaloniaBanner,
        "chummer-banner chummer-banner-warning",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "status",
            ["data-tone"] = "warning",
            ["data-title"] = "Read-only",
            ["part"] = "banner",
            ["classes"] = "BannerWarning BannerPinned",
            ["headline"] = "Read-only",
            ["body"] = "Data synced is paused.",
            ["tone"] = "Warning",
            ["pinned"] = "true"
        },
        "avalonia banner payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptStaleStateBadge(stale),
        "chummer-badge",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "note",
            ["data-state"] = "failed",
            ["data-detail"] = "Expired cache",
            ["class"] = "chummer-badge chummer-badge-failed",
            ["aria-label"] = "Expired cache"
        },
        "blazor stale-state payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptStaleStateBadge(stale),
        "StaleBadge",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "stale-badge",
            ["classes"] = "StaleBadgeFailed",
            ["state"] = "Failed",
            ["state-detail"] = "Expired cache"
        },
        "avalonia stale-state payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptApprovalChip(approval),
        "chummer-chip",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "status",
            ["data-approved"] = "false",
            ["data-approver"] = "Alex",
            ["class"] = "chummer-chip chummer-chip-pending",
            ["aria-label"] = "Manager decision"
        },
        "blazor approval-chip payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptApprovalChip(approval),
        "ApprovalChip",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "approval-chip",
            ["classes"] = "ApprovalChipPending",
            ["text"] = "Manager decision",
            ["approved"] = "false",
            ["label"] = "Manager decision",
            ["approver"] = "Alex"
        },
        "avalonia approval-chip payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptOfflineBanner(offline),
        "chummer-offline",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "alert",
            ["aria-live"] = "polite",
            ["data-service"] = "Runtime Relay",
            ["data-offline"] = "true",
            ["class"] = "chummer-offline chummer-offline-on",
            ["aria-label"] = "Runtime Relay is offline"
        },
        "blazor offline-banner payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptOfflineBanner(offline),
        "OfflineBanner",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "offline-banner",
            ["classes"] = "OfflineBannerOffline",
            ["service"] = "Runtime Relay",
            ["offline"] = "true"
        },
        "avalonia offline-banner payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptAccessibilityState(accessibility),
        "chummer-accessibility",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "status",
            ["aria-busy"] = "true",
            ["aria-disabled"] = "false",
            ["aria-live"] = "assertive",
            ["aria-label"] = "Loading panel",
            ["aria-describedby"] = "panel-help"
        },
        "blazor accessibility payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptAccessibilityState(accessibility),
        "AccessibilityState",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "a11y",
            ["classes"] = "AccessibilityState",
            ["role"] = "status",
            ["is-busy"] = "true",
            ["is-disabled"] = "false",
            ["live"] = "assertive",
            ["label"] = "Loading panel",
            ["described-by"] = "panel-help"
        },
        "avalonia accessibility payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptRoleTransition(roleTransition),
        "chummer-role-transition",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "status",
            ["aria-live"] = "polite",
            ["data-from-role"] = "Observer",
            ["data-to-role"] = "GM",
            ["data-phase"] = "inprogress",
            ["data-requires-ack"] = "true",
            ["class"] = "chummer-role-transition chummer-role-transition-inprogress",
            ["data-detail"] = "Awaiting owner handoff."
        },
        "blazor role-transition payload");
    ExpectPayloadSnapshot(
        BlazorUiKitAdapter.AdaptRoleTransition(roleTransition),
        "blazor.role-transition.snapshot",
        "blazor role-transition snapshot");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptRoleTransition(roleTransition),
        "RoleTransition",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "role-transition",
            ["classes"] = "RoleTransition RoleTransitionInProgress",
            ["from-role"] = "Observer",
            ["to-role"] = "GM",
            ["phase"] = "InProgress",
            ["requires-ack"] = "true",
            ["detail"] = "Awaiting owner handoff."
        },
        "avalonia role-transition payload");
    ExpectPayloadSnapshot(
        AvaloniaUiKitAdapter.AdaptRoleTransition(roleTransition),
        "avalonia.role-transition.snapshot",
        "avalonia role-transition snapshot");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptProgressToast(progressToast),
        "chummer-progress-toast",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "progressbar",
            ["aria-live"] = "polite",
            ["aria-label"] = "Syncing campaign",
            ["aria-valuemin"] = "0",
            ["aria-valuemax"] = "100",
            ["aria-valuenow"] = "72",
            ["data-title"] = "Syncing campaign",
            ["data-progress-label"] = "Applying replay packets",
            ["data-progress-percent"] = "72",
            ["data-tone"] = "info",
            ["data-allow-cancel"] = "true",
            ["data-allow-resume"] = "true",
            ["class"] = "chummer-progress-toast chummer-progress-toast-info"
        },
        "blazor progress-toast payload");
    ExpectPayloadSnapshot(
        BlazorUiKitAdapter.AdaptProgressToast(progressToast),
        "blazor.progress-toast.snapshot",
        "blazor progress-toast snapshot");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptProgressToast(progressToast),
        "ProgressToast",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "progress-toast",
            ["classes"] = "ProgressToast ProgressToastInfo",
            ["title"] = "Syncing campaign",
            ["progress-label"] = "Applying replay packets",
            ["progress-percent"] = "72",
            ["tone"] = "Info",
            ["allow-cancel"] = "true",
            ["allow-resume"] = "true"
        },
        "avalonia progress-toast payload");
    ExpectPayloadSnapshot(
        AvaloniaUiKitAdapter.AdaptProgressToast(progressToast),
        "avalonia.progress-toast.snapshot",
        "avalonia progress-toast snapshot");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptResumeAffordance(resumeAffordance),
        "chummer-resume-affordance",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "region",
            ["aria-live"] = "polite",
            ["aria-label"] = "Resume run",
            ["data-title"] = "Resume run",
            ["data-checkpoint"] = "Checkpoint: Scene 4",
            ["data-resume-action"] = "Resume from checkpoint",
            ["data-requires-recovery"] = "true",
            ["class"] = "chummer-resume-affordance chummer-resume-affordance-recovery",
            ["data-detail"] = "One conflict needs review."
        },
        "blazor resume-affordance payload");
    ExpectPayloadSnapshot(
        BlazorUiKitAdapter.AdaptResumeAffordance(resumeAffordance),
        "blazor.resume-affordance.snapshot",
        "blazor resume-affordance snapshot");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptResumeAffordance(resumeAffordance),
        "ResumeAffordance",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "resume-affordance",
            ["classes"] = "ResumeAffordance ResumeAffordanceRecovery",
            ["title"] = "Resume run",
            ["checkpoint"] = "Checkpoint: Scene 4",
            ["resume-action"] = "Resume from checkpoint",
            ["requires-recovery"] = "true",
            ["detail"] = "One conflict needs review."
        },
        "avalonia resume-affordance payload");
    ExpectPayloadSnapshot(
        AvaloniaUiKitAdapter.AdaptResumeAffordance(resumeAffordance),
        "avalonia.resume-affordance.snapshot",
        "avalonia resume-affordance snapshot");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptGuidanceState(onboardingState),
        "chummer-guidance-state",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "region",
            ["aria-live"] = "polite",
            ["aria-label"] = "Welcome to Chummer",
            ["data-state-kind"] = "onboarding",
            ["data-title"] = "Welcome to Chummer",
            ["data-body"] = "Connect your first campaign workspace.",
            ["data-primary-action"] = "Start onboarding",
            ["data-secondary-action"] = "Skip for now",
            ["class"] = "chummer-guidance-state chummer-guidance-state-onboarding"
        },
        "blazor onboarding guidance payload");
    ExpectPayloadSnapshot(
        BlazorUiKitAdapter.AdaptGuidanceState(onboardingState),
        "blazor.guidance-onboarding.snapshot",
        "blazor onboarding guidance snapshot");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptGuidanceState(onboardingState),
        "GuidanceState",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "guidance-state",
            ["classes"] = "GuidanceState GuidanceStateOnboarding",
            ["state-kind"] = "Onboarding",
            ["title"] = "Welcome to Chummer",
            ["body"] = "Connect your first campaign workspace.",
            ["primary-action"] = "Start onboarding",
            ["secondary-action"] = "Skip for now"
        },
        "avalonia onboarding guidance payload");
    ExpectPayloadSnapshot(
        AvaloniaUiKitAdapter.AdaptGuidanceState(onboardingState),
        "avalonia.guidance-onboarding.snapshot",
        "avalonia onboarding guidance snapshot");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptGuidanceState(emptyState),
        "chummer-guidance-state",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "region",
            ["aria-live"] = "polite",
            ["aria-label"] = "No runs yet",
            ["data-state-kind"] = "empty-state",
            ["data-title"] = "No runs yet",
            ["data-body"] = "Create a run to begin tracking outcomes.",
            ["data-primary-action"] = "Create run",
            ["class"] = "chummer-guidance-state chummer-guidance-state-empty-state"
        },
        "blazor empty-state guidance payload");
    ExpectPayloadSnapshot(
        BlazorUiKitAdapter.AdaptGuidanceState(emptyState),
        "blazor.guidance-empty-state.snapshot",
        "blazor empty-state guidance snapshot");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptGuidanceState(emptyState),
        "GuidanceState",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "guidance-state",
            ["classes"] = "GuidanceState GuidanceStateEmptyState",
            ["state-kind"] = "EmptyState",
            ["title"] = "No runs yet",
            ["body"] = "Create a run to begin tracking outcomes.",
            ["primary-action"] = "Create run"
        },
        "avalonia empty-state guidance payload");
    ExpectPayloadSnapshot(
        AvaloniaUiKitAdapter.AdaptGuidanceState(emptyState),
        "avalonia.guidance-empty-state.snapshot",
        "avalonia empty-state guidance snapshot");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptGuidanceState(recoveryState),
        "chummer-guidance-state",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "region",
            ["aria-live"] = "assertive",
            ["aria-label"] = "Recovery required",
            ["data-state-kind"] = "recovery",
            ["data-title"] = "Recovery required",
            ["data-body"] = "A sync conflict needs review before publish.",
            ["data-primary-action"] = "Review recovery",
            ["data-secondary-action"] = "Dismiss later",
            ["data-detail"] = "Last sync stopped at packet 381.",
            ["class"] = "chummer-guidance-state chummer-guidance-state-recovery"
        },
        "blazor recovery guidance payload");
    ExpectPayloadSnapshot(
        BlazorUiKitAdapter.AdaptGuidanceState(recoveryState),
        "blazor.guidance-recovery.snapshot",
        "blazor recovery guidance snapshot");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptGuidanceState(recoveryState),
        "GuidanceState",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "guidance-state",
            ["classes"] = "GuidanceState GuidanceStateRecovery",
            ["state-kind"] = "Recovery",
            ["title"] = "Recovery required",
            ["body"] = "A sync conflict needs review before publish.",
            ["primary-action"] = "Review recovery",
            ["secondary-action"] = "Dismiss later",
            ["detail"] = "Last sync stopped at packet 381."
        },
        "avalonia recovery guidance payload");
    ExpectPayloadSnapshot(
        AvaloniaUiKitAdapter.AdaptGuidanceState(recoveryState),
        "avalonia.guidance-recovery.snapshot",
        "avalonia recovery guidance snapshot");

    ExpectPayloadSnapshot(
        BlazorUiKitAdapter.AdaptGuidanceState(firstRunState),
        "blazor.guidance-first-run.snapshot",
        "blazor first-run guidance snapshot");
    ExpectPayloadSnapshot(
        AvaloniaUiKitAdapter.AdaptGuidanceState(firstRunState),
        "avalonia.guidance-first-run.snapshot",
        "avalonia first-run guidance snapshot");

    var blazorLongRunning = BlazorUiKitAdapter.AdaptLongRunningActionControls(longRunningActions);
    var avaloniaLongRunning = AvaloniaUiKitAdapter.AdaptLongRunningActionControls(longRunningActions);

    ExpectPayload(
        blazorLongRunning,
        "chummer-action-controls",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "group",
            ["aria-live"] = "polite",
            ["data-action-dictionary"] = "design/DR-129",
            ["data-no-loss-path"] = "safe-continuation",
            ["data-retry-label"] = "Retry sync",
            ["data-retry-enabled"] = "true",
            ["data-retry-lossless"] = "false",
            ["data-cancel-label"] = "Cancel run",
            ["data-cancel-enabled"] = "true",
            ["data-cancel-lossless"] = "false",
            ["data-rollback-label"] = "Rollback to checkpoint",
            ["data-rollback-enabled"] = "true",
            ["data-rollback-lossless"] = "false",
            ["data-safe-continuation-label"] = "Continue safely",
            ["data-safe-continuation-enabled"] = "true",
            ["data-safe-continuation-lossless"] = "true",
            ["data-detail"] = "Prefer safe continuation when replay integrity is uncertain.",
            ["class"] = "chummer-action-controls"
        },
        "blazor long-running controls payload");
    ExpectPayloadSnapshot(
        blazorLongRunning,
        "blazor.long-running-actions.snapshot",
        "blazor long-running actions snapshot");
    ExpectPayload(
        avaloniaLongRunning,
        "LongRunningActionControls",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "action-controls",
            ["classes"] = "LongRunningActionControls",
            ["action-dictionary"] = "design/DR-129",
            ["no-loss-path"] = "safe-continuation",
            ["retry-label"] = "Retry sync",
            ["retry-enabled"] = "true",
            ["retry-lossless"] = "false",
            ["cancel-label"] = "Cancel run",
            ["cancel-enabled"] = "true",
            ["cancel-lossless"] = "false",
            ["rollback-label"] = "Rollback to checkpoint",
            ["rollback-enabled"] = "true",
            ["rollback-lossless"] = "false",
            ["safe-continuation-label"] = "Continue safely",
            ["safe-continuation-enabled"] = "true",
            ["safe-continuation-lossless"] = "true",
            ["detail"] = "Prefer safe continuation when replay integrity is uncertain."
        },
        "avalonia long-running controls payload");
    ExpectPayloadSnapshot(
        avaloniaLongRunning,
        "avalonia.long-running-actions.snapshot",
        "avalonia long-running actions snapshot");

    ExpectEqual(blazorLongRunning.Attributes["data-retry-label"], avaloniaLongRunning.Attributes["retry-label"], "retry label parity across adapters");
    ExpectEqual(blazorLongRunning.Attributes["data-cancel-label"], avaloniaLongRunning.Attributes["cancel-label"], "cancel label parity across adapters");
    ExpectEqual(blazorLongRunning.Attributes["data-rollback-label"], avaloniaLongRunning.Attributes["rollback-label"], "rollback label parity across adapters");
    ExpectEqual(blazorLongRunning.Attributes["data-safe-continuation-label"], avaloniaLongRunning.Attributes["safe-continuation-label"], "safe-continuation label parity across adapters");
    ExpectEqual(blazorLongRunning.Attributes["data-no-loss-path"], avaloniaLongRunning.Attributes["no-loss-path"], "no-loss path parity across adapters");
    ExpectEqual(TokenCanon.CreateDefault()["long.running.actions.no.loss.default"], blazorLongRunning.Attributes["data-no-loss-path"], "blazor no-loss path aligns with canon token");
    ExpectEqual(TokenCanon.CreateDefault()["long.running.actions.no.loss.default"], avaloniaLongRunning.Attributes["no-loss-path"], "avalonia no-loss path aligns with canon token");
    ExpectSingleNoLossPath(blazorLongRunning.Attributes, "data-", "blazor long-running controls");
    ExpectSingleNoLossPath(avaloniaLongRunning.Attributes, string.Empty, "avalonia long-running controls");

    var blazorDenseWorkbench = BlazorUiKitAdapter.AdaptClassicDenseWorkbenchPreset(classicDenseWorkbench);
    var avaloniaDenseWorkbench = AvaloniaUiKitAdapter.AdaptClassicDenseWorkbenchPreset(classicDenseWorkbench);

    ExpectPayload(
        blazorDenseWorkbench,
        "chummer-classic-dense-workbench",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "region",
            ["aria-label"] = "Classic dense workbench preset",
            ["data-preset-id"] = "classic_dense_workbench",
            ["data-top-menu-bar-enabled"] = "true",
            ["data-toolstrip-enabled"] = "true",
            ["data-tab-strip-density"] = "compact",
            ["data-compact-list-detail-panes"] = "true",
            ["data-compact-inspector-forms"] = "true",
            ["data-status-strip-posture"] = "permanent",
            ["data-compact-spacing-scale"] = "0.85",
            ["data-compact-header-scale"] = "0.90",
            ["data-banner-height-ceiling"] = "2.50rem",
            ["data-badge-density-ceiling"] = "3",
            ["data-compact-field-height"] = "1.875rem",
            ["data-compact-button-height"] = "1.875rem",
            ["data-flagship-default-avalonia"] = "true",
            ["class"] = "chummer-classic-dense-workbench"
        },
        "blazor classic dense-workbench payload");
    ExpectPayloadSnapshot(
        blazorDenseWorkbench,
        "blazor.classic-dense-workbench.snapshot",
        "blazor classic dense-workbench snapshot");

    ExpectPayload(
        avaloniaDenseWorkbench,
        "ClassicDenseWorkbench",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "classic-dense-workbench",
            ["classes"] = "ClassicDenseWorkbench FlagshipDesktopDefault",
            ["preset-id"] = "classic_dense_workbench",
            ["top-menu-bar-enabled"] = "true",
            ["toolstrip-enabled"] = "true",
            ["tab-strip-density"] = "compact",
            ["compact-list-detail-panes"] = "true",
            ["compact-inspector-forms"] = "true",
            ["status-strip-posture"] = "permanent",
            ["compact-spacing-scale"] = "0.85",
            ["compact-header-scale"] = "0.90",
            ["banner-height-ceiling"] = "2.50rem",
            ["badge-density-ceiling"] = "3",
            ["compact-field-height"] = "1.875rem",
            ["compact-button-height"] = "1.875rem",
            ["flagship-default-avalonia"] = "true"
        },
        "avalonia classic dense-workbench payload");
    ExpectPayloadSnapshot(
        avaloniaDenseWorkbench,
        "avalonia.classic-dense-workbench.snapshot",
        "avalonia classic dense-workbench snapshot");

    ExpectEqual("true", avaloniaDenseWorkbench.Attributes["flagship-default-avalonia"], "avalonia classic dense-workbench default posture");
    ExpectContains(avaloniaDenseWorkbench.Attributes["classes"], "FlagshipDesktopDefault", "avalonia classic dense-workbench flagship class");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-compact-spacing-scale"]) <= 0.85d, "blazor compact spacing scale stays within dense noise budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-compact-header-scale"]) <= 0.90d, "blazor compact header scale stays within dense noise budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-badge-density-ceiling"]) <= 3d, "blazor badge density ceiling stays within dense noise budget");
    ExpectTrue(ParseRemValue(blazorDenseWorkbench.Attributes["data-banner-height-ceiling"]) <= 2.50d, "blazor banner height ceiling stays within dense noise budget");
    ExpectTrue(ParseRemValue(blazorDenseWorkbench.Attributes["data-compact-field-height"]) <= 1.875d, "blazor compact field height stays within dense noise budget");
    ExpectTrue(ParseRemValue(blazorDenseWorkbench.Attributes["data-compact-button-height"]) <= 1.875d, "blazor compact button height stays within dense noise budget");
}

static void ExpectPayloadSnapshot(UiAdapterPayload payload, string snapshotFileName, string scenario)
{
    var snapshotPath = Path.Combine(AppContext.BaseDirectory, "Snapshots", snapshotFileName);
    if (!File.Exists(snapshotPath))
    {
        throw new InvalidOperationException($"Expected snapshot file for {scenario} at '{snapshotPath}'.");
    }

    var actual = SerializePayload(payload);
    var expected = File.ReadAllText(snapshotPath, Encoding.UTF8)
        .Replace("\r\n", "\n", StringComparison.Ordinal)
        .TrimEnd('\n');

    ExpectEqual(expected, actual, $"{scenario} payload snapshot");
}

static string SerializePayload(UiAdapterPayload payload)
{
    var lines = new List<string>
    {
        $"root={payload.RootClass}"
    };

    foreach (var pair in payload.Attributes.OrderBy(static pair => pair.Key, StringComparer.Ordinal))
    {
        lines.Add($"{pair.Key}={pair.Value}");
    }

    return string.Join('\n', lines);
}

static void ExpectPayload(
    UiAdapterPayload actualPayload,
    string expectedRootClass,
    IReadOnlyDictionary<string, string> expectedAttributes,
    string scenario)
{
    ExpectEqual(expectedRootClass, actualPayload.RootClass, $"{scenario} root class");
    ExpectEqualInt(expectedAttributes.Count, actualPayload.Attributes.Count, $"{scenario} attribute count");

    foreach (var pair in expectedAttributes)
    {
        ExpectTrue(actualPayload.Attributes.ContainsKey(pair.Key), $"{scenario} contains attribute {pair.Key}");
        ExpectEqual(pair.Value, actualPayload.Attributes[pair.Key], $"{scenario} attribute {pair.Key}");
    }
}

static void ExpectEqual(string expected, string actual, string scenario)
{
    if (!string.Equals(expected, actual, StringComparison.Ordinal))
    {
        throw new InvalidOperationException($"Expected {scenario} to be '{expected}' but was '{actual}'.");
    }
}

static void ExpectEqualInt(int expected, int actual, string scenario)
{
    if (expected != actual)
    {
        throw new InvalidOperationException($"Expected {scenario} to be '{expected}' but was '{actual}'.");
    }
}

static void ExpectContains(string source, string fragment, string scenario)
{
    if (!source.Contains(fragment, StringComparison.Ordinal))
    {
        throw new InvalidOperationException($"Expected {scenario} to contain '{fragment}'.");
    }
}

static void ExpectTrue(bool condition, string scenario)
{
    if (!condition)
    {
        throw new InvalidOperationException($"Expected {scenario}.");
    }
}

static void ExpectSingleNoLossPath(IReadOnlyDictionary<string, string> attributes, string prefix, string scenario)
{
    var keys = new[]
    {
        $"{prefix}retry-lossless",
        $"{prefix}cancel-lossless",
        $"{prefix}rollback-lossless",
        $"{prefix}safe-continuation-lossless"
    };

    var trueCount = 0;
    foreach (var key in keys)
    {
        ExpectTrue(attributes.ContainsKey(key), $"{scenario} contains {key}");
        if (string.Equals(attributes[key], "true", StringComparison.Ordinal))
        {
            trueCount++;
        }
    }

    if (trueCount != 1)
    {
        throw new InvalidOperationException($"Expected {scenario} to expose exactly one no-loss path but found {trueCount}.");
    }
}

static void ExpectContrastAtLeast(string foregroundHex, string backgroundHex, double minimumRatio, string scenario)
{
    var ratio = ContrastRatio(foregroundHex, backgroundHex);
    if (ratio < minimumRatio)
    {
        throw new InvalidOperationException(
            $"Expected {scenario} to be >= {minimumRatio.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture)} but was {ratio.ToString("0.##", System.Globalization.CultureInfo.InvariantCulture)}.");
    }
}

static double ParseInvariantDouble(string value)
{
    if (!double.TryParse(value, System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out var parsed))
    {
        throw new InvalidOperationException($"Expected numeric value but received '{value}'.");
    }

    return parsed;
}

static double ParseRemValue(string value)
{
    if (!value.EndsWith("rem", StringComparison.Ordinal))
    {
        throw new InvalidOperationException($"Expected rem value but received '{value}'.");
    }

    return ParseInvariantDouble(value[..^3]);
}

static double ContrastRatio(string firstHex, string secondHex)
{
    var first = RelativeLuminance(ParseHexColor(firstHex));
    var second = RelativeLuminance(ParseHexColor(secondHex));
    var lighter = Math.Max(first, second);
    var darker = Math.Min(first, second);
    return (lighter + 0.05) / (darker + 0.05);
}

static (double Red, double Green, double Blue) ParseHexColor(string hex)
{
    if (string.IsNullOrWhiteSpace(hex))
    {
        throw new InvalidOperationException("Expected non-empty hex color value.");
    }

    var value = hex.Trim();
    if (value.Length != 7 || value[0] != '#')
    {
        throw new InvalidOperationException($"Expected color '{hex}' in #RRGGBB format.");
    }

    static double ParseChannel(string source, int offset)
    {
        var byteValue = Convert.ToByte(source.Substring(offset, 2), 16);
        return byteValue / 255d;
    }

    return (ParseChannel(value, 1), ParseChannel(value, 3), ParseChannel(value, 5));
}

static double RelativeLuminance((double Red, double Green, double Blue) color)
{
    static double Expand(double channel) =>
        channel <= 0.03928
            ? channel / 12.92
            : Math.Pow((channel + 0.055) / 1.055, 2.4);

    var red = Expand(color.Red);
    var green = Expand(color.Green);
    var blue = Expand(color.Blue);
    return (0.2126 * red) + (0.7152 * green) + (0.0722 * blue);
}
