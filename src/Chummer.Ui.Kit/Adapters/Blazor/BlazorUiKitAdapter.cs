using Chummer.Ui.Kit.Adapters;
using System.Collections.ObjectModel;

namespace Chummer.Ui.Kit.Blazor.Adapters;

public static class BlazorUiKitAdapter
{
    public static UiAdapterPayload AdaptShellChrome(ShellChrome chrome)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "banner",
            ["aria-label"] = $"{chrome.Title} shell chrome",
            ["data-title"] = chrome.Title,
            ["data-body"] = chrome.Body,
            ["data-tone"] = chrome.Tone.ToString().ToLowerInvariant(),
            ["data-compact"] = chrome.Compact.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-shell chummer-shell-{chrome.Tone.ToString().ToLowerInvariant()}{(chrome.Compact ? " chummer-shell-compact" : string.Empty)}"
        };

        return new UiAdapterPayload("chummer-shell", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptBanner(Banner banner)
    {
        var tone = banner.Tone.ToString().ToLowerInvariant();

        return UiAdapterPayload.Banner(tone, banner.Headline,
            new Dictionary<string, string>(StringComparer.Ordinal)
            {
                ["class"] = $"chummer-banner{(banner.Pinned ? " chummer-banner-pinned" : string.Empty)}",
                ["data-body"] = banner.Body,
                ["data-tone"] = tone,
                ["data-pinned"] = banner.Pinned.ToString().ToLowerInvariant(),
                ["aria-label"] = banner.Headline
            });
    }

    public static UiAdapterPayload AdaptStaleStateBadge(StaleStateBadge badge)
    {
        var state = badge.State.ToString().ToLowerInvariant();

        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "note",
            ["data-state"] = state,
            ["data-detail"] = badge.Detail ?? string.Empty,
            ["class"] = $"chummer-badge chummer-badge-{state}",
            ["aria-label"] = badge.Detail ?? $"{badge.State} state"
        };

        return new UiAdapterPayload("chummer-badge", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptApprovalChip(ApprovalChip chip)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "status",
            ["data-approved"] = chip.IsApproved.ToString().ToLowerInvariant(),
            ["data-approver"] = chip.Approver ?? string.Empty,
            ["class"] = $"chummer-chip chummer-chip-{(chip.IsApproved ? "approved" : "pending")}",
            ["aria-label"] = chip.Label
        };

        return new UiAdapterPayload("chummer-chip", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptOfflineBanner(OfflineBanner banner)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "alert",
            ["aria-live"] = "polite",
            ["data-service"] = banner.Service,
            ["data-offline"] = banner.IsOffline.ToString().ToLowerInvariant(),
            ["class"] = banner.IsOffline ? "chummer-offline chummer-offline-on" : "chummer-offline chummer-offline-off",
            ["aria-label"] = banner.IsOffline ? $"{banner.Service} is offline" : $"{banner.Service} is online"
        };

        return new UiAdapterPayload("chummer-offline", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptAccessibilityState(AccessibilityState state)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "status",
            ["aria-busy"] = state.Busy.ToString().ToLowerInvariant(),
            ["aria-disabled"] = state.Disabled.ToString().ToLowerInvariant(),
            ["aria-live"] = state.LiveRegion,
        };

        if (!string.IsNullOrWhiteSpace(state.Label))
        {
            attrs["aria-label"] = state.Label;
        }

        if (!string.IsNullOrWhiteSpace(state.DescribedBy))
        {
            attrs["aria-describedby"] = state.DescribedBy;
        }

        return new UiAdapterPayload("chummer-accessibility", new ReadOnlyDictionary<string, string>(attrs));
    }
}
