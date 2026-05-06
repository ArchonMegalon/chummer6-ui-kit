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

    public static UiAdapterPayload AdaptClassicDenseWorkbenchPreset(ClassicDenseWorkbenchPreset preset)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "classic-dense-workbench",
            ["classes"] = $"ClassicDenseWorkbench{(preset.FlagshipDefaultForAvalonia ? " FlagshipDesktopDefault" : string.Empty)}",
            ["preset-id"] = preset.PresetId,
            ["dense-workbench-budget-version"] = preset.DenseWorkbenchBudgetVersion,
            ["top-menu-bar-enabled"] = preset.TopMenuBarEnabled.ToString().ToLowerInvariant(),
            ["toolstrip-enabled"] = preset.ToolstripEnabled.ToString().ToLowerInvariant(),
            ["tab-strip-density"] = preset.TabStripDensity,
            ["compact-list-detail-panes"] = preset.CompactListDetailPanes.ToString().ToLowerInvariant(),
            ["compact-inspector-forms"] = preset.CompactInspectorForms.ToString().ToLowerInvariant(),
            ["status-strip-posture"] = preset.StatusStripPosture,
            ["compact-spacing-scale"] = preset.CompactSpacingScale,
            ["compact-header-scale"] = preset.CompactHeaderScale,
            ["row-spacing-max"] = preset.RowSpacingMax,
            ["card-padding-max"] = preset.CardPaddingMax,
            ["input-padding-horizontal-max"] = preset.InputPaddingHorizontalMax,
            ["input-padding-vertical-max"] = preset.InputPaddingVerticalMax,
            ["banner-height-ceiling"] = preset.BannerHeightCeiling,
            ["badge-density-ceiling"] = preset.BadgeDensityCeiling,
            ["persistent-banner-count-max"] = preset.PersistentBannerCountMax,
            ["persistent-secondary-badge-cluster-max"] = preset.PersistentSecondaryBadgeClusterMax,
            ["compact-field-height"] = preset.CompactFieldHeight,
            ["compact-button-height"] = preset.CompactButtonHeight,
            ["compact-button-min-height-max"] = preset.CompactButtonMinHeightMax,
            ["compact-icon-button-size-max"] = preset.CompactIconButtonSizeMax,
            ["hero-banner-height-max"] = preset.HeroBannerHeightMax,
            ["card-nesting-depth-max"] = preset.CardNestingDepthMax,
            ["dashboard-tile-count-in-toolstrip-max"] = preset.DashboardTileCountInToolstripMax,
            ["decorative-landing-chrome-in-workbench-max"] = preset.DecorativeLandingChromeInWorkbenchMax,
            ["menu-height-max"] = preset.MenuHeightMax,
            ["toolstrip-height-max"] = preset.ToolstripHeightMax,
            ["workspace-context-strip-required"] = preset.WorkspaceContextStripRequired.ToString().ToLowerInvariant(),
            ["tab-strip-height-max"] = preset.TabStripHeightMax,
            ["left-navigation-width-min"] = preset.LeftNavigationWidthMin,
            ["left-navigation-width-max"] = preset.LeftNavigationWidthMax,
            ["right-inspector-width-min"] = preset.RightInspectorWidthMin,
            ["right-inspector-width-max"] = preset.RightInspectorWidthMax,
            ["menu-and-toolstrip-combined-height-max"] = preset.MenuAndToolstripCombinedHeightMax,
            ["status-strip-height-max"] = preset.StatusStripHeightMax,
            ["center-pane-must-dominate"] = preset.CenterPaneMustDominate.ToString().ToLowerInvariant(),
            ["section-rhythm-must-remain-visible"] = preset.SectionRhythmMustRemainVisible.ToString().ToLowerInvariant(),
            ["header-to-content-ratio-max"] = preset.HeaderToContentRatioMax,
            ["dense-list-row-height-max"] = preset.DenseListRowHeightMax,
            ["dense-list-visible-row-min"] = preset.DenseListVisibleRowMin,
            ["dense-detail-group-visible-field-min"] = preset.DenseDetailGroupVisibleFieldMin,
            ["builder-route-visible-rows-1440x900-min"] = preset.BuilderRouteVisibleRowsAt1440x900Min,
            ["builder-route-visible-rows-1366x768-min"] = preset.BuilderRouteVisibleRowsAt1366x768Min,
            ["proof-family-ids"] = string.Join(",", preset.ProofFamilyIds),
            ["chrome-regression-sentinels"] = string.Join(",", preset.ChromeRegressionSentinels),
            ["flagship-default-avalonia"] = preset.FlagshipDefaultForAvalonia.ToString().ToLowerInvariant()
        };

        return new UiAdapterPayload("ClassicDenseWorkbench", new ReadOnlyDictionary<string, string>(attrs));
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
        var noLossPath = ToContractCase(controls.NoLossPath);
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

    public static UiAdapterPayload AdaptActionBudgetBar(ActionBudgetBar budget)
    {
        var kind = budget.Kind.ToString();
        var emphasis = budget.Emphasis.ToString();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "action-budget-bar",
            ["classes"] = $"ActionBudgetBar ActionBudgetBar{emphasis}{(budget.Overdrawn ? " ActionBudgetBarOverdrawn" : string.Empty)}",
            ["label"] = budget.Label,
            ["kind"] = kind,
            ["available"] = budget.Available.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["maximum"] = budget.Maximum.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["pending-cost"] = budget.PendingCost.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["overdrawn"] = budget.Overdrawn.ToString().ToLowerInvariant(),
            ["emphasis"] = emphasis
        };

        if (!string.IsNullOrWhiteSpace(budget.Detail))
        {
            attrs["detail"] = budget.Detail;
        }

        return new UiAdapterPayload("ActionBudgetBar", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptConditionEffectChip(ConditionEffectChip chip)
    {
        var kind = chip.Kind.ToString();
        var tone = chip.Tone.ToString();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "condition-effect-chip",
            ["classes"] = $"ConditionEffectChip ConditionEffectChip{kind} ConditionEffectChip{tone}{(chip.SourceAnchored ? " ConditionEffectChipAnchored" : string.Empty)}",
            ["label"] = chip.Label,
            ["kind"] = kind,
            ["tone"] = tone,
            ["stack-count"] = chip.StackCount.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["source-anchored"] = chip.SourceAnchored.ToString().ToLowerInvariant()
        };

        if (!string.IsNullOrWhiteSpace(chip.Detail))
        {
            attrs["detail"] = chip.Detail;
        }

        return new UiAdapterPayload("ConditionEffectChip", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptSourceAnchorDrawer(SourceAnchorDrawer drawer)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "source-anchor-drawer",
            ["classes"] = $"SourceAnchorDrawer{(drawer.Open ? " SourceAnchorDrawerOpen" : string.Empty)}{(drawer.ConflictWarning ? " SourceAnchorDrawerConflict" : string.Empty)}",
            ["title"] = drawer.Title,
            ["source-short-code"] = drawer.SourceShortCode,
            ["location-label"] = drawer.LocationLabel,
            ["anchor-id"] = drawer.AnchorId,
            ["open"] = drawer.Open.ToString().ToLowerInvariant(),
            ["conflict-warning"] = drawer.ConflictWarning.ToString().ToLowerInvariant()
        };

        if (!string.IsNullOrWhiteSpace(drawer.Excerpt))
        {
            attrs["excerpt"] = drawer.Excerpt;
        }

        if (!string.IsNullOrWhiteSpace(drawer.SupportLabel))
        {
            attrs["support-label"] = drawer.SupportLabel;
        }

        return new UiAdapterPayload("SourceAnchorDrawer", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptRunboardCard(RunboardCard card)
    {
        var kind = card.Kind.ToString();
        var priority = card.Priority.ToString();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["part"] = "runboard-card",
            ["classes"] = $"RunboardCard RunboardCard{kind} RunboardCard{priority}{(card.RequiresAttention ? " RunboardCardAttention" : string.Empty)}",
            ["title"] = card.Title,
            ["summary"] = card.Summary,
            ["kind"] = kind,
            ["priority"] = priority,
            ["item-count"] = card.ItemCount.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["requires-attention"] = card.RequiresAttention.ToString().ToLowerInvariant()
        };

        if (!string.IsNullOrWhiteSpace(card.MetricLabel))
        {
            attrs["metric-label"] = card.MetricLabel;
        }

        if (!string.IsNullOrWhiteSpace(card.Detail))
        {
            attrs["detail"] = card.Detail;
        }

        return new UiAdapterPayload("RunboardCard", new ReadOnlyDictionary<string, string>(attrs));
    }

    private static string ToContractCase(LongRunningControlId controlId)
    {
        return controlId switch
        {
            LongRunningControlId.Retry => "retry",
            LongRunningControlId.Cancel => "cancel",
            LongRunningControlId.Rollback => "rollback",
            LongRunningControlId.SafeContinuation => "safe-continuation",
            _ => controlId.ToString()
        };
    }
}
