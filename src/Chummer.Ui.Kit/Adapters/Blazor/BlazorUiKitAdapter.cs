using Chummer.Ui.Kit.Adapters;
using System.Collections.ObjectModel;
using System.Globalization;

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

    public static UiAdapterPayload AdaptDenseColumnHeader(DenseColumnHeader header)
    {
        var sort = header.SortDirection.ToString().ToLowerInvariant();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "columnheader",
            ["data-key"] = header.Key,
            ["data-label"] = header.Label,
            ["data-sort"] = sort,
            ["data-sortable"] = header.Sortable.ToString().ToLowerInvariant(),
            ["data-numeric"] = header.Numeric.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-dense-header{(header.Sortable ? " chummer-dense-header-sortable" : string.Empty)}{(header.Numeric ? " chummer-dense-header-numeric" : string.Empty)}",
            ["aria-sort"] = sort switch
            {
                "ascending" => "ascending",
                "descending" => "descending",
                _ => "none"
            }
        };

        return new UiAdapterPayload("chummer-dense-header", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptDenseRowMetadata(DenseRowMetadata row)
    {
        var emphasis = row.Emphasis.ToString().ToLowerInvariant();
        var affinity = row.ExplainAffinity.ToString().ToLowerInvariant();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "row",
            ["data-row-key"] = row.RowKey,
            ["data-primary"] = row.PrimaryText,
            ["data-secondary"] = row.SecondaryText ?? string.Empty,
            ["data-emphasis"] = emphasis,
            ["data-explain-affinity"] = affinity,
            ["data-selected"] = row.Selected.ToString().ToLowerInvariant(),
            ["data-disabled"] = row.Disabled.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-dense-row chummer-dense-row-{emphasis}{(row.Selected ? " chummer-dense-row-selected" : string.Empty)}{(row.Disabled ? " chummer-dense-row-disabled" : string.Empty)}",
            ["aria-label"] = row.SecondaryText is null ? row.PrimaryText : $"{row.PrimaryText} {row.SecondaryText}"
        };

        return new UiAdapterPayload("chummer-dense-row", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptDenseTableSummary(DenseTableSummary summary)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "table",
            ["data-label"] = summary.Label,
            ["data-row-count"] = summary.RowCount.ToString(CultureInfo.InvariantCulture),
            ["data-visible-columns"] = summary.VisibleColumnCount.ToString(CultureInfo.InvariantCulture),
            ["data-compact"] = summary.Compact.ToString().ToLowerInvariant(),
            ["data-zebra-stripes"] = summary.ZebraStripes.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-dense-table{(summary.Compact ? " chummer-dense-table-compact" : string.Empty)}{(summary.ZebraStripes ? " chummer-dense-table-striped" : string.Empty)}",
            ["aria-label"] = $"{summary.Label} dense table"
        };

        return new UiAdapterPayload("chummer-dense-table", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptExplainChip(ExplainChip chip)
    {
        var tone = chip.Tone.ToString().ToLowerInvariant();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "note",
            ["data-label"] = chip.Label,
            ["data-evidence-count"] = chip.EvidenceCountLabel,
            ["data-tone"] = tone,
            ["data-interactive"] = chip.Interactive.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-explain-chip chummer-explain-chip-{tone}{(chip.Interactive ? " chummer-explain-chip-actionable" : string.Empty)}",
            ["aria-label"] = $"{chip.Label} {chip.EvidenceCountLabel}"
        };

        return new UiAdapterPayload("chummer-explain-chip", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptSpiderStatusCard(SpiderStatusCard card)
    {
        var tone = card.Tone.ToString().ToLowerInvariant();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "article",
            ["data-title"] = card.Title,
            ["data-summary"] = card.Summary,
            ["data-posture"] = card.PostureLabel,
            ["data-tone"] = tone,
            ["data-requires-attention"] = card.RequiresAttention.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-status-card chummer-status-card-spider chummer-status-card-{tone}{(card.RequiresAttention ? " chummer-status-card-attention" : string.Empty)}",
            ["aria-label"] = $"{card.Title} {card.PostureLabel}"
        };

        return new UiAdapterPayload("chummer-status-card", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptArtifactStatusCard(ArtifactStatusCard card)
    {
        var tone = card.Tone.ToString().ToLowerInvariant();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "article",
            ["data-title"] = card.Title,
            ["data-status"] = card.StatusLabel,
            ["data-detail"] = card.Detail,
            ["data-tone"] = tone,
            ["data-preview-ready"] = card.PreviewReady.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-status-card chummer-status-card-artifact chummer-status-card-{tone}{(card.PreviewReady ? " chummer-status-card-preview-ready" : string.Empty)}",
            ["aria-label"] = $"{card.Title} {card.StatusLabel}"
        };

        return new UiAdapterPayload("chummer-status-card", new ReadOnlyDictionary<string, string>(attrs));
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
