using Chummer.Ui.Kit.Adapters;
using System.Collections.ObjectModel;

namespace Chummer.Ui.Kit.Blazor.Adapters;

public static class BlazorUiKitAdapter
{
    public static UiAdapterPayload AdaptDenseTableHeader(DenseTableHeader header)
    {
        var direction = header.SortDirection.ToString().ToLowerInvariant();
        var ariaSort = header.SortDirection switch
        {
            DenseSortDirection.Asc => "ascending",
            DenseSortDirection.Desc => "descending",
            _ => "none"
        };
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "columnheader",
            ["data-key"] = header.Key,
            ["data-label"] = header.Label,
            ["data-sortable"] = header.Sortable.ToString().ToLowerInvariant(),
            ["data-sort-direction"] = direction,
            ["aria-sort"] = ariaSort,
            ["class"] = $"chummer-dense-header{(header.Sortable ? " chummer-dense-header-sortable" : string.Empty)} chummer-dense-sort-{direction}"
        };

        return new UiAdapterPayload("chummer-dense-header", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptDenseRowMetadata(DenseRowMetadata row)
    {
        var emphasis = row.Emphasis.ToString().ToLowerInvariant();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "row",
            ["data-row-id"] = row.RowId,
            ["data-emphasis"] = emphasis,
            ["data-selected"] = row.Selected.ToString().ToLowerInvariant(),
            ["data-explain-affinity"] = row.ExplainAffinity.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-dense-row chummer-dense-row-{emphasis}{(row.Selected ? " chummer-dense-row-selected" : string.Empty)}{(row.ExplainAffinity ? " chummer-dense-row-explain" : string.Empty)}"
        };

        return new UiAdapterPayload("chummer-dense-row", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptExplainChip(ExplainChip chip)
    {
        var tone = chip.Tone.ToString().ToLowerInvariant();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "note",
            ["data-label"] = chip.Label,
            ["data-tone"] = tone,
            ["data-active"] = chip.Active.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-explain-chip chummer-explain-chip-{tone}{(chip.Active ? " chummer-explain-chip-active" : string.Empty)}",
            ["aria-label"] = chip.Label
        };

        if (!string.IsNullOrWhiteSpace(chip.Hint))
        {
            attrs["data-hint"] = chip.Hint;
        }

        return new UiAdapterPayload("chummer-explain-chip", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptSpiderStatusCard(SpiderStatusCard card)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "group",
            ["data-title"] = card.Title,
            ["data-status"] = card.Status,
            ["data-summary"] = card.Summary,
            ["data-stale"] = card.Stale.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-card chummer-card-spider{(card.Stale ? " chummer-card-stale" : string.Empty)}",
            ["aria-label"] = $"{card.Title} status card"
        };

        return new UiAdapterPayload("chummer-card-spider", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptArtifactStatusCard(ArtifactStatusCard card)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "group",
            ["data-title"] = card.Title,
            ["data-artifact-type"] = card.ArtifactType,
            ["data-status"] = card.Status,
            ["data-available"] = card.Available.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-card chummer-card-artifact{(card.Available ? " chummer-card-available" : " chummer-card-unavailable")}",
            ["aria-label"] = $"{card.Title} artifact card"
        };

        return new UiAdapterPayload("chummer-card-artifact", new ReadOnlyDictionary<string, string>(attrs));
    }

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
