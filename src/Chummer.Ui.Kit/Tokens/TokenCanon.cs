using System.Collections.ObjectModel;

namespace Chummer.Ui.Kit.Tokens;

public sealed class TokenCanon
{
    private readonly IReadOnlyDictionary<string, string> _tokens;

    public TokenCanon(IReadOnlyDictionary<string, string> tokens)
    {
        ArgumentNullException.ThrowIfNull(tokens);

        if (tokens.Count == 0)
        {
            throw new ArgumentException("Token canon must include at least one token.", nameof(tokens));
        }

        _tokens = new ReadOnlyDictionary<string, string>(
            new SortedDictionary<string, string>(
                tokens.ToDictionary(
                    pair => NormalizeKey(pair.Key),
                    pair => NormalizeValue(pair.Value),
                    StringComparer.Ordinal),
                StringComparer.Ordinal));
    }

    public IReadOnlyDictionary<string, string> Tokens => _tokens;

    public bool Contains(string key) => _tokens.ContainsKey(NormalizeKey(key));

    public string this[string key] => _tokens[NormalizeKey(key)];

    public static TokenCanon CreateDefault()
    {
        return new TokenCanon(new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["color.background.canvas"] = "#F7F3EA",
            ["color.background.panel"] = "#FFFDF8",
            ["color.border.subtle"] = "#D5C8B8",
            ["color.text.primary"] = "#1F1A17",
            ["color.text.muted"] = "#675D52",
            ["color.accent.primary"] = "#8C4A2F",
            ["shell.chrome.root.class"] = "chummer-shell",
            ["shell.chrome.role"] = "banner",
            ["shell.chrome.default.tone"] = "default",
            ["shell.chrome.default.compact"] = "false",
            ["accessibility.state.root.class"] = "chummer-accessibility",
            ["accessibility.state.role"] = "status",
            ["accessibility.state.live.default"] = "polite",
            ["accessibility.state.busy.default"] = "false",
            ["accessibility.state.disabled.default"] = "false",
            ["role.transition.root.class"] = "chummer-role-transition",
            ["role.transition.phase.default"] = "announced",
            ["progress.toast.root.class"] = "chummer-progress-toast",
            ["progress.toast.tone.default"] = "info",
            ["resume.affordance.root.class"] = "chummer-resume-affordance",
            ["resume.affordance.recovery.default"] = "false",
            ["onboarding.state.root.class"] = "chummer-guidance-state",
            ["onboarding.state.primary.action.default"] = "Get started",
            ["error.state.root.class"] = "chummer-guidance-state",
            ["error.state.primary.action.default"] = "Review error",
            ["empty.state.root.class"] = "chummer-guidance-state",
            ["empty.state.primary.action.default"] = "Create first item",
            ["recovery.state.root.class"] = "chummer-guidance-state",
            ["recovery.state.primary.action.default"] = "Review recovery",
            ["first.run.state.root.class"] = "chummer-guidance-state",
            ["first.run.state.primary.action.default"] = "Start walkthrough",
            ["long.running.actions.root.class"] = "chummer-action-controls",
            ["long.running.actions.no.loss.default"] = "safe-continuation",
            ["long.running.actions.dictionary"] = "design/DR-129",
            ["action.budget.bar.root.class"] = "chummer-action-budget-bar",
            ["action.budget.bar.kind.default"] = "major",
            ["action.budget.bar.emphasis.default"] = "steady",
            ["condition.effect.chip.root.class"] = "chummer-condition-effect-chip",
            ["condition.effect.chip.kind.default"] = "effect",
            ["condition.effect.chip.tone.default"] = "neutral",
            ["source.anchor.drawer.root.class"] = "chummer-source-anchor-drawer",
            ["source.anchor.drawer.open.default"] = "false",
            ["runboard.card.root.class"] = "chummer-runboard-card",
            ["runboard.card.priority.default"] = "standard",
            ["classic.dense.workbench.preset.id"] = "classic_dense_workbench",
            ["classic.dense.workbench.budget.version"] = "2026-04-16",
            ["classic.dense.workbench.flagship.avalonia.default"] = "true",
            ["classic.dense.workbench.proof.family.ids"] = "family:dense_builder_and_career_workflows,family:dice_initiative_and_table_utilities,family:identity_contacts_lifestyles_history",
            ["classic.dense.workbench.chrome.regression.sentinels"] = "hero_banner_height_max=0,dashboard_tile_count_in_toolstrip_max=0,decorative_landing_chrome_in_workbench_max=0,menu_height_max=32,toolstrip_height_max=40,menu_and_toolstrip_combined_height_max=72,status_strip_height_max=26,persistent_banner_count_max=1,persistent_secondary_badge_cluster_max=3,card_nesting_depth_max=2,center_pane_must_dominate=true",
            ["noise.budget.compact.spacing.scale"] = "0.85",
            ["noise.budget.compact.header.scale"] = "0.90",
            ["noise.budget.row.spacing.max"] = "6",
            ["noise.budget.card.padding.max"] = "10",
            ["noise.budget.input.padding.horizontal.max"] = "8",
            ["noise.budget.input.padding.vertical.max"] = "6",
            ["noise.budget.banner.height.max"] = "2.50rem",
            ["noise.budget.badge.density.max"] = "3",
            ["noise.budget.persistent.banner.count.max"] = "1",
            ["noise.budget.badge.cluster.secondary.max"] = "3",
            ["noise.budget.field.height.compact"] = "1.875rem",
            ["noise.budget.button.height.compact"] = "1.875rem",
            ["noise.budget.button.min.height.max"] = "32",
            ["noise.budget.icon.button.size.compact.max"] = "32",
            ["noise.budget.hero.banner.height.max"] = "0",
            ["noise.budget.card.nesting.depth.max"] = "2",
            ["noise.budget.toolstrip.dashboard.tile.max"] = "0",
            ["noise.budget.decorative.landing.chrome.max"] = "0",
            ["workbench.layout.top.menu.enabled"] = "true",
            ["workbench.layout.toolstrip.enabled"] = "true",
            ["workbench.layout.workspace.context.strip.required"] = "true",
            ["workbench.layout.menu.height.max"] = "32",
            ["workbench.layout.toolstrip.height.max"] = "40",
            ["workbench.layout.tab.strip.density"] = "compact",
            ["workbench.layout.tab.strip.height.max"] = "30",
            ["workbench.layout.list.detail.compact"] = "true",
            ["workbench.layout.inspector.forms.compact"] = "true",
            ["workbench.layout.left.navigation.width.min"] = "180",
            ["workbench.layout.left.navigation.width.max"] = "240",
            ["workbench.layout.right.inspector.width.min"] = "260",
            ["workbench.layout.right.inspector.width.max"] = "340",
            ["workbench.layout.status.strip.posture"] = "permanent",
            ["workbench.layout.menu.toolstrip.height.max"] = "72",
            ["workbench.layout.status.strip.height.max"] = "26",
            ["workbench.layout.center.pane.must.dominate"] = "true",
            ["workbench.layout.section.rhythm.must.remain.visible"] = "true",
            ["workbench.layout.header.to.content.ratio.max"] = "0.30",
            ["workbench.visible.list.row.height.max"] = "32",
            ["workbench.visible.dense.list.row.min"] = "9",
            ["workbench.visible.dense.detail.group.field.min"] = "6",
            ["workbench.visible.builder.rows.1440x900.min"] = "12",
            ["workbench.visible.builder.rows.1366x768.min"] = "9",
            ["space.100"] = "0.25rem",
            ["space.200"] = "0.5rem",
            ["space.400"] = "1rem",
            ["radius.sm"] = "0.25rem",
            ["radius.md"] = "0.5rem",
            ["font.family.base"] = "\"IBM Plex Sans\", \"Segoe UI\", sans-serif",
            ["font.size.body"] = "1rem",
            ["font.size.title"] = "1.5rem"
        });
    }

    private static string NormalizeKey(string key)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Token key cannot be null or whitespace.", nameof(key));
        }

        return key.Trim();
    }

    private static string NormalizeValue(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Token value cannot be null or whitespace.", nameof(value));
        }

        return value.Trim();
    }
}
