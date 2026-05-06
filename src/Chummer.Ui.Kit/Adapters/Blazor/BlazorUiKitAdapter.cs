using Chummer.Ui.Kit.Adapters;
using System.Collections.ObjectModel;

namespace Chummer.Ui.Kit.Blazor.Adapters;

public static class BlazorUiKitAdapter
{
    public static UiAdapterPayload AdaptDenseTableHeader(DenseTableHeader header)
    {
        var effectiveDirection = header.Sortable ? header.SortDirection : DenseSortDirection.None;
        var direction = effectiveDirection.ToString().ToLowerInvariant();
        var ariaSort = effectiveDirection switch
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

    public static UiAdapterPayload AdaptClassicDenseWorkbenchPreset(ClassicDenseWorkbenchPreset preset)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "region",
            ["aria-label"] = "Classic dense workbench preset",
            ["data-preset-id"] = preset.PresetId,
            ["data-dense-workbench-budget-version"] = preset.DenseWorkbenchBudgetVersion,
            ["data-top-menu-bar-enabled"] = preset.TopMenuBarEnabled.ToString().ToLowerInvariant(),
            ["data-toolstrip-enabled"] = preset.ToolstripEnabled.ToString().ToLowerInvariant(),
            ["data-tab-strip-density"] = preset.TabStripDensity,
            ["data-compact-list-detail-panes"] = preset.CompactListDetailPanes.ToString().ToLowerInvariant(),
            ["data-compact-inspector-forms"] = preset.CompactInspectorForms.ToString().ToLowerInvariant(),
            ["data-status-strip-posture"] = preset.StatusStripPosture,
            ["data-compact-spacing-scale"] = preset.CompactSpacingScale,
            ["data-compact-header-scale"] = preset.CompactHeaderScale,
            ["data-row-spacing-max"] = preset.RowSpacingMax,
            ["data-card-padding-max"] = preset.CardPaddingMax,
            ["data-input-padding-horizontal-max"] = preset.InputPaddingHorizontalMax,
            ["data-input-padding-vertical-max"] = preset.InputPaddingVerticalMax,
            ["data-banner-height-ceiling"] = preset.BannerHeightCeiling,
            ["data-badge-density-ceiling"] = preset.BadgeDensityCeiling,
            ["data-persistent-banner-count-max"] = preset.PersistentBannerCountMax,
            ["data-persistent-secondary-badge-cluster-max"] = preset.PersistentSecondaryBadgeClusterMax,
            ["data-compact-field-height"] = preset.CompactFieldHeight,
            ["data-compact-button-height"] = preset.CompactButtonHeight,
            ["data-compact-button-min-height-max"] = preset.CompactButtonMinHeightMax,
            ["data-compact-icon-button-size-max"] = preset.CompactIconButtonSizeMax,
            ["data-hero-banner-height-max"] = preset.HeroBannerHeightMax,
            ["data-card-nesting-depth-max"] = preset.CardNestingDepthMax,
            ["data-dashboard-tile-count-in-toolstrip-max"] = preset.DashboardTileCountInToolstripMax,
            ["data-decorative-landing-chrome-in-workbench-max"] = preset.DecorativeLandingChromeInWorkbenchMax,
            ["data-menu-height-max"] = preset.MenuHeightMax,
            ["data-toolstrip-height-max"] = preset.ToolstripHeightMax,
            ["data-workspace-context-strip-required"] = preset.WorkspaceContextStripRequired.ToString().ToLowerInvariant(),
            ["data-tab-strip-height-max"] = preset.TabStripHeightMax,
            ["data-left-navigation-width-min"] = preset.LeftNavigationWidthMin,
            ["data-left-navigation-width-max"] = preset.LeftNavigationWidthMax,
            ["data-right-inspector-width-min"] = preset.RightInspectorWidthMin,
            ["data-right-inspector-width-max"] = preset.RightInspectorWidthMax,
            ["data-menu-and-toolstrip-combined-height-max"] = preset.MenuAndToolstripCombinedHeightMax,
            ["data-status-strip-height-max"] = preset.StatusStripHeightMax,
            ["data-center-pane-must-dominate"] = preset.CenterPaneMustDominate.ToString().ToLowerInvariant(),
            ["data-section-rhythm-must-remain-visible"] = preset.SectionRhythmMustRemainVisible.ToString().ToLowerInvariant(),
            ["data-header-to-content-ratio-max"] = preset.HeaderToContentRatioMax,
            ["data-dense-list-row-height-max"] = preset.DenseListRowHeightMax,
            ["data-dense-list-visible-row-min"] = preset.DenseListVisibleRowMin,
            ["data-dense-detail-group-visible-field-min"] = preset.DenseDetailGroupVisibleFieldMin,
            ["data-builder-route-visible-rows-1440x900-min"] = preset.BuilderRouteVisibleRowsAt1440x900Min,
            ["data-builder-route-visible-rows-1366x768-min"] = preset.BuilderRouteVisibleRowsAt1366x768Min,
            ["data-proof-family-ids"] = string.Join(",", preset.ProofFamilyIds),
            ["data-chrome-regression-sentinels"] = string.Join(",", preset.ChromeRegressionSentinels),
            ["data-flagship-default-avalonia"] = preset.FlagshipDefaultForAvalonia.ToString().ToLowerInvariant(),
            ["class"] = "chummer-classic-dense-workbench"
        };

        return new UiAdapterPayload("chummer-classic-dense-workbench", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptRoleTransition(RoleTransition transition)
    {
        var phase = transition.Phase.ToString().ToLowerInvariant();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "status",
            ["aria-live"] = "polite",
            ["data-from-role"] = transition.FromRole,
            ["data-to-role"] = transition.ToRole,
            ["data-phase"] = phase,
            ["data-requires-ack"] = transition.RequiresAcknowledgement.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-role-transition chummer-role-transition-{phase}"
        };

        if (!string.IsNullOrWhiteSpace(transition.Detail))
        {
            attrs["data-detail"] = transition.Detail;
        }

        return new UiAdapterPayload("chummer-role-transition", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptProgressToast(ProgressToast toast)
    {
        var tone = toast.Tone.ToString().ToLowerInvariant();
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "progressbar",
            ["aria-live"] = "polite",
            ["aria-label"] = toast.Title,
            ["aria-valuemin"] = "0",
            ["aria-valuemax"] = "100",
            ["aria-valuenow"] = toast.ProgressPercent.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["data-title"] = toast.Title,
            ["data-progress-label"] = toast.ProgressLabel,
            ["data-progress-percent"] = toast.ProgressPercent.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["data-tone"] = tone,
            ["data-allow-cancel"] = toast.AllowCancel.ToString().ToLowerInvariant(),
            ["data-allow-resume"] = toast.AllowResume.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-progress-toast chummer-progress-toast-{tone}"
        };

        return new UiAdapterPayload("chummer-progress-toast", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptResumeAffordance(ResumeAffordance affordance)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "region",
            ["aria-live"] = "polite",
            ["aria-label"] = affordance.Title,
            ["data-title"] = affordance.Title,
            ["data-checkpoint"] = affordance.CheckpointLabel,
            ["data-resume-action"] = affordance.ResumeActionLabel,
            ["data-requires-recovery"] = affordance.RequiresRecovery.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-resume-affordance{(affordance.RequiresRecovery ? " chummer-resume-affordance-recovery" : string.Empty)}"
        };

        if (!string.IsNullOrWhiteSpace(affordance.Detail))
        {
            attrs["data-detail"] = affordance.Detail;
        }

        return new UiAdapterPayload("chummer-resume-affordance", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptGuidanceState(GuidanceState state)
    {
        var kind = ToContractCase(state.Kind);
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "region",
            ["aria-live"] = state.Kind is GuidanceStateKind.Recovery or GuidanceStateKind.Error ? "assertive" : "polite",
            ["aria-label"] = state.Title,
            ["data-state-kind"] = kind,
            ["data-title"] = state.Title,
            ["data-body"] = state.Body,
            ["data-primary-action"] = state.PrimaryActionLabel,
            ["class"] = $"chummer-guidance-state chummer-guidance-state-{kind}"
        };

        if (!string.IsNullOrWhiteSpace(state.SecondaryActionLabel))
        {
            attrs["data-secondary-action"] = state.SecondaryActionLabel;
        }

        if (!string.IsNullOrWhiteSpace(state.Detail))
        {
            attrs["data-detail"] = state.Detail;
        }

        return new UiAdapterPayload("chummer-guidance-state", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptLongRunningActionControls(LongRunningActionControls controls)
    {
        var noLossPath = ToContractCase(controls.NoLossPath);
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "group",
            ["aria-live"] = "polite",
            ["data-action-dictionary"] = controls.ActionDictionaryReference,
            ["data-no-loss-path"] = noLossPath,
            ["data-retry-label"] = controls.RetryLabel,
            ["data-retry-enabled"] = controls.RetryEnabled.ToString().ToLowerInvariant(),
            ["data-retry-lossless"] = (controls.NoLossPath == LongRunningControlId.Retry).ToString().ToLowerInvariant(),
            ["data-cancel-label"] = controls.CancelLabel,
            ["data-cancel-enabled"] = controls.CancelEnabled.ToString().ToLowerInvariant(),
            ["data-cancel-lossless"] = (controls.NoLossPath == LongRunningControlId.Cancel).ToString().ToLowerInvariant(),
            ["data-rollback-label"] = controls.RollbackLabel,
            ["data-rollback-enabled"] = controls.RollbackEnabled.ToString().ToLowerInvariant(),
            ["data-rollback-lossless"] = (controls.NoLossPath == LongRunningControlId.Rollback).ToString().ToLowerInvariant(),
            ["data-safe-continuation-label"] = controls.SafeContinuationLabel,
            ["data-safe-continuation-enabled"] = controls.SafeContinuationEnabled.ToString().ToLowerInvariant(),
            ["data-safe-continuation-lossless"] = (controls.NoLossPath == LongRunningControlId.SafeContinuation).ToString().ToLowerInvariant(),
            ["class"] = "chummer-action-controls"
        };

        if (!string.IsNullOrWhiteSpace(controls.Detail))
        {
            attrs["data-detail"] = controls.Detail;
        }

        return new UiAdapterPayload("chummer-action-controls", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptActionBudgetBar(ActionBudgetBar budget)
    {
        var kind = ToContractCase(budget.Kind);
        var emphasis = ToContractCase(budget.Emphasis);
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "progressbar",
            ["aria-label"] = $"{budget.Label} action budget",
            ["aria-valuemin"] = "0",
            ["aria-valuemax"] = budget.Maximum.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["aria-valuenow"] = budget.Available.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["data-label"] = budget.Label,
            ["data-kind"] = kind,
            ["data-available"] = budget.Available.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["data-maximum"] = budget.Maximum.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["data-pending-cost"] = budget.PendingCost.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["data-overdrawn"] = budget.Overdrawn.ToString().ToLowerInvariant(),
            ["data-emphasis"] = emphasis,
            ["class"] = $"chummer-action-budget-bar chummer-action-budget-bar-{emphasis}{(budget.Overdrawn ? " chummer-action-budget-bar-overdrawn" : string.Empty)}"
        };

        if (!string.IsNullOrWhiteSpace(budget.Detail))
        {
            attrs["data-detail"] = budget.Detail;
        }

        return new UiAdapterPayload("chummer-action-budget-bar", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptConditionEffectChip(ConditionEffectChip chip)
    {
        var kind = ToContractCase(chip.Kind);
        var tone = ToContractCase(chip.Tone);
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "status",
            ["aria-label"] = chip.StackCount == 1 ? chip.Label : $"{chip.Label} x{chip.StackCount.ToString(System.Globalization.CultureInfo.InvariantCulture)}",
            ["data-label"] = chip.Label,
            ["data-kind"] = kind,
            ["data-tone"] = tone,
            ["data-stack-count"] = chip.StackCount.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["data-source-anchored"] = chip.SourceAnchored.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-condition-effect-chip chummer-condition-effect-chip-{kind} chummer-condition-effect-chip-{tone}{(chip.SourceAnchored ? " chummer-condition-effect-chip-source-anchored" : string.Empty)}"
        };

        if (!string.IsNullOrWhiteSpace(chip.Detail))
        {
            attrs["data-detail"] = chip.Detail;
        }

        return new UiAdapterPayload("chummer-condition-effect-chip", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptSourceAnchorDrawer(SourceAnchorDrawer drawer)
    {
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "complementary",
            ["aria-label"] = drawer.Title,
            ["data-title"] = drawer.Title,
            ["data-source-short-code"] = drawer.SourceShortCode,
            ["data-location-label"] = drawer.LocationLabel,
            ["data-anchor-id"] = drawer.AnchorId,
            ["data-open"] = drawer.Open.ToString().ToLowerInvariant(),
            ["data-conflict-warning"] = drawer.ConflictWarning.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-source-anchor-drawer{(drawer.Open ? " chummer-source-anchor-drawer-open" : string.Empty)}{(drawer.ConflictWarning ? " chummer-source-anchor-drawer-conflict" : string.Empty)}"
        };

        if (!string.IsNullOrWhiteSpace(drawer.Excerpt))
        {
            attrs["data-excerpt"] = drawer.Excerpt;
        }

        if (!string.IsNullOrWhiteSpace(drawer.SupportLabel))
        {
            attrs["data-support-label"] = drawer.SupportLabel;
        }

        return new UiAdapterPayload("chummer-source-anchor-drawer", new ReadOnlyDictionary<string, string>(attrs));
    }

    public static UiAdapterPayload AdaptRunboardCard(RunboardCard card)
    {
        var kind = ToContractCase(card.Kind);
        var priority = ToContractCase(card.Priority);
        var attrs = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "group",
            ["aria-label"] = card.Title,
            ["data-title"] = card.Title,
            ["data-summary"] = card.Summary,
            ["data-kind"] = kind,
            ["data-priority"] = priority,
            ["data-item-count"] = card.ItemCount.ToString(System.Globalization.CultureInfo.InvariantCulture),
            ["data-requires-attention"] = card.RequiresAttention.ToString().ToLowerInvariant(),
            ["class"] = $"chummer-runboard-card chummer-runboard-card-{kind} chummer-runboard-card-{priority}{(card.RequiresAttention ? " chummer-runboard-card-attention" : string.Empty)}"
        };

        if (!string.IsNullOrWhiteSpace(card.MetricLabel))
        {
            attrs["data-metric-label"] = card.MetricLabel;
        }

        if (!string.IsNullOrWhiteSpace(card.Detail))
        {
            attrs["data-detail"] = card.Detail;
        }

        return new UiAdapterPayload("chummer-runboard-card", new ReadOnlyDictionary<string, string>(attrs));
    }

    private static string ToContractCase(GuidanceStateKind kind) => kind switch
    {
        GuidanceStateKind.Error => "error",
        GuidanceStateKind.EmptyState => "empty-state",
        GuidanceStateKind.FirstRun => "first-run",
        GuidanceStateKind.Onboarding => "onboarding",
        GuidanceStateKind.Recovery => "recovery",
        _ => kind.ToString().ToLowerInvariant()
    };

    private static string ToContractCase(LongRunningControlId id) => id switch
    {
        LongRunningControlId.SafeContinuation => "safe-continuation",
        LongRunningControlId.Retry => "retry",
        LongRunningControlId.Cancel => "cancel",
        LongRunningControlId.Rollback => "rollback",
        _ => id.ToString().ToLowerInvariant()
    };

    private static string ToContractCase(ActionBudgetKind kind) => kind switch
    {
        ActionBudgetKind.Major => "major",
        ActionBudgetKind.Minor => "minor",
        ActionBudgetKind.Reaction => "reaction",
        ActionBudgetKind.Edge => "edge",
        _ => kind.ToString().ToLowerInvariant()
    };

    private static string ToContractCase(ActionBudgetEmphasis emphasis) => emphasis switch
    {
        ActionBudgetEmphasis.Steady => "steady",
        ActionBudgetEmphasis.Ready => "ready",
        ActionBudgetEmphasis.Warning => "warning",
        ActionBudgetEmphasis.Critical => "critical",
        _ => emphasis.ToString().ToLowerInvariant()
    };

    private static string ToContractCase(ConditionEffectKind kind) => kind switch
    {
        ConditionEffectKind.Condition => "condition",
        ConditionEffectKind.Effect => "effect",
        ConditionEffectKind.Modifier => "modifier",
        ConditionEffectKind.Warning => "warning",
        _ => kind.ToString().ToLowerInvariant()
    };

    private static string ToContractCase(ConditionEffectTone tone) => tone switch
    {
        ConditionEffectTone.Neutral => "neutral",
        ConditionEffectTone.Info => "info",
        ConditionEffectTone.Success => "success",
        ConditionEffectTone.Warning => "warning",
        ConditionEffectTone.Danger => "danger",
        _ => tone.ToString().ToLowerInvariant()
    };

    private static string ToContractCase(RunboardCardKind kind) => kind switch
    {
        RunboardCardKind.Initiative => "initiative",
        RunboardCardKind.Objective => "objective",
        RunboardCardKind.Opposition => "opposition",
        RunboardCardKind.Heat => "heat",
        RunboardCardKind.Resolution => "resolution",
        _ => kind.ToString().ToLowerInvariant()
    };

    private static string ToContractCase(RunboardCardPriority priority) => priority switch
    {
        RunboardCardPriority.Standard => "standard",
        RunboardCardPriority.Raised => "raised",
        RunboardCardPriority.Critical => "critical",
        _ => priority.ToString().ToLowerInvariant()
    };
}
