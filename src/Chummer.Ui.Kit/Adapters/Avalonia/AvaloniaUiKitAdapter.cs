using Chummer.Ui.Kit.Adapters;
using System.Collections.ObjectModel;

namespace Chummer.Ui.Kit.Avalonia.Adapters;

public static class AvaloniaUiKitAdapter
{
    public static UiAdapterPayload AdaptShellChrome(ShellChrome chrome)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "shell",
            ["classes"] = $"ShellRoot Shell{chrome.Tone} {(chrome.Compact ? "ShellCompact" : "ShellExpanded")}",
            ["title"] = chrome.Title,
            ["body"] = chrome.Body,
            ["tone"] = chrome.Tone.ToString(),
            ["compact"] = chrome.Compact.ToString().ToLowerInvariant()
        };

        return new UiAdapterPayload("chummer-shell", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptBanner(Banner banner)
    {
        var tone = banner.Tone.ToString();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "banner",
            ["classes"] = $"Banner{banner.Tone}{(banner.Pinned ? " BannerPinned" : string.Empty)}",
            ["headline"] = banner.Headline,
            ["body"] = banner.Body,
            ["tone"] = tone,
            ["pinned"] = banner.Pinned.ToString().ToLowerInvariant()
        };

        return UiAdapterPayload.Banner(tone.ToLowerInvariant(), banner.Headline, attrs);
    }

    public static UiAdapterPayload AdaptStaleStateBadge(StaleStateBadge badge)
    {
        var state = badge.State.ToString();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "stale-badge",
            ["classes"] = $"StaleBadge{state}",
            ["state"] = state,
            ["state-detail"] = badge.Detail ?? string.Empty
        };

        return new UiAdapterPayload("StaleBadge", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptApprovalChip(ApprovalChip chip)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "approval-chip",
            ["classes"] = $"ApprovalChip{(chip.IsApproved ? "Approved" : "Pending")}",
            ["text"] = chip.Label,
            ["approved"] = chip.IsApproved.ToString().ToLowerInvariant(),
            ["label"] = chip.Label,
            ["approver"] = chip.Approver ?? string.Empty
        };

        if (!string.IsNullOrWhiteSpace(chip.Approver))
        {
            attrs["approver"] = chip.Approver;
        }

        return new UiAdapterPayload("ApprovalChip", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptOfflineBanner(OfflineBanner banner)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "offline-banner",
            ["classes"] = $"OfflineBanner{(banner.IsOffline ? "Offline" : "Online")}",
            ["service"] = banner.Service,
            ["offline"] = banner.IsOffline.ToString().ToLowerInvariant()
        };

        return new UiAdapterPayload("OfflineBanner", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptAccessibilityState(AccessibilityState state)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "a11y",
            ["classes"] = "AccessibilityState",
            ["role"] = "status",
            ["is-busy"] = state.Busy.ToString().ToLowerInvariant(),
            ["is-disabled"] = state.Disabled.ToString().ToLowerInvariant(),
            ["live"] = state.LiveRegion
        };

        if (!string.IsNullOrWhiteSpace(state.Label))
        {
            attrs["label"] = state.Label;
        }

        if (!string.IsNullOrWhiteSpace(state.DescribedBy))
        {
            attrs["described-by"] = state.DescribedBy;
        }

        return new UiAdapterPayload("chummer-accessibility", new ReadOnlyDictionary<string, string>(attrs));
    }
}
