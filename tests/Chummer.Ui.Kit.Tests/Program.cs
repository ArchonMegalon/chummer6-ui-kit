using Chummer.Ui.Kit.Preview;
using Chummer.Ui.Kit.Theming;
using Chummer.Ui.Kit.Tokens;
using Chummer.Ui.Kit.Adapters;
using Chummer.Ui.Kit.Blazor.Adapters;
using Chummer.Ui.Kit.Avalonia.Adapters;

var checks = new Action[]
{
    DefaultCanonContainsExpectedTokens,
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
        "dense_data",
        "explain_patterns",
        "chummer_cards",
        "offline_banner",
        "accessibility_state"
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
    var denseHeader = new DenseColumnHeader("initiative", "Initiative", DenseSortDirection.Descending, sortable: true, numeric: true);
    var denseRow = new DenseRowMetadata("row-7", "Mystic Adept", "6 edge remaining", RowEmphasis.Warning, ExplainAffinity.High, selected: true);
    var denseTable = new DenseTableSummary("Active effects", 14, 5);
    var explainChip = new ExplainChip("Explain modifiers", "3 facts", ExplainChipTone.Informative, interactive: true);
    var spiderCard = new SpiderStatusCard("Spider posture", "Escalation routed to GM host.", "Attention needed", CardTone.Warning, requiresAttention: true);
    var artifactCard = new ArtifactStatusCard("Alpha build", "Preview ready", "Signed artifact available for install.", CardTone.Success, previewReady: true);
    var offline = new OfflineBanner("Runtime Relay", isOffline: true);
    var accessibility = new AccessibilityState("assertive", busy: true, disabled: false, label: "Loading panel", describedBy: "panel-help");

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
            ["classes"] = "ShellWarning ShellCompact",
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
        BlazorUiKitAdapter.AdaptDenseColumnHeader(denseHeader),
        "chummer-dense-header",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "columnheader",
            ["data-key"] = "initiative",
            ["data-label"] = "Initiative",
            ["data-sort"] = "descending",
            ["data-sortable"] = "true",
            ["data-numeric"] = "true",
            ["class"] = "chummer-dense-header chummer-dense-header-sortable chummer-dense-header-numeric",
            ["aria-sort"] = "descending"
        },
        "blazor dense-header payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptDenseColumnHeader(denseHeader),
        "DenseColumnHeader",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "dense-column-header",
            ["classes"] = "DenseColumnHeader DenseColumnHeaderSortable DenseColumnHeaderNumeric",
            ["key"] = "initiative",
            ["label"] = "Initiative",
            ["sort"] = "Descending",
            ["sortable"] = "true",
            ["numeric"] = "true"
        },
        "avalonia dense-header payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptDenseRowMetadata(denseRow),
        "chummer-dense-row",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "row",
            ["data-row-key"] = "row-7",
            ["data-primary"] = "Mystic Adept",
            ["data-secondary"] = "6 edge remaining",
            ["data-emphasis"] = "warning",
            ["data-explain-affinity"] = "high",
            ["data-selected"] = "true",
            ["data-disabled"] = "false",
            ["class"] = "chummer-dense-row chummer-dense-row-warning chummer-dense-row-selected",
            ["aria-label"] = "Mystic Adept 6 edge remaining"
        },
        "blazor dense-row payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptDenseRowMetadata(denseRow),
        "DenseRow",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "dense-row",
            ["classes"] = "DenseRowWarning DenseRowSelected",
            ["row-key"] = "row-7",
            ["primary"] = "Mystic Adept",
            ["secondary"] = "6 edge remaining",
            ["emphasis"] = "Warning",
            ["explain-affinity"] = "High",
            ["selected"] = "true",
            ["disabled"] = "false"
        },
        "avalonia dense-row payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptDenseTableSummary(denseTable),
        "chummer-dense-table",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "table",
            ["data-label"] = "Active effects",
            ["data-row-count"] = "14",
            ["data-visible-columns"] = "5",
            ["data-compact"] = "true",
            ["data-zebra-stripes"] = "true",
            ["class"] = "chummer-dense-table chummer-dense-table-compact chummer-dense-table-striped",
            ["aria-label"] = "Active effects dense table"
        },
        "blazor dense-table payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptDenseTableSummary(denseTable),
        "DenseTable",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "dense-table",
            ["classes"] = "DenseTable DenseTableCompact DenseTableStriped",
            ["label"] = "Active effects",
            ["row-count"] = "14",
            ["visible-columns"] = "5",
            ["compact"] = "true",
            ["zebra-stripes"] = "true"
        },
        "avalonia dense-table payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptExplainChip(explainChip),
        "chummer-explain-chip",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "note",
            ["data-label"] = "Explain modifiers",
            ["data-evidence-count"] = "3 facts",
            ["data-tone"] = "informative",
            ["data-interactive"] = "true",
            ["class"] = "chummer-explain-chip chummer-explain-chip-informative chummer-explain-chip-actionable",
            ["aria-label"] = "Explain modifiers 3 facts"
        },
        "blazor explain-chip payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptExplainChip(explainChip),
        "ExplainChip",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "explain-chip",
            ["classes"] = "ExplainChipInformative ExplainChipInteractive",
            ["label"] = "Explain modifiers",
            ["evidence-count"] = "3 facts",
            ["tone"] = "Informative",
            ["interactive"] = "true"
        },
        "avalonia explain-chip payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptSpiderStatusCard(spiderCard),
        "chummer-status-card",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "article",
            ["data-title"] = "Spider posture",
            ["data-summary"] = "Escalation routed to GM host.",
            ["data-posture"] = "Attention needed",
            ["data-tone"] = "warning",
            ["data-requires-attention"] = "true",
            ["class"] = "chummer-status-card chummer-status-card-spider chummer-status-card-warning chummer-status-card-attention",
            ["aria-label"] = "Spider posture Attention needed"
        },
        "blazor spider-card payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptSpiderStatusCard(spiderCard),
        "SpiderStatusCard",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "spider-status-card",
            ["classes"] = "StatusCard StatusCardSpider StatusCardWarning StatusCardAttention",
            ["title"] = "Spider posture",
            ["summary"] = "Escalation routed to GM host.",
            ["posture"] = "Attention needed",
            ["tone"] = "Warning",
            ["requires-attention"] = "true"
        },
        "avalonia spider-card payload");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptArtifactStatusCard(artifactCard),
        "chummer-status-card",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "article",
            ["data-title"] = "Alpha build",
            ["data-status"] = "Preview ready",
            ["data-detail"] = "Signed artifact available for install.",
            ["data-tone"] = "success",
            ["data-preview-ready"] = "true",
            ["class"] = "chummer-status-card chummer-status-card-artifact chummer-status-card-success chummer-status-card-preview-ready",
            ["aria-label"] = "Alpha build Preview ready"
        },
        "blazor artifact-card payload");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptArtifactStatusCard(artifactCard),
        "ArtifactStatusCard",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "artifact-status-card",
            ["classes"] = "StatusCard StatusCardArtifact StatusCardSuccess StatusCardPreviewReady",
            ["title"] = "Alpha build",
            ["status"] = "Preview ready",
            ["detail"] = "Signed artifact available for install.",
            ["tone"] = "Success",
            ["preview-ready"] = "true"
        },
        "avalonia artifact-card payload");

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
