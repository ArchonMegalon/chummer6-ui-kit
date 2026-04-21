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
            ["classic.dense.workbench.preset.id"] = "classic_dense_workbench",
            ["classic.dense.workbench.flagship.avalonia.default"] = "true",
            ["noise.budget.compact.spacing.scale"] = "0.85",
            ["noise.budget.compact.header.scale"] = "0.90",
            ["noise.budget.banner.height.max"] = "2.50rem",
            ["noise.budget.badge.density.max"] = "3",
            ["noise.budget.field.height.compact"] = "1.875rem",
            ["noise.budget.button.height.compact"] = "1.875rem",
            ["workbench.layout.top.menu.enabled"] = "true",
            ["workbench.layout.toolstrip.enabled"] = "true",
            ["workbench.layout.tab.strip.density"] = "compact",
            ["workbench.layout.list.detail.compact"] = "true",
            ["workbench.layout.inspector.forms.compact"] = "true",
            ["workbench.layout.status.strip.posture"] = "permanent",
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
