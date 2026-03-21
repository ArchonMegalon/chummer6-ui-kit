using Chummer.Ui.Kit.Preview;
using Chummer.Ui.Kit.Theming;
using Chummer.Ui.Kit.Tokens;
using Chummer.Ui.Kit.Adapters;
using Chummer.Ui.Kit.Blazor.Adapters;
using Chummer.Ui.Kit.Avalonia.Adapters;

var checks = new Action[]
{
    DefaultCanonContainsExpectedTokens,
    DefaultCanonContainsB1ShellAndAccessibilityTokens,
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
        "chummer_cards"
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
    var denseRow = new DenseRowMetadata("row-17", DenseRowEmphasis.Highlighted, selected: true, explainAffinity: true);
    var explainChip = new ExplainChip("Explain armor stack", ExplainChipTone.Info, active: true, hint: "Includes temporary modifiers");
    var spiderCard = new SpiderStatusCard("Spider Relay", "Pending Approval", "Awaiting reviewer action", stale: true);
    var artifactCard = new ArtifactStatusCard("Run Log 13", "Dossier", "Published", available: false);

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
