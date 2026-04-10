using Chummer.Ui.Kit.Adapters;
using System.Collections.ObjectModel;

namespace Chummer.Ui.Kit.Avalonia.Adapters;

public static class AvaloniaUiKitAdapter
{
    public static UiAdapterPayload AdaptDenseTableHeader(DenseTableHeader header)
    {
        var effectiveDirection = header.Sortable ? header.SortDirection : DenseSortDirection.None;
        var direction = effectiveDirection.ToString();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "dense-header",
            ["classes"] = $"DenseHeader{(header.Sortable ? " DenseHeaderSortable" : string.Empty)} DenseSort{direction}",
            ["key"] = header.Key,
            ["label"] = header.Label,
            ["sortable"] = header.Sortable.ToString().ToLowerInvariant(),
            ["sort-direction"] = direction
        };

        return new UiAdapterPayload("DenseHeader", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptDenseRowMetadata(DenseRowMetadata row)
    {
        var emphasis = row.Emphasis.ToString();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "dense-row",
            ["classes"] = $"DenseRow DenseRow{emphasis}{(row.Selected ? " DenseRowSelected" : string.Empty)}{(row.ExplainAffinity ? " DenseRowExplain" : string.Empty)}",
            ["row-id"] = row.RowId,
            ["emphasis"] = emphasis,
            ["selected"] = row.Selected.ToString().ToLowerInvariant(),
            ["explain-affinity"] = row.ExplainAffinity.ToString().ToLowerInvariant()
        };

        return new UiAdapterPayload("DenseRow", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptExplainChip(ExplainChip chip)
    {
        var tone = chip.Tone.ToString();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "explain-chip",
            ["classes"] = $"ExplainChip ExplainChip{tone}{(chip.Active ? " ExplainChipActive" : string.Empty)}",
            ["label"] = chip.Label,
            ["tone"] = tone,
            ["active"] = chip.Active.ToString().ToLowerInvariant()
        };

        if (!string.IsNullOrWhiteSpace(chip.Hint))
        {
            attrs["hint"] = chip.Hint;
        }

        return new UiAdapterPayload("ExplainChip", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptSpiderStatusCard(SpiderStatusCard card)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "spider-card",
            ["classes"] = $"SpiderStatusCard{(card.Stale ? " SpiderStatusCardStale" : string.Empty)}",
            ["title"] = card.Title,
            ["status"] = card.Status,
            ["summary"] = card.Summary,
            ["stale"] = card.Stale.ToString().ToLowerInvariant()
        };

        return new UiAdapterPayload("SpiderStatusCard", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptArtifactStatusCard(ArtifactStatusCard card)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "artifact-card",
            ["classes"] = $"ArtifactStatusCard{(card.Available ? " ArtifactStatusCardAvailable" : " ArtifactStatusCardUnavailable")}",
            ["title"] = card.Title,
            ["artifact-type"] = card.ArtifactType,
            ["status"] = card.Status,
            ["available"] = card.Available.ToString().ToLowerInvariant()
        };

        return new UiAdapterPayload("ArtifactStatusCard", new ReadOnlyDictionary<string, string>(attrs));
    }

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

        return new UiAdapterPayload("AccessibilityState", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptRoleTransition(RoleTransition transition)
    {
        var phase = transition.Phase.ToString();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "role-transition",
            ["classes"] = $"RoleTransition RoleTransition{phase}",
            ["from-role"] = transition.FromRole,
            ["to-role"] = transition.ToRole,
            ["phase"] = phase,
            ["requires-ack"] = transition.RequiresAcknowledgement.ToString().ToLowerInvariant()
        };

        if (!string.IsNullOrWhiteSpace(transition.Detail))
        {
            attrs["detail"] = transition.Detail;
        }

        return new UiAdapterPayload("RoleTransition", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptProgressToast(ProgressToast toast)
    {
        var tone = toast.Tone.ToString();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "progress-toast",
            ["classes"] = $"ProgressToast ProgressToast{tone}",
            ["title"] = toast.Title,
            ["progress-label"] = toast.ProgressLabel,
            ["progress-percent"] = toast.ProgressPercent.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["tone"] = tone,
            ["allow-cancel"] = toast.AllowCancel.ToString().ToLowerInvariant(),
            ["allow-resume"] = toast.AllowResume.ToString().ToLowerInvariant()
        };

        return new UiAdapterPayload("ProgressToast", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptResumeAffordance(ResumeAffordance affordance)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "resume-affordance",
            ["classes"] = $"ResumeAffordance{(affordance.RequiresRecovery ? " ResumeAffordanceRecovery" : string.Empty)}",
            ["title"] = affordance.Title,
            ["checkpoint"] = affordance.CheckpointLabel,
            ["resume-action"] = affordance.ResumeActionLabel,
            ["requires-recovery"] = affordance.RequiresRecovery.ToString().ToLowerInvariant()
        };

        if (!string.IsNullOrWhiteSpace(affordance.Detail))
        {
            attrs["detail"] = affordance.Detail;
        }

        return new UiAdapterPayload("ResumeAffordance", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptGuidanceState(GuidanceState state)
    {
        var kind = state.Kind.ToString();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "guidance-state",
            ["classes"] = $"GuidanceState GuidanceState{kind}",
            ["state-kind"] = kind,
            ["title"] = state.Title,
            ["body"] = state.Body,
            ["primary-action"] = state.PrimaryActionLabel
        };

        if (!string.IsNullOrWhiteSpace(state.SecondaryActionLabel))
        {
            attrs["secondary-action"] = state.SecondaryActionLabel;
        }

        if (!string.IsNullOrWhiteSpace(state.Detail))
        {
            attrs["detail"] = state.Detail;
        }

        return new UiAdapterPayload("GuidanceState", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptLongRunningActionControls(LongRunningActionControls controls)
    {
        var noLossPath = controls.NoLossPath.ToString();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "action-controls",
            ["classes"] = "LongRunningActionControls",
            ["action-dictionary"] = controls.ActionDictionaryReference,
            ["no-loss-path"] = noLossPath,
            ["retry-label"] = controls.RetryLabel,
            ["retry-enabled"] = controls.RetryEnabled.ToString().ToLowerInvariant(),
            ["retry-lossless"] = (controls.NoLossPath == LongRunningControlId.Retry).ToString().ToLowerInvariant(),
            ["cancel-label"] = controls.CancelLabel,
            ["cancel-enabled"] = controls.CancelEnabled.ToString().ToLowerInvariant(),
            ["cancel-lossless"] = (controls.NoLossPath == LongRunningControlId.Cancel).ToString().ToLowerInvariant(),
            ["rollback-label"] = controls.RollbackLabel,
            ["rollback-enabled"] = controls.RollbackEnabled.ToString().ToLowerInvariant(),
            ["rollback-lossless"] = (controls.NoLossPath == LongRunningControlId.Rollback).ToString().ToLowerInvariant(),
            ["safe-continuation-label"] = controls.SafeContinuationLabel,
            ["safe-continuation-enabled"] = controls.SafeContinuationEnabled.ToString().ToLowerInvariant(),
            ["safe-continuation-lossless"] = (controls.NoLossPath == LongRunningControlId.SafeContinuation).ToString().ToLowerInvariant()
        };

        if (!string.IsNullOrWhiteSpace(controls.Detail))
        {
            attrs["detail"] = controls.Detail;
        }

        return new UiAdapterPayload("LongRunningActionControls", new ReadOnlyDictionary<string, string>(attrs));
    }
}
