using Chummer.Ui.Kit.Adapters;
using System.Collections.ObjectModel;
using System.Globalization;

namespace Chummer.Ui.Kit.Avalonia.Adapters;

public static class AvaloniaUiKitAdapter
{
    public static UiAdapterPayload AdaptShellChrome(ShellChrome chrome)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "shell",
            ["classes"] = $"Shell{chrome.Tone} {(chrome.Compact ? "ShellCompact" : "ShellExpanded")}",
            ["title"] = chrome.Title,
            ["body"] = chrome.Body,
            ["tone"] = chrome.Tone.ToString(),
            ["compact"] = chrome.Compact.ToString().ToLowerInvariant()
        };

        return new UiAdapterPayload("ShellRoot", new ReadOnlyDictionary<string, string>(attrs));
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

    public static UiAdapterPayload AdaptDenseColumnHeader(DenseColumnHeader header)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "dense-column-header",
            ["classes"] = $"DenseColumnHeader{(header.Sortable ? " DenseColumnHeaderSortable" : string.Empty)}{(header.Numeric ? " DenseColumnHeaderNumeric" : string.Empty)}",
            ["key"] = header.Key,
            ["label"] = header.Label,
            ["sort"] = header.SortDirection.ToString(),
            ["sortable"] = header.Sortable.ToString().ToLowerInvariant(),
            ["numeric"] = header.Numeric.ToString().ToLowerInvariant()
        };

        return new UiAdapterPayload("DenseColumnHeader", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptDenseRowMetadata(DenseRowMetadata row)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "dense-row",
            ["classes"] = $"DenseRow{row.Emphasis}{(row.Selected ? " DenseRowSelected" : string.Empty)}{(row.Disabled ? " DenseRowDisabled" : string.Empty)}",
            ["row-key"] = row.RowKey,
            ["primary"] = row.PrimaryText,
            ["secondary"] = row.SecondaryText ?? string.Empty,
            ["emphasis"] = row.Emphasis.ToString(),
            ["explain-affinity"] = row.ExplainAffinity.ToString(),
            ["selected"] = row.Selected.ToString().ToLowerInvariant(),
            ["disabled"] = row.Disabled.ToString().ToLowerInvariant()
        };

        return new UiAdapterPayload("DenseRow", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptDenseTableSummary(DenseTableSummary summary)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "dense-table",
            ["classes"] = $"DenseTable{(summary.Compact ? " DenseTableCompact" : string.Empty)}{(summary.ZebraStripes ? " DenseTableStriped" : string.Empty)}",
            ["label"] = summary.Label,
            ["row-count"] = summary.RowCount.ToString(CultureInfo.InvariantCulture),
            ["visible-columns"] = summary.VisibleColumnCount.ToString(CultureInfo.InvariantCulture),
            ["compact"] = summary.Compact.ToString().ToLowerInvariant(),
            ["zebra-stripes"] = summary.ZebraStripes.ToString().ToLowerInvariant()
        };

        return new UiAdapterPayload("DenseTable", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptExplainChip(ExplainChip chip)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "explain-chip",
            ["classes"] = $"ExplainChip{chip.Tone}{(chip.Interactive ? " ExplainChipInteractive" : string.Empty)}",
            ["label"] = chip.Label,
            ["evidence-count"] = chip.EvidenceCountLabel,
            ["tone"] = chip.Tone.ToString(),
            ["interactive"] = chip.Interactive.ToString().ToLowerInvariant()
        };

        return new UiAdapterPayload("ExplainChip", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptSpiderStatusCard(SpiderStatusCard card)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "spider-status-card",
            ["classes"] = $"StatusCard StatusCardSpider StatusCard{card.Tone}{(card.RequiresAttention ? " StatusCardAttention" : string.Empty)}",
            ["title"] = card.Title,
            ["summary"] = card.Summary,
            ["posture"] = card.PostureLabel,
            ["tone"] = card.Tone.ToString(),
            ["requires-attention"] = card.RequiresAttention.ToString().ToLowerInvariant()
        };

        return new UiAdapterPayload("SpiderStatusCard", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptArtifactStatusCard(ArtifactStatusCard card)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "artifact-status-card",
            ["classes"] = $"StatusCard StatusCardArtifact StatusCard{card.Tone}{(card.PreviewReady ? " StatusCardPreviewReady" : string.Empty)}",
            ["title"] = card.Title,
            ["status"] = card.StatusLabel,
            ["detail"] = card.Detail,
            ["tone"] = card.Tone.ToString(),
            ["preview-ready"] = card.PreviewReady.ToString().ToLowerInvariant()
        };

        return new UiAdapterPayload("ArtifactStatusCard", new ReadOnlyDictionary<string, string>(attrs));
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

        return new UiAdapterPayload("AccessibilityState", new ReadOnlyDictionary<string, string>(attrs));
    }
}
