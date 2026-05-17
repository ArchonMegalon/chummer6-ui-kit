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
    DefaultCanonContainsRunboardAndSourceAnchorTokens,
    NewPrimitiveGuardsFailClosed,
    DefaultCanonContainsClassicDenseWorkbenchTokens,
    FlagshipClassicDenseWorkbenchDefaultIsTokenBacked,
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
        "error.state.root.class",
        "error.state.primary.action.default",
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
    ExpectEqual("Review error", canon["error.state.primary.action.default"], "error primary action token");
    ExpectEqual("Create first item", canon["empty.state.primary.action.default"], "empty-state primary action token");
    ExpectEqual("Review recovery", canon["recovery.state.primary.action.default"], "recovery primary action token");
    ExpectEqual("Start walkthrough", canon["first.run.state.primary.action.default"], "first-run primary action token");
    ExpectEqual("chummer-action-controls", canon["long.running.actions.root.class"], "long-running actions root class token");
    ExpectEqual("safe-continuation", canon["long.running.actions.no.loss.default"], "long-running no-loss token");
    ExpectEqual("design/DR-129", canon["long.running.actions.dictionary"], "long-running dictionary token");
}

static void DefaultCanonContainsRunboardAndSourceAnchorTokens()
{
    var canon = TokenCanon.CreateDefault();
    var expectedKeys = new[]
    {
        "action.budget.bar.root.class",
        "action.budget.bar.kind.default",
        "action.budget.bar.emphasis.default",
        "condition.effect.chip.root.class",
        "condition.effect.chip.kind.default",
        "condition.effect.chip.tone.default",
        "source.anchor.drawer.root.class",
        "source.anchor.drawer.open.default",
        "runboard.card.root.class",
        "runboard.card.priority.default"
    };

    foreach (var key in expectedKeys)
    {
        ExpectTrue(canon.Contains(key), $"default canon contains {key}");
    }

    ExpectEqual("chummer-action-budget-bar", canon["action.budget.bar.root.class"], "action-budget root class token");
    ExpectEqual("major", canon["action.budget.bar.kind.default"], "action-budget kind token");
    ExpectEqual("steady", canon["action.budget.bar.emphasis.default"], "action-budget emphasis token");
    ExpectEqual("chummer-condition-effect-chip", canon["condition.effect.chip.root.class"], "condition/effect root class token");
    ExpectEqual("effect", canon["condition.effect.chip.kind.default"], "condition/effect kind token");
    ExpectEqual("neutral", canon["condition.effect.chip.tone.default"], "condition/effect tone token");
    ExpectEqual("chummer-source-anchor-drawer", canon["source.anchor.drawer.root.class"], "source-anchor drawer root class token");
    ExpectEqual("false", canon["source.anchor.drawer.open.default"], "source-anchor drawer open token");
    ExpectEqual("chummer-runboard-card", canon["runboard.card.root.class"], "runboard root class token");
    ExpectEqual("standard", canon["runboard.card.priority.default"], "runboard priority token");
}

static void NewPrimitiveGuardsFailClosed()
{
    ExpectThrows<ArgumentOutOfRangeException>(
        () => _ = new ActionBudgetBar("Major", ActionBudgetKind.Major, available: 3, maximum: 2),
        "action-budget available count above maximum fails closed");
    ExpectThrows<ArgumentOutOfRangeException>(
        () => _ = new ActionBudgetBar("Major", ActionBudgetKind.Major, available: -1, maximum: 2),
        "action-budget negative available count fails closed");
    ExpectThrows<ArgumentOutOfRangeException>(
        () => _ = new ConditionEffectChip("Prone", stackCount: 0),
        "condition/effect chip zero stack count fails closed");
    ExpectThrows<ArgumentException>(
        () => _ = new SourceAnchorDrawer("Suppressive fire", "SR6", "p. 114", "bad anchor"),
        "source-anchor drawer whitespace anchor id fails closed");
    ExpectThrows<ArgumentOutOfRangeException>(
        () => _ = new RunboardCard("Scene pressure", "Escalates next round.", itemCount: -1),
        "runboard negative item count fails closed");
    ExpectThrows<ArgumentException>(
        () => _ = new ClassicDenseWorkbenchPreset(
            proofFamilyIds: new[]
            {
                "family:dense_builder_and_career_workflows",
                "family:dice_initiative_and_table_utilities",
            }),
        "classic dense-workbench missing required proof family ids fails closed");
    ExpectThrows<ArgumentException>(
        () => _ = new ClassicDenseWorkbenchPreset(
            chromeRegressionSentinels: new[]
            {
                "hero_banner_height_max=0",
                "dashboard_tile_count_in_toolstrip_max=0",
                "decorative_landing_chrome_in_workbench_max=0",
                "menu_height_max=32",
                "toolstrip_height_max=40",
                "menu_and_toolstrip_combined_height_max=72",
                "status_strip_height_max=26",
                "persistent_banner_count_max=1",
                "card_nesting_depth_max=2",
                "center_pane_must_dominate=true",
            }),
        "classic dense-workbench missing required chrome sentinel fails closed");
    ExpectThrows<ArgumentException>(
        () => _ = new ClassicDenseWorkbenchPreset(
            menuHeightMax: "28",
            chromeRegressionSentinels: new[]
            {
                "hero_banner_height_max=0",
                "dashboard_tile_count_in_toolstrip_max=0",
                "decorative_landing_chrome_in_workbench_max=0",
                "menu_height_max=32",
                "toolstrip_height_max=40",
                "menu_and_toolstrip_combined_height_max=72",
                "status_strip_height_max=26",
                "persistent_banner_count_max=1",
                "persistent_secondary_badge_cluster_max=3",
                "card_nesting_depth_max=2",
                "center_pane_must_dominate=true",
            }),
        "classic dense-workbench stale chrome sentinel list fails closed");
    ExpectThrows<ArgumentException>(
        () => _ = new ClassicDenseWorkbenchPreset(
            proofFamilyIds: new[]
            {
                "family:dense_builder_and_career_workflows",
                "family:dice_initiative_and_table_utilities",
                "family:identity_contacts_lifestyles_history",
                "family:non_canonical_extra",
            }),
        "classic dense-workbench non-canonical proof family broadening fails closed");
}

static void DefaultCanonContainsClassicDenseWorkbenchTokens()
{
    var canon = TokenCanon.CreateDefault();
    var expectedKeys = new[]
    {
        "classic.dense.workbench.preset.id",
        "classic.dense.workbench.budget.version",
        "classic.dense.workbench.flagship.avalonia.default",
        "classic.dense.workbench.proof.family.ids",
        "classic.dense.workbench.chrome.regression.sentinels",
        "noise.budget.compact.spacing.scale",
        "noise.budget.compact.header.scale",
        "noise.budget.row.spacing.max",
        "noise.budget.card.padding.max",
        "noise.budget.input.padding.horizontal.max",
        "noise.budget.input.padding.vertical.max",
        "noise.budget.banner.height.max",
        "noise.budget.badge.density.max",
        "noise.budget.persistent.banner.count.max",
        "noise.budget.badge.cluster.secondary.max",
        "noise.budget.field.height.compact",
        "noise.budget.button.height.compact",
        "noise.budget.button.min.height.max",
        "noise.budget.icon.button.size.compact.max",
        "noise.budget.hero.banner.height.max",
        "noise.budget.card.nesting.depth.max",
        "noise.budget.toolstrip.dashboard.tile.max",
        "noise.budget.decorative.landing.chrome.max",
        "workbench.layout.top.menu.enabled",
        "workbench.layout.toolstrip.enabled",
        "workbench.layout.workspace.context.strip.required",
        "workbench.layout.menu.height.max",
        "workbench.layout.toolstrip.height.max",
        "workbench.layout.tab.strip.density",
        "workbench.layout.tab.strip.height.max",
        "workbench.layout.list.detail.compact",
        "workbench.layout.inspector.forms.compact",
        "workbench.layout.left.navigation.width.min",
        "workbench.layout.left.navigation.width.max",
        "workbench.layout.right.inspector.width.min",
        "workbench.layout.right.inspector.width.max",
        "workbench.layout.status.strip.posture",
        "workbench.layout.menu.toolstrip.height.max",
        "workbench.layout.status.strip.height.max",
        "workbench.layout.center.pane.must.dominate",
        "workbench.layout.section.rhythm.must.remain.visible",
        "workbench.layout.header.to.content.ratio.max",
        "workbench.visible.list.row.height.max",
        "workbench.visible.dense.list.row.min",
        "workbench.visible.dense.detail.group.field.min",
        "workbench.visible.builder.rows.1440x900.min",
        "workbench.visible.builder.rows.1366x768.min"
    };

    foreach (var key in expectedKeys)
    {
        ExpectTrue(canon.Contains(key), $"default canon contains {key}");
    }

    ExpectEqual("classic_dense_workbench", canon["classic.dense.workbench.preset.id"], "dense preset id token");
    ExpectEqual("2026-04-16", canon["classic.dense.workbench.budget.version"], "dense budget version token");
    ExpectEqual("true", canon["classic.dense.workbench.flagship.avalonia.default"], "avalonia flagship default token");
    ExpectEqual("family:dense_builder_and_career_workflows,family:dice_initiative_and_table_utilities,family:identity_contacts_lifestyles_history", canon["classic.dense.workbench.proof.family.ids"], "dense preset proof families token");
    ExpectEqual("hero_banner_height_max=0,dashboard_tile_count_in_toolstrip_max=0,decorative_landing_chrome_in_workbench_max=0,menu_height_max=32,toolstrip_height_max=40,menu_and_toolstrip_combined_height_max=72,status_strip_height_max=26,persistent_banner_count_max=1,persistent_secondary_badge_cluster_max=3,card_nesting_depth_max=2,center_pane_must_dominate=true", canon["classic.dense.workbench.chrome.regression.sentinels"], "dense preset chrome sentinel token");
    ExpectEqual("6", canon["noise.budget.row.spacing.max"], "row spacing max token");
    ExpectEqual("10", canon["noise.budget.card.padding.max"], "card padding max token");
    ExpectEqual("8", canon["noise.budget.input.padding.horizontal.max"], "input horizontal padding max token");
    ExpectEqual("6", canon["noise.budget.input.padding.vertical.max"], "input vertical padding max token");
    ExpectEqual("0", canon["noise.budget.hero.banner.height.max"], "hero banner max token");
    ExpectEqual("2", canon["noise.budget.card.nesting.depth.max"], "card nesting depth max token");
    ExpectEqual("0", canon["noise.budget.toolstrip.dashboard.tile.max"], "dashboard tile max token");
    ExpectEqual("0", canon["noise.budget.decorative.landing.chrome.max"], "decorative landing chrome max token");
    ExpectEqual("1", canon["noise.budget.persistent.banner.count.max"], "persistent banner count max token");
    ExpectEqual("3", canon["noise.budget.badge.cluster.secondary.max"], "persistent secondary badge-cluster max token");
    ExpectEqual("32", canon["noise.budget.button.min.height.max"], "compact button min-height max token");
    ExpectEqual("32", canon["noise.budget.icon.button.size.compact.max"], "compact icon-button size max token");
    ExpectEqual("true", canon["workbench.layout.workspace.context.strip.required"], "workspace-context strip requirement token");
    ExpectEqual("32", canon["workbench.layout.menu.height.max"], "menu height max token");
    ExpectEqual("40", canon["workbench.layout.toolstrip.height.max"], "toolstrip height max token");
    ExpectEqual("compact", canon["workbench.layout.tab.strip.density"], "tab strip density token");
    ExpectEqual("30", canon["workbench.layout.tab.strip.height.max"], "tab strip height max token");
    ExpectEqual("180", canon["workbench.layout.left.navigation.width.min"], "left-navigation width min token");
    ExpectEqual("240", canon["workbench.layout.left.navigation.width.max"], "left-navigation width max token");
    ExpectEqual("260", canon["workbench.layout.right.inspector.width.min"], "right-inspector width min token");
    ExpectEqual("340", canon["workbench.layout.right.inspector.width.max"], "right-inspector width max token");
    ExpectEqual("permanent", canon["workbench.layout.status.strip.posture"], "status strip posture token");
    ExpectEqual("72", canon["workbench.layout.menu.toolstrip.height.max"], "menu/toolstrip height max token");
    ExpectEqual("26", canon["workbench.layout.status.strip.height.max"], "status strip height max token");
    ExpectEqual("true", canon["workbench.layout.center.pane.must.dominate"], "center pane dominance token");
    ExpectEqual("true", canon["workbench.layout.section.rhythm.must.remain.visible"], "section rhythm token");
    ExpectEqual("0.30", canon["workbench.layout.header.to.content.ratio.max"], "header-to-content ratio max token");
    ExpectEqual("32", canon["workbench.visible.list.row.height.max"], "dense list-row height max token");
    ExpectEqual("9", canon["workbench.visible.dense.list.row.min"], "dense list visible row minimum token");
    ExpectEqual("6", canon["workbench.visible.dense.detail.group.field.min"], "dense detail group field minimum token");
    ExpectEqual("12", canon["workbench.visible.builder.rows.1440x900.min"], "1440x900 builder row minimum token");
    ExpectEqual("9", canon["workbench.visible.builder.rows.1366x768.min"], "1366x768 builder row minimum token");
}

static void FlagshipClassicDenseWorkbenchDefaultIsTokenBacked()
{
    var canon = TokenCanon.CreateDefault();
    var preset = ClassicDenseWorkbenchPreset.CreateFlagshipDesktopDefault(canon);

    ExpectEqual(canon["classic.dense.workbench.preset.id"], preset.PresetId, "flagship preset id comes from canon");
    ExpectEqual(canon["classic.dense.workbench.budget.version"], preset.DenseWorkbenchBudgetVersion, "flagship preset budget version comes from canon");
    ExpectEqual(canon["classic.dense.workbench.proof.family.ids"], string.Join(",", preset.ProofFamilyIds), "flagship proof families come from canon");
    ExpectEqual(canon["classic.dense.workbench.chrome.regression.sentinels"], string.Join(",", preset.ChromeRegressionSentinels), "flagship chrome sentinels come from canon");
    ExpectEqual(canon["noise.budget.compact.spacing.scale"], preset.CompactSpacingScale, "flagship compact spacing scale comes from canon");
    ExpectEqual(canon["noise.budget.row.spacing.max"], preset.RowSpacingMax, "flagship row spacing max comes from canon");
    ExpectEqual(canon["noise.budget.decorative.landing.chrome.max"], preset.DecorativeLandingChromeInWorkbenchMax, "flagship decorative chrome cap comes from canon");
    ExpectEqual(canon["workbench.layout.menu.height.max"], preset.MenuHeightMax, "flagship menu height comes from canon");
    ExpectEqual(canon["workbench.layout.toolstrip.height.max"], preset.ToolstripHeightMax, "flagship toolstrip height comes from canon");
    ExpectEqual(canon["workbench.layout.status.strip.height.max"], preset.StatusStripHeightMax, "flagship status strip height comes from canon");
    ExpectEqual(canon["workbench.visible.builder.rows.1440x900.min"], preset.BuilderRouteVisibleRowsAt1440x900Min, "flagship 1440x900 row minimum comes from canon");
    ExpectEqual(canon["workbench.visible.builder.rows.1366x768.min"], preset.BuilderRouteVisibleRowsAt1366x768Min, "flagship 1366x768 row minimum comes from canon");

    var overriddenTokens = canon.Tokens.ToDictionary(pair => pair.Key, pair => pair.Value, StringComparer.Ordinal);
    overriddenTokens["classic.dense.workbench.budget.version"] = "2099-12-31";
    overriddenTokens["noise.budget.decorative.landing.chrome.max"] = "1";
    overriddenTokens["classic.dense.workbench.chrome.regression.sentinels"] =
        "hero_banner_height_max=0,dashboard_tile_count_in_toolstrip_max=0,decorative_landing_chrome_in_workbench_max=1,menu_height_max=32,toolstrip_height_max=40,menu_and_toolstrip_combined_height_max=72,status_strip_height_max=26,persistent_banner_count_max=1,persistent_secondary_badge_cluster_max=3,card_nesting_depth_max=2,center_pane_must_dominate=true";

    var overriddenPreset = ClassicDenseWorkbenchPreset.CreateFlagshipDesktopDefault(new TokenCanon(overriddenTokens));
    ExpectEqual("2099-12-31", overriddenPreset.DenseWorkbenchBudgetVersion, "flagship preset refreshes from overridden canon budget version");
    ExpectEqual("1", overriddenPreset.DecorativeLandingChromeInWorkbenchMax, "flagship preset refreshes from overridden canon chrome cap");
    ExpectContains(string.Join(",", overriddenPreset.ChromeRegressionSentinels), "decorative_landing_chrome_in_workbench_max=1", "flagship preset refreshes from overridden canon chrome sentinels");
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
        "action_budget_bars",
        "condition_effect_chips",
        "source_anchor_drawers",
        "runboard_primitives",
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
    var errorState = new GuidanceState(GuidanceStateKind.Error, "Sync failed", "Chummer could not finish restoring your workspace.", "Review error", "Try again", "Crash packet CR-17 was captured.");
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
    var actionBudgetBar = new ActionBudgetBar("Major action", ActionBudgetKind.Major, available: 1, maximum: 2, pendingCost: 2, emphasis: ActionBudgetEmphasis.Warning, detail: "Pending called shot spends the remaining action.");
    var conditionEffectChip = new ConditionEffectChip("Prone", ConditionEffectKind.Condition, ConditionEffectTone.Warning, stackCount: 2, sourceAnchored: true, detail: "Applies a -2 defense modifier until cleared.");
    var sourceAnchorDrawer = new SourceAnchorDrawer("Suppressive fire", "SR6", "p. 114", "sr6-combat-suppressive-fire", open: true, conflictWarning: true, excerpt: "Targets inside the area must spend an action or take the attack.", supportLabel: "House rule adds gel-round fallout.");
    var runboardCard = new RunboardCard("Scene pressure", "Lone Star response escalates next round.", RunboardCardKind.Heat, RunboardCardPriority.Raised, metricLabel: "Heat 6/10", itemCount: 3, requiresAttention: true, detail: "Escalation timer reaches dispatch on the next round boundary.");
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
        BlazorUiKitAdapter.AdaptGuidanceState(errorState),
        "chummer-guidance-state",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "region",
            ["aria-live"] = "assertive",
            ["aria-label"] = "Sync failed",
            ["data-state-kind"] = "error",
            ["data-title"] = "Sync failed",
            ["data-body"] = "Chummer could not finish restoring your workspace.",
            ["data-primary-action"] = "Review error",
            ["data-secondary-action"] = "Try again",
            ["data-detail"] = "Crash packet CR-17 was captured.",
            ["class"] = "chummer-guidance-state chummer-guidance-state-error"
        },
        "blazor error guidance payload");
    ExpectPayloadSnapshot(
        BlazorUiKitAdapter.AdaptGuidanceState(errorState),
        "blazor.guidance-error.snapshot",
        "blazor error guidance snapshot");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptGuidanceState(errorState),
        "GuidanceState",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "guidance-state",
            ["classes"] = "GuidanceState GuidanceStateError",
            ["state-kind"] = "Error",
            ["title"] = "Sync failed",
            ["body"] = "Chummer could not finish restoring your workspace.",
            ["primary-action"] = "Review error",
            ["secondary-action"] = "Try again",
            ["detail"] = "Crash packet CR-17 was captured."
        },
        "avalonia error guidance payload");
    ExpectPayloadSnapshot(
        AvaloniaUiKitAdapter.AdaptGuidanceState(errorState),
        "avalonia.guidance-error.snapshot",
        "avalonia error guidance snapshot");

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

    ExpectPayload(
        BlazorUiKitAdapter.AdaptActionBudgetBar(actionBudgetBar),
        "chummer-action-budget-bar",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "progressbar",
            ["aria-label"] = "Major action action budget",
            ["aria-valuemin"] = "0",
            ["aria-valuemax"] = "2",
            ["aria-valuenow"] = "1",
            ["data-label"] = "Major action",
            ["data-kind"] = "major",
            ["data-available"] = "1",
            ["data-maximum"] = "2",
            ["data-pending-cost"] = "2",
            ["data-overdrawn"] = "true",
            ["data-emphasis"] = "warning",
            ["data-detail"] = "Pending called shot spends the remaining action.",
            ["class"] = "chummer-action-budget-bar chummer-action-budget-bar-warning chummer-action-budget-bar-overdrawn"
        },
        "blazor action-budget payload");
    ExpectPayloadSnapshot(
        BlazorUiKitAdapter.AdaptActionBudgetBar(actionBudgetBar),
        "blazor.action-budget-bar.snapshot",
        "blazor action-budget snapshot");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptActionBudgetBar(actionBudgetBar),
        "ActionBudgetBar",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "action-budget-bar",
            ["classes"] = "ActionBudgetBar ActionBudgetBarWarning ActionBudgetBarOverdrawn",
            ["label"] = "Major action",
            ["kind"] = "Major",
            ["available"] = "1",
            ["maximum"] = "2",
            ["pending-cost"] = "2",
            ["overdrawn"] = "true",
            ["emphasis"] = "Warning",
            ["detail"] = "Pending called shot spends the remaining action."
        },
        "avalonia action-budget payload");
    ExpectPayloadSnapshot(
        AvaloniaUiKitAdapter.AdaptActionBudgetBar(actionBudgetBar),
        "avalonia.action-budget-bar.snapshot",
        "avalonia action-budget snapshot");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptConditionEffectChip(conditionEffectChip),
        "chummer-condition-effect-chip",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "status",
            ["aria-label"] = "Prone x2",
            ["data-label"] = "Prone",
            ["data-kind"] = "condition",
            ["data-tone"] = "warning",
            ["data-stack-count"] = "2",
            ["data-source-anchored"] = "true",
            ["data-detail"] = "Applies a -2 defense modifier until cleared.",
            ["class"] = "chummer-condition-effect-chip chummer-condition-effect-chip-condition chummer-condition-effect-chip-warning chummer-condition-effect-chip-source-anchored"
        },
        "blazor condition/effect payload");
    ExpectPayloadSnapshot(
        BlazorUiKitAdapter.AdaptConditionEffectChip(conditionEffectChip),
        "blazor.condition-effect-chip.snapshot",
        "blazor condition/effect snapshot");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptConditionEffectChip(conditionEffectChip),
        "ConditionEffectChip",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "condition-effect-chip",
            ["classes"] = "ConditionEffectChip ConditionEffectChipCondition ConditionEffectChipWarning ConditionEffectChipAnchored",
            ["label"] = "Prone",
            ["kind"] = "Condition",
            ["tone"] = "Warning",
            ["stack-count"] = "2",
            ["source-anchored"] = "true",
            ["detail"] = "Applies a -2 defense modifier until cleared."
        },
        "avalonia condition/effect payload");
    ExpectPayloadSnapshot(
        AvaloniaUiKitAdapter.AdaptConditionEffectChip(conditionEffectChip),
        "avalonia.condition-effect-chip.snapshot",
        "avalonia condition/effect snapshot");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptSourceAnchorDrawer(sourceAnchorDrawer),
        "chummer-source-anchor-drawer",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "complementary",
            ["aria-label"] = "Suppressive fire",
            ["data-title"] = "Suppressive fire",
            ["data-source-short-code"] = "SR6",
            ["data-location-label"] = "p. 114",
            ["data-anchor-id"] = "sr6-combat-suppressive-fire",
            ["data-open"] = "true",
            ["data-conflict-warning"] = "true",
            ["data-excerpt"] = "Targets inside the area must spend an action or take the attack.",
            ["data-support-label"] = "House rule adds gel-round fallout.",
            ["class"] = "chummer-source-anchor-drawer chummer-source-anchor-drawer-open chummer-source-anchor-drawer-conflict"
        },
        "blazor source-anchor drawer payload");
    ExpectPayloadSnapshot(
        BlazorUiKitAdapter.AdaptSourceAnchorDrawer(sourceAnchorDrawer),
        "blazor.source-anchor-drawer.snapshot",
        "blazor source-anchor drawer snapshot");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptSourceAnchorDrawer(sourceAnchorDrawer),
        "SourceAnchorDrawer",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "source-anchor-drawer",
            ["classes"] = "SourceAnchorDrawer SourceAnchorDrawerOpen SourceAnchorDrawerConflict",
            ["title"] = "Suppressive fire",
            ["source-short-code"] = "SR6",
            ["location-label"] = "p. 114",
            ["anchor-id"] = "sr6-combat-suppressive-fire",
            ["open"] = "true",
            ["conflict-warning"] = "true",
            ["excerpt"] = "Targets inside the area must spend an action or take the attack.",
            ["support-label"] = "House rule adds gel-round fallout."
        },
        "avalonia source-anchor drawer payload");
    ExpectPayloadSnapshot(
        AvaloniaUiKitAdapter.AdaptSourceAnchorDrawer(sourceAnchorDrawer),
        "avalonia.source-anchor-drawer.snapshot",
        "avalonia source-anchor drawer snapshot");

    ExpectPayload(
        BlazorUiKitAdapter.AdaptRunboardCard(runboardCard),
        "chummer-runboard-card",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "group",
            ["aria-label"] = "Scene pressure",
            ["data-title"] = "Scene pressure",
            ["data-summary"] = "Lone Star response escalates next round.",
            ["data-kind"] = "heat",
            ["data-priority"] = "raised",
            ["data-item-count"] = "3",
            ["data-requires-attention"] = "true",
            ["data-metric-label"] = "Heat 6/10",
            ["data-detail"] = "Escalation timer reaches dispatch on the next round boundary.",
            ["class"] = "chummer-runboard-card chummer-runboard-card-heat chummer-runboard-card-raised chummer-runboard-card-attention"
        },
        "blazor runboard payload");
    ExpectPayloadSnapshot(
        BlazorUiKitAdapter.AdaptRunboardCard(runboardCard),
        "blazor.runboard-card.snapshot",
        "blazor runboard snapshot");
    ExpectPayload(
        AvaloniaUiKitAdapter.AdaptRunboardCard(runboardCard),
        "RunboardCard",
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "runboard-card",
            ["classes"] = "RunboardCard RunboardCardHeat RunboardCardRaised RunboardCardAttention",
            ["title"] = "Scene pressure",
            ["summary"] = "Lone Star response escalates next round.",
            ["kind"] = "Heat",
            ["priority"] = "Raised",
            ["item-count"] = "3",
            ["requires-attention"] = "true",
            ["metric-label"] = "Heat 6/10",
            ["detail"] = "Escalation timer reaches dispatch on the next round boundary."
        },
        "avalonia runboard payload");
    ExpectPayloadSnapshot(
        AvaloniaUiKitAdapter.AdaptRunboardCard(runboardCard),
        "avalonia.runboard-card.snapshot",
        "avalonia runboard snapshot");

    ExpectEqual(TokenCanon.CreateDefault()["action.budget.bar.root.class"], BlazorUiKitAdapter.AdaptActionBudgetBar(actionBudgetBar).RootClass, "action-budget root aligns with canon");
    ExpectEqual(TokenCanon.CreateDefault()["condition.effect.chip.root.class"], BlazorUiKitAdapter.AdaptConditionEffectChip(conditionEffectChip).RootClass, "condition/effect root aligns with canon");
    ExpectEqual(TokenCanon.CreateDefault()["source.anchor.drawer.root.class"], BlazorUiKitAdapter.AdaptSourceAnchorDrawer(sourceAnchorDrawer).RootClass, "source-anchor drawer root aligns with canon");
    ExpectEqual(TokenCanon.CreateDefault()["runboard.card.root.class"], BlazorUiKitAdapter.AdaptRunboardCard(runboardCard).RootClass, "runboard root aligns with canon");

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
            ["data-dense-workbench-budget-version"] = "2026-04-16",
            ["data-top-menu-bar-enabled"] = "true",
            ["data-toolstrip-enabled"] = "true",
            ["data-tab-strip-density"] = "compact",
            ["data-compact-list-detail-panes"] = "true",
            ["data-compact-inspector-forms"] = "true",
            ["data-status-strip-posture"] = "permanent",
            ["data-compact-spacing-scale"] = "0.85",
            ["data-compact-header-scale"] = "0.90",
            ["data-row-spacing-max"] = "6",
            ["data-card-padding-max"] = "10",
            ["data-input-padding-horizontal-max"] = "8",
            ["data-input-padding-vertical-max"] = "6",
            ["data-banner-height-ceiling"] = "2.50rem",
            ["data-badge-density-ceiling"] = "3",
            ["data-persistent-banner-count-max"] = "1",
            ["data-persistent-secondary-badge-cluster-max"] = "3",
            ["data-compact-field-height"] = "1.875rem",
            ["data-compact-button-height"] = "1.875rem",
            ["data-compact-button-min-height-max"] = "32",
            ["data-compact-icon-button-size-max"] = "32",
            ["data-hero-banner-height-max"] = "0",
            ["data-card-nesting-depth-max"] = "2",
            ["data-dashboard-tile-count-in-toolstrip-max"] = "0",
            ["data-decorative-landing-chrome-in-workbench-max"] = "0",
            ["data-menu-height-max"] = "32",
            ["data-toolstrip-height-max"] = "40",
            ["data-workspace-context-strip-required"] = "true",
            ["data-tab-strip-height-max"] = "30",
            ["data-left-navigation-width-min"] = "180",
            ["data-left-navigation-width-max"] = "240",
            ["data-right-inspector-width-min"] = "260",
            ["data-right-inspector-width-max"] = "340",
            ["data-menu-and-toolstrip-combined-height-max"] = "72",
            ["data-status-strip-height-max"] = "26",
            ["data-center-pane-must-dominate"] = "true",
            ["data-section-rhythm-must-remain-visible"] = "true",
            ["data-header-to-content-ratio-max"] = "0.30",
            ["data-dense-list-row-height-max"] = "32",
            ["data-dense-list-visible-row-min"] = "9",
            ["data-dense-detail-group-visible-field-min"] = "6",
            ["data-builder-route-visible-rows-1440x900-min"] = "12",
            ["data-builder-route-visible-rows-1366x768-min"] = "9",
            ["data-proof-family-ids"] = "family:dense_builder_and_career_workflows,family:dice_initiative_and_table_utilities,family:identity_contacts_lifestyles_history",
            ["data-chrome-regression-sentinels"] = "hero_banner_height_max=0,dashboard_tile_count_in_toolstrip_max=0,decorative_landing_chrome_in_workbench_max=0,menu_height_max=32,toolstrip_height_max=40,menu_and_toolstrip_combined_height_max=72,status_strip_height_max=26,persistent_banner_count_max=1,persistent_secondary_badge_cluster_max=3,card_nesting_depth_max=2,center_pane_must_dominate=true",
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
            ["dense-workbench-budget-version"] = "2026-04-16",
            ["top-menu-bar-enabled"] = "true",
            ["toolstrip-enabled"] = "true",
            ["tab-strip-density"] = "compact",
            ["compact-list-detail-panes"] = "true",
            ["compact-inspector-forms"] = "true",
            ["status-strip-posture"] = "permanent",
            ["compact-spacing-scale"] = "0.85",
            ["compact-header-scale"] = "0.90",
            ["row-spacing-max"] = "6",
            ["card-padding-max"] = "10",
            ["input-padding-horizontal-max"] = "8",
            ["input-padding-vertical-max"] = "6",
            ["banner-height-ceiling"] = "2.50rem",
            ["badge-density-ceiling"] = "3",
            ["persistent-banner-count-max"] = "1",
            ["persistent-secondary-badge-cluster-max"] = "3",
            ["compact-field-height"] = "1.875rem",
            ["compact-button-height"] = "1.875rem",
            ["compact-button-min-height-max"] = "32",
            ["compact-icon-button-size-max"] = "32",
            ["hero-banner-height-max"] = "0",
            ["card-nesting-depth-max"] = "2",
            ["dashboard-tile-count-in-toolstrip-max"] = "0",
            ["decorative-landing-chrome-in-workbench-max"] = "0",
            ["menu-height-max"] = "32",
            ["toolstrip-height-max"] = "40",
            ["workspace-context-strip-required"] = "true",
            ["tab-strip-height-max"] = "30",
            ["left-navigation-width-min"] = "180",
            ["left-navigation-width-max"] = "240",
            ["right-inspector-width-min"] = "260",
            ["right-inspector-width-max"] = "340",
            ["menu-and-toolstrip-combined-height-max"] = "72",
            ["status-strip-height-max"] = "26",
            ["center-pane-must-dominate"] = "true",
            ["section-rhythm-must-remain-visible"] = "true",
            ["header-to-content-ratio-max"] = "0.30",
            ["dense-list-row-height-max"] = "32",
            ["dense-list-visible-row-min"] = "9",
            ["dense-detail-group-visible-field-min"] = "6",
            ["builder-route-visible-rows-1440x900-min"] = "12",
            ["builder-route-visible-rows-1366x768-min"] = "9",
            ["proof-family-ids"] = "family:dense_builder_and_career_workflows,family:dice_initiative_and_table_utilities,family:identity_contacts_lifestyles_history",
            ["chrome-regression-sentinels"] = "hero_banner_height_max=0,dashboard_tile_count_in_toolstrip_max=0,decorative_landing_chrome_in_workbench_max=0,menu_height_max=32,toolstrip_height_max=40,menu_and_toolstrip_combined_height_max=72,status_strip_height_max=26,persistent_banner_count_max=1,persistent_secondary_badge_cluster_max=3,card_nesting_depth_max=2,center_pane_must_dominate=true",
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
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-row-spacing-max"]) <= 6d, "blazor row spacing max stays within dense noise budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-card-padding-max"]) <= 10d, "blazor card padding max stays within dense noise budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-input-padding-horizontal-max"]) <= 8d, "blazor input horizontal padding max stays within dense noise budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-input-padding-vertical-max"]) <= 6d, "blazor input vertical padding max stays within dense noise budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-badge-density-ceiling"]) <= 3d, "blazor badge density ceiling stays within dense noise budget");
    ExpectTrue(ParseRemValue(blazorDenseWorkbench.Attributes["data-banner-height-ceiling"]) <= 2.50d, "blazor banner height ceiling stays within dense noise budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-persistent-banner-count-max"]) <= 1d, "blazor persistent banner count stays within dense noise budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-persistent-secondary-badge-cluster-max"]) <= 3d, "blazor secondary badge-cluster count stays within dense noise budget");
    ExpectTrue(ParseRemValue(blazorDenseWorkbench.Attributes["data-compact-field-height"]) <= 1.875d, "blazor compact field height stays within dense noise budget");
    ExpectTrue(ParseRemValue(blazorDenseWorkbench.Attributes["data-compact-button-height"]) <= 1.875d, "blazor compact button height stays within dense noise budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-compact-button-min-height-max"]) <= 32d, "blazor compact button minimum height stays within dense noise budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-compact-icon-button-size-max"]) <= 32d, "blazor compact icon-button size stays within dense noise budget");
    ExpectEqual("0", blazorDenseWorkbench.Attributes["data-hero-banner-height-max"], "blazor hero banner height stays fail-closed");
    ExpectEqual("2", blazorDenseWorkbench.Attributes["data-card-nesting-depth-max"], "blazor card nesting depth stays fail-closed");
    ExpectEqual("0", blazorDenseWorkbench.Attributes["data-dashboard-tile-count-in-toolstrip-max"], "blazor dashboard tile count stays fail-closed");
    ExpectEqual("0", blazorDenseWorkbench.Attributes["data-decorative-landing-chrome-in-workbench-max"], "blazor decorative landing chrome stays fail-closed");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-menu-height-max"]) <= 32d, "blazor menu height stays within budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-toolstrip-height-max"]) <= 40d, "blazor toolstrip height stays within budget");
    ExpectEqual("true", blazorDenseWorkbench.Attributes["data-workspace-context-strip-required"], "blazor workspace-context strip requirement stays explicit");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-tab-strip-height-max"]) <= 30d, "blazor tab-strip height stays within budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-left-navigation-width-min"]) >= 180d, "blazor left-navigation minimum width stays explicit");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-left-navigation-width-max"]) <= 240d, "blazor left-navigation maximum width stays explicit");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-right-inspector-width-min"]) >= 260d, "blazor right-inspector minimum width stays explicit");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-right-inspector-width-max"]) <= 340d, "blazor right-inspector maximum width stays explicit");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-menu-and-toolstrip-combined-height-max"]) <= 72d, "blazor menu/toolstrip combined height stays within budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-status-strip-height-max"]) <= 26d, "blazor status-strip height stays within budget");
    ExpectEqual("true", blazorDenseWorkbench.Attributes["data-center-pane-must-dominate"], "blazor center-pane dominance stays explicit");
    ExpectEqual("true", blazorDenseWorkbench.Attributes["data-section-rhythm-must-remain-visible"], "blazor section rhythm stays explicit");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-header-to-content-ratio-max"]) <= 0.30d, "blazor header-to-content ratio stays within budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-dense-list-row-height-max"]) <= 32d, "blazor dense list-row height stays within budget");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-dense-list-visible-row-min"]) >= 9d, "blazor dense-list visible row minimum stays explicit");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-dense-detail-group-visible-field-min"]) >= 6d, "blazor dense detail-group minimum stays explicit");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-builder-route-visible-rows-1440x900-min"]) >= 12d, "blazor 1440x900 builder-row minimum stays explicit");
    ExpectTrue(ParseInvariantDouble(blazorDenseWorkbench.Attributes["data-builder-route-visible-rows-1366x768-min"]) >= 9d, "blazor 1366x768 builder-row minimum stays explicit");
    ExpectEqual("family:dense_builder_and_career_workflows,family:dice_initiative_and_table_utilities,family:identity_contacts_lifestyles_history", blazorDenseWorkbench.Attributes["data-proof-family-ids"], "blazor proof families stay bound to dense preset");
    ExpectContains(blazorDenseWorkbench.Attributes["data-chrome-regression-sentinels"], "decorative_landing_chrome_in_workbench_max=0", "blazor chrome sentinels include decorative chrome fail-close");
    ExpectContains(blazorDenseWorkbench.Attributes["data-chrome-regression-sentinels"], "menu_height_max=32", "blazor chrome sentinels include menu-height fail-close");
    ExpectContains(blazorDenseWorkbench.Attributes["data-chrome-regression-sentinels"], "toolstrip_height_max=40", "blazor chrome sentinels include toolstrip-height fail-close");
    ExpectContains(blazorDenseWorkbench.Attributes["data-chrome-regression-sentinels"], "menu_and_toolstrip_combined_height_max=72", "blazor chrome sentinels include combined top-chrome fail-close");
    ExpectContains(blazorDenseWorkbench.Attributes["data-chrome-regression-sentinels"], "status_strip_height_max=26", "blazor chrome sentinels include status-strip fail-close");
    ExpectContains(blazorDenseWorkbench.Attributes["data-chrome-regression-sentinels"], "persistent_banner_count_max=1", "blazor chrome sentinels include persistent-banner fail-close");
    ExpectContains(blazorDenseWorkbench.Attributes["data-chrome-regression-sentinels"], "persistent_secondary_badge_cluster_max=3", "blazor chrome sentinels include badge-cluster fail-close");
    ExpectContains(blazorDenseWorkbench.Attributes["data-chrome-regression-sentinels"], "card_nesting_depth_max=2", "blazor chrome sentinels include card-nesting fail-close");
    ExpectContains(blazorDenseWorkbench.Attributes["data-chrome-regression-sentinels"], "center_pane_must_dominate=true", "blazor chrome sentinels include center-pane dominance");
    ExpectEqual("2026-04-16", blazorDenseWorkbench.Attributes["data-dense-workbench-budget-version"], "blazor dense budget version stays explicit");
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

static void ExpectThrows<TException>(Action action, string scenario)
    where TException : Exception
{
    try
    {
        action();
    }
    catch (TException)
    {
        return;
    }
    catch (Exception ex)
    {
        throw new InvalidOperationException($"Expected {scenario} to throw {typeof(TException).Name} but got {ex.GetType().Name}.", ex);
    }

    throw new InvalidOperationException($"Expected {scenario} to throw {typeof(TException).Name}.");
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
