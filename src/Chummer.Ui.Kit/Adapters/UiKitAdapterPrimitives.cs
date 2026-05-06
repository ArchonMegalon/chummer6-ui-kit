using System.Collections.ObjectModel;
using Chummer.Ui.Kit.Tokens;

namespace Chummer.Ui.Kit.Adapters;

public enum ShellChromeTone
{
    Default,
    Focused,
    Warning,
    Error,
    Success
}

public enum BannerTone
{
    Info,
    Warning,
    Error,
    Success
}

public enum StaleState
{
    Fresh,
    Stale,
    Unknown,
    Failed
}

public sealed class ShellChrome
{
    public ShellChrome(string title, string body, ShellChromeTone tone = ShellChromeTone.Default, bool compact = false)
    {
        Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("Title is required.", nameof(title)) : title.Trim();
        Body = string.IsNullOrWhiteSpace(body) ? throw new ArgumentException("Body is required.", nameof(body)) : body.Trim();
        Tone = tone;
        Compact = compact;
    }

    public string Title { get; }
    public string Body { get; }
    public ShellChromeTone Tone { get; }
    public bool Compact { get; }
}

public sealed class Banner
{
    public Banner(string headline, string body, BannerTone tone = BannerTone.Info, bool pinned = false)
    {
        Headline = string.IsNullOrWhiteSpace(headline) ? throw new ArgumentException("Headline is required.", nameof(headline)) : headline.Trim();
        Body = string.IsNullOrWhiteSpace(body) ? throw new ArgumentException("Body is required.", nameof(body)) : body.Trim();
        Tone = tone;
        Pinned = pinned;
    }

    public string Headline { get; }
    public string Body { get; }
    public BannerTone Tone { get; }
    public bool Pinned { get; }
}

public sealed class StaleStateBadge
{
    public StaleStateBadge(StaleState state, string? detail = null)
    {
        State = state;
        Detail = string.IsNullOrWhiteSpace(detail) ? null : detail.Trim();
    }

    public StaleState State { get; }
    public string? Detail { get; }
}

public sealed class ApprovalChip
{
    public ApprovalChip(bool isApproved, string label, string? approver = null)
    {
        IsApproved = isApproved;
        Label = string.IsNullOrWhiteSpace(label) ? throw new ArgumentException("Label is required.", nameof(label)) : label.Trim();
        Approver = string.IsNullOrWhiteSpace(approver) ? null : approver.Trim();
    }

    public bool IsApproved { get; }
    public string Label { get; }
    public string? Approver { get; }
}

public sealed class OfflineBanner
{
    public OfflineBanner(string service, bool isOffline)
    {
        Service = string.IsNullOrWhiteSpace(service) ? throw new ArgumentException("Service is required.", nameof(service)) : service.Trim();
        IsOffline = isOffline;
    }

    public string Service { get; }
    public bool IsOffline { get; }
}

public sealed class AccessibilityState
{
    public AccessibilityState(string liveRegion = "polite", bool busy = false, bool disabled = false, string? label = null, string? describedBy = null)
    {
        LiveRegion = string.IsNullOrWhiteSpace(liveRegion) ? "polite" : liveRegion.Trim();
        Busy = busy;
        Disabled = disabled;
        Label = string.IsNullOrWhiteSpace(label) ? null : label.Trim();
        DescribedBy = string.IsNullOrWhiteSpace(describedBy) ? null : describedBy.Trim();
    }

    public string LiveRegion { get; }
    public bool Busy { get; }
    public bool Disabled { get; }
    public string? Label { get; }
    public string? DescribedBy { get; }
}

public enum RoleTransitionPhase
{
    Announced,
    InProgress,
    Completed,
    Blocked
}

public sealed class RoleTransition
{
    public RoleTransition(
        string fromRole,
        string toRole,
        RoleTransitionPhase phase = RoleTransitionPhase.Announced,
        bool requiresAcknowledgement = false,
        string? detail = null)
    {
        FromRole = string.IsNullOrWhiteSpace(fromRole) ? throw new ArgumentException("From role is required.", nameof(fromRole)) : fromRole.Trim();
        ToRole = string.IsNullOrWhiteSpace(toRole) ? throw new ArgumentException("To role is required.", nameof(toRole)) : toRole.Trim();
        Phase = phase;
        RequiresAcknowledgement = requiresAcknowledgement;
        Detail = string.IsNullOrWhiteSpace(detail) ? null : detail.Trim();
    }

    public string FromRole { get; }
    public string ToRole { get; }
    public RoleTransitionPhase Phase { get; }
    public bool RequiresAcknowledgement { get; }
    public string? Detail { get; }
}

public enum ProgressToastTone
{
    Neutral,
    Info,
    Success,
    Warning,
    Error
}

public sealed class ProgressToast
{
    public ProgressToast(
        string title,
        string progressLabel,
        int progressPercent,
        ProgressToastTone tone = ProgressToastTone.Info,
        bool allowCancel = false,
        bool allowResume = false)
    {
        Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("Title is required.", nameof(title)) : title.Trim();
        ProgressLabel = string.IsNullOrWhiteSpace(progressLabel) ? throw new ArgumentException("Progress label is required.", nameof(progressLabel)) : progressLabel.Trim();
        ProgressPercent = progressPercent is < 0 or > 100 ? throw new ArgumentOutOfRangeException(nameof(progressPercent), "Progress percent must be between 0 and 100.") : progressPercent;
        Tone = tone;
        AllowCancel = allowCancel;
        AllowResume = allowResume;
    }

    public string Title { get; }
    public string ProgressLabel { get; }
    public int ProgressPercent { get; }
    public ProgressToastTone Tone { get; }
    public bool AllowCancel { get; }
    public bool AllowResume { get; }
}

public sealed class ResumeAffordance
{
    public ResumeAffordance(
        string title,
        string checkpointLabel,
        string resumeActionLabel,
        bool requiresRecovery = false,
        string? detail = null)
    {
        Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("Title is required.", nameof(title)) : title.Trim();
        CheckpointLabel = string.IsNullOrWhiteSpace(checkpointLabel) ? throw new ArgumentException("Checkpoint label is required.", nameof(checkpointLabel)) : checkpointLabel.Trim();
        ResumeActionLabel = string.IsNullOrWhiteSpace(resumeActionLabel) ? throw new ArgumentException("Resume action label is required.", nameof(resumeActionLabel)) : resumeActionLabel.Trim();
        RequiresRecovery = requiresRecovery;
        Detail = string.IsNullOrWhiteSpace(detail) ? null : detail.Trim();
    }

    public string Title { get; }
    public string CheckpointLabel { get; }
    public string ResumeActionLabel { get; }
    public bool RequiresRecovery { get; }
    public string? Detail { get; }
}

public enum GuidanceStateKind
{
    Onboarding,
    Error,
    EmptyState,
    Recovery,
    FirstRun
}

public sealed class GuidanceState
{
    public GuidanceState(
        GuidanceStateKind kind,
        string title,
        string body,
        string primaryActionLabel,
        string? secondaryActionLabel = null,
        string? detail = null)
    {
        Kind = kind;
        Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("Title is required.", nameof(title)) : title.Trim();
        Body = string.IsNullOrWhiteSpace(body) ? throw new ArgumentException("Body is required.", nameof(body)) : body.Trim();
        PrimaryActionLabel = PrimitiveGuards.NormalizeLocaleSafeLabel(primaryActionLabel, nameof(primaryActionLabel));
        SecondaryActionLabel = string.IsNullOrWhiteSpace(secondaryActionLabel) ? null : PrimitiveGuards.NormalizeLocaleSafeLabel(secondaryActionLabel, nameof(secondaryActionLabel));
        Detail = string.IsNullOrWhiteSpace(detail) ? null : detail.Trim();
    }

    public GuidanceStateKind Kind { get; }
    public string Title { get; }
    public string Body { get; }
    public string PrimaryActionLabel { get; }
    public string? SecondaryActionLabel { get; }
    public string? Detail { get; }
}

public enum LongRunningControlId
{
    Retry,
    Cancel,
    Rollback,
    SafeContinuation
}

public sealed class LongRunningActionControls
{
    public LongRunningActionControls(
        string retryLabel,
        string cancelLabel,
        string rollbackLabel,
        string safeContinuationLabel,
        LongRunningControlId noLossPath = LongRunningControlId.SafeContinuation,
        bool retryEnabled = true,
        bool cancelEnabled = true,
        bool rollbackEnabled = true,
        bool safeContinuationEnabled = true,
        string actionDictionaryReference = "design/DR-129",
        string? detail = null)
    {
        RetryLabel = PrimitiveGuards.NormalizeLocaleSafeLabel(retryLabel, nameof(retryLabel));
        CancelLabel = PrimitiveGuards.NormalizeLocaleSafeLabel(cancelLabel, nameof(cancelLabel));
        RollbackLabel = PrimitiveGuards.NormalizeLocaleSafeLabel(rollbackLabel, nameof(rollbackLabel));
        SafeContinuationLabel = PrimitiveGuards.NormalizeLocaleSafeLabel(safeContinuationLabel, nameof(safeContinuationLabel));
        RetryEnabled = retryEnabled;
        CancelEnabled = cancelEnabled;
        RollbackEnabled = rollbackEnabled;
        SafeContinuationEnabled = safeContinuationEnabled;
        NoLossPath = noLossPath;
        ActionDictionaryReference = string.IsNullOrWhiteSpace(actionDictionaryReference)
            ? throw new ArgumentException("Action dictionary reference is required.", nameof(actionDictionaryReference))
            : actionDictionaryReference.Trim();
        Detail = string.IsNullOrWhiteSpace(detail) ? null : detail.Trim();

        if (!IsEnabled(noLossPath))
        {
            throw new ArgumentException("No-loss path must point to an enabled action.", nameof(noLossPath));
        }
    }

    public string RetryLabel { get; }
    public string CancelLabel { get; }
    public string RollbackLabel { get; }
    public string SafeContinuationLabel { get; }
    public bool RetryEnabled { get; }
    public bool CancelEnabled { get; }
    public bool RollbackEnabled { get; }
    public bool SafeContinuationEnabled { get; }
    public LongRunningControlId NoLossPath { get; }
    public string ActionDictionaryReference { get; }
    public string? Detail { get; }

    public bool IsEnabled(LongRunningControlId id) => id switch
    {
        LongRunningControlId.Retry => RetryEnabled,
        LongRunningControlId.Cancel => CancelEnabled,
        LongRunningControlId.Rollback => RollbackEnabled,
        LongRunningControlId.SafeContinuation => SafeContinuationEnabled,
        _ => false
    };
}

public enum ActionBudgetKind
{
    Major,
    Minor,
    Reaction,
    Edge
}

public enum ActionBudgetEmphasis
{
    Steady,
    Ready,
    Warning,
    Critical
}

public sealed class ActionBudgetBar
{
    public ActionBudgetBar(
        string label,
        ActionBudgetKind kind,
        int available,
        int maximum,
        int pendingCost = 0,
        ActionBudgetEmphasis emphasis = ActionBudgetEmphasis.Steady,
        string? detail = null)
    {
        Label = PrimitiveGuards.NormalizeLocaleSafeLabel(label, nameof(label));
        Kind = kind;
        Available = PrimitiveGuards.NormalizeCount(available, nameof(available));
        Maximum = PrimitiveGuards.NormalizePositiveCount(maximum, nameof(maximum));
        PendingCost = PrimitiveGuards.NormalizeCount(pendingCost, nameof(pendingCost));
        Emphasis = emphasis;
        Detail = string.IsNullOrWhiteSpace(detail) ? null : detail.Trim();

        if (Available > Maximum)
        {
            throw new ArgumentOutOfRangeException(nameof(available), "Available actions cannot exceed the maximum.");
        }
    }

    public string Label { get; }
    public ActionBudgetKind Kind { get; }
    public int Available { get; }
    public int Maximum { get; }
    public int PendingCost { get; }
    public ActionBudgetEmphasis Emphasis { get; }
    public string? Detail { get; }
    public bool Overdrawn => PendingCost > Available;
}

public enum ConditionEffectKind
{
    Condition,
    Effect,
    Modifier,
    Warning
}

public enum ConditionEffectTone
{
    Neutral,
    Info,
    Success,
    Warning,
    Danger
}

public sealed class ConditionEffectChip
{
    public ConditionEffectChip(
        string label,
        ConditionEffectKind kind = ConditionEffectKind.Effect,
        ConditionEffectTone tone = ConditionEffectTone.Neutral,
        int stackCount = 1,
        bool sourceAnchored = false,
        string? detail = null)
    {
        Label = PrimitiveGuards.NormalizeLocaleSafeLabel(label, nameof(label));
        Kind = kind;
        Tone = tone;
        StackCount = PrimitiveGuards.NormalizePositiveCount(stackCount, nameof(stackCount));
        SourceAnchored = sourceAnchored;
        Detail = string.IsNullOrWhiteSpace(detail) ? null : detail.Trim();
    }

    public string Label { get; }
    public ConditionEffectKind Kind { get; }
    public ConditionEffectTone Tone { get; }
    public int StackCount { get; }
    public bool SourceAnchored { get; }
    public string? Detail { get; }
}

public sealed class SourceAnchorDrawer
{
    public SourceAnchorDrawer(
        string title,
        string sourceShortCode,
        string locationLabel,
        string anchorId,
        bool open = false,
        bool conflictWarning = false,
        string? excerpt = null,
        string? supportLabel = null)
    {
        Title = PrimitiveGuards.NormalizeLocaleSafeLabel(title, nameof(title));
        SourceShortCode = PrimitiveGuards.NormalizeLocaleSafeLabel(sourceShortCode, nameof(sourceShortCode));
        LocationLabel = PrimitiveGuards.NormalizeLocaleSafeLabel(locationLabel, nameof(locationLabel));
        AnchorId = PrimitiveGuards.NormalizeContractId(anchorId, nameof(anchorId));
        Open = open;
        ConflictWarning = conflictWarning;
        Excerpt = string.IsNullOrWhiteSpace(excerpt) ? null : excerpt.Trim();
        SupportLabel = string.IsNullOrWhiteSpace(supportLabel) ? null : PrimitiveGuards.NormalizeLocaleSafeLabel(supportLabel, nameof(supportLabel));
    }

    public string Title { get; }
    public string SourceShortCode { get; }
    public string LocationLabel { get; }
    public string AnchorId { get; }
    public bool Open { get; }
    public bool ConflictWarning { get; }
    public string? Excerpt { get; }
    public string? SupportLabel { get; }
}

public enum RunboardCardKind
{
    Initiative,
    Objective,
    Opposition,
    Heat,
    Resolution
}

public enum RunboardCardPriority
{
    Standard,
    Raised,
    Critical
}

public sealed class RunboardCard
{
    public RunboardCard(
        string title,
        string summary,
        RunboardCardKind kind = RunboardCardKind.Objective,
        RunboardCardPriority priority = RunboardCardPriority.Standard,
        string? metricLabel = null,
        int itemCount = 0,
        bool requiresAttention = false,
        string? detail = null)
    {
        Title = PrimitiveGuards.NormalizeLocaleSafeLabel(title, nameof(title));
        Summary = PrimitiveGuards.NormalizeLocaleSafeLabel(summary, nameof(summary));
        Kind = kind;
        Priority = priority;
        MetricLabel = string.IsNullOrWhiteSpace(metricLabel) ? null : PrimitiveGuards.NormalizeLocaleSafeLabel(metricLabel, nameof(metricLabel));
        ItemCount = PrimitiveGuards.NormalizeCount(itemCount, nameof(itemCount));
        RequiresAttention = requiresAttention;
        Detail = string.IsNullOrWhiteSpace(detail) ? null : detail.Trim();
    }

    public string Title { get; }
    public string Summary { get; }
    public RunboardCardKind Kind { get; }
    public RunboardCardPriority Priority { get; }
    public string? MetricLabel { get; }
    public int ItemCount { get; }
    public bool RequiresAttention { get; }
    public string? Detail { get; }
}

public sealed class ClassicDenseWorkbenchPreset
{
    private static readonly string[] RequiredProofFamilyIds =
    {
        "family:dense_builder_and_career_workflows",
        "family:dice_initiative_and_table_utilities",
        "family:identity_contacts_lifestyles_history",
    };

    public ClassicDenseWorkbenchPreset()
        : this(TokenCanon.CreateDefault())
    {
    }

    public static ClassicDenseWorkbenchPreset CreateFlagshipDesktopDefault(TokenCanon? tokenCanon = null) =>
        new(tokenCanon ?? TokenCanon.CreateDefault());

    public ClassicDenseWorkbenchPreset(
        string presetId = "classic_dense_workbench",
        string denseWorkbenchBudgetVersion = "2026-04-16",
        bool topMenuBarEnabled = true,
        bool toolstripEnabled = true,
        string tabStripDensity = "compact",
        bool compactListDetailPanes = true,
        bool compactInspectorForms = true,
        string statusStripPosture = "permanent",
        string compactSpacingScale = "0.85",
        string compactHeaderScale = "0.90",
        string rowSpacingMax = "6",
        string cardPaddingMax = "10",
        string inputPaddingHorizontalMax = "8",
        string inputPaddingVerticalMax = "6",
        string bannerHeightCeiling = "2.50rem",
        string badgeDensityCeiling = "3",
        string persistentBannerCountMax = "1",
        string persistentSecondaryBadgeClusterMax = "3",
        string compactFieldHeight = "1.875rem",
        string compactButtonHeight = "1.875rem",
        string compactButtonMinHeightMax = "32",
        string compactIconButtonSizeMax = "32",
        string heroBannerHeightMax = "0",
        string cardNestingDepthMax = "2",
        string dashboardTileCountInToolstripMax = "0",
        string decorativeLandingChromeInWorkbenchMax = "0",
        string menuHeightMax = "32",
        string toolstripHeightMax = "40",
        bool workspaceContextStripRequired = true,
        string tabStripHeightMax = "30",
        string leftNavigationWidthMin = "180",
        string leftNavigationWidthMax = "240",
        string rightInspectorWidthMin = "260",
        string rightInspectorWidthMax = "340",
        string menuAndToolstripCombinedHeightMax = "72",
        string statusStripHeightMax = "26",
        bool centerPaneMustDominate = true,
        bool sectionRhythmMustRemainVisible = true,
        string headerToContentRatioMax = "0.30",
        string denseListRowHeightMax = "32",
        string denseListVisibleRowMin = "9",
        string denseDetailGroupVisibleFieldMin = "6",
        string builderRouteVisibleRowsAt1440x900Min = "12",
        string builderRouteVisibleRowsAt1366x768Min = "9",
        IReadOnlyList<string>? proofFamilyIds = null,
        IReadOnlyList<string>? chromeRegressionSentinels = null,
        bool flagshipDefaultForAvalonia = true)
    {
        PresetId = string.IsNullOrWhiteSpace(presetId) ? throw new ArgumentException("Preset id is required.", nameof(presetId)) : presetId.Trim();
        DenseWorkbenchBudgetVersion = string.IsNullOrWhiteSpace(denseWorkbenchBudgetVersion) ? throw new ArgumentException("Dense workbench budget version is required.", nameof(denseWorkbenchBudgetVersion)) : denseWorkbenchBudgetVersion.Trim();
        TopMenuBarEnabled = topMenuBarEnabled;
        ToolstripEnabled = toolstripEnabled;
        TabStripDensity = string.IsNullOrWhiteSpace(tabStripDensity) ? throw new ArgumentException("Tab strip density is required.", nameof(tabStripDensity)) : tabStripDensity.Trim();
        CompactListDetailPanes = compactListDetailPanes;
        CompactInspectorForms = compactInspectorForms;
        StatusStripPosture = string.IsNullOrWhiteSpace(statusStripPosture) ? throw new ArgumentException("Status strip posture is required.", nameof(statusStripPosture)) : statusStripPosture.Trim();
        CompactSpacingScale = string.IsNullOrWhiteSpace(compactSpacingScale) ? throw new ArgumentException("Compact spacing scale is required.", nameof(compactSpacingScale)) : compactSpacingScale.Trim();
        CompactHeaderScale = string.IsNullOrWhiteSpace(compactHeaderScale) ? throw new ArgumentException("Compact header scale is required.", nameof(compactHeaderScale)) : compactHeaderScale.Trim();
        RowSpacingMax = string.IsNullOrWhiteSpace(rowSpacingMax) ? throw new ArgumentException("Row spacing maximum is required.", nameof(rowSpacingMax)) : rowSpacingMax.Trim();
        CardPaddingMax = string.IsNullOrWhiteSpace(cardPaddingMax) ? throw new ArgumentException("Card padding maximum is required.", nameof(cardPaddingMax)) : cardPaddingMax.Trim();
        InputPaddingHorizontalMax = string.IsNullOrWhiteSpace(inputPaddingHorizontalMax) ? throw new ArgumentException("Input padding horizontal maximum is required.", nameof(inputPaddingHorizontalMax)) : inputPaddingHorizontalMax.Trim();
        InputPaddingVerticalMax = string.IsNullOrWhiteSpace(inputPaddingVerticalMax) ? throw new ArgumentException("Input padding vertical maximum is required.", nameof(inputPaddingVerticalMax)) : inputPaddingVerticalMax.Trim();
        BannerHeightCeiling = string.IsNullOrWhiteSpace(bannerHeightCeiling) ? throw new ArgumentException("Banner height ceiling is required.", nameof(bannerHeightCeiling)) : bannerHeightCeiling.Trim();
        BadgeDensityCeiling = string.IsNullOrWhiteSpace(badgeDensityCeiling) ? throw new ArgumentException("Badge density ceiling is required.", nameof(badgeDensityCeiling)) : badgeDensityCeiling.Trim();
        PersistentBannerCountMax = string.IsNullOrWhiteSpace(persistentBannerCountMax) ? throw new ArgumentException("Persistent banner count maximum is required.", nameof(persistentBannerCountMax)) : persistentBannerCountMax.Trim();
        PersistentSecondaryBadgeClusterMax = string.IsNullOrWhiteSpace(persistentSecondaryBadgeClusterMax) ? throw new ArgumentException("Persistent secondary badge-cluster maximum is required.", nameof(persistentSecondaryBadgeClusterMax)) : persistentSecondaryBadgeClusterMax.Trim();
        CompactFieldHeight = string.IsNullOrWhiteSpace(compactFieldHeight) ? throw new ArgumentException("Compact field height is required.", nameof(compactFieldHeight)) : compactFieldHeight.Trim();
        CompactButtonHeight = string.IsNullOrWhiteSpace(compactButtonHeight) ? throw new ArgumentException("Compact button height is required.", nameof(compactButtonHeight)) : compactButtonHeight.Trim();
        CompactButtonMinHeightMax = string.IsNullOrWhiteSpace(compactButtonMinHeightMax) ? throw new ArgumentException("Compact button minimum-height maximum is required.", nameof(compactButtonMinHeightMax)) : compactButtonMinHeightMax.Trim();
        CompactIconButtonSizeMax = string.IsNullOrWhiteSpace(compactIconButtonSizeMax) ? throw new ArgumentException("Compact icon-button size maximum is required.", nameof(compactIconButtonSizeMax)) : compactIconButtonSizeMax.Trim();
        HeroBannerHeightMax = string.IsNullOrWhiteSpace(heroBannerHeightMax) ? throw new ArgumentException("Hero banner height maximum is required.", nameof(heroBannerHeightMax)) : heroBannerHeightMax.Trim();
        CardNestingDepthMax = string.IsNullOrWhiteSpace(cardNestingDepthMax) ? throw new ArgumentException("Card nesting depth maximum is required.", nameof(cardNestingDepthMax)) : cardNestingDepthMax.Trim();
        DashboardTileCountInToolstripMax = string.IsNullOrWhiteSpace(dashboardTileCountInToolstripMax) ? throw new ArgumentException("Dashboard tile count maximum is required.", nameof(dashboardTileCountInToolstripMax)) : dashboardTileCountInToolstripMax.Trim();
        DecorativeLandingChromeInWorkbenchMax = string.IsNullOrWhiteSpace(decorativeLandingChromeInWorkbenchMax) ? throw new ArgumentException("Decorative landing chrome maximum is required.", nameof(decorativeLandingChromeInWorkbenchMax)) : decorativeLandingChromeInWorkbenchMax.Trim();
        MenuHeightMax = string.IsNullOrWhiteSpace(menuHeightMax) ? throw new ArgumentException("Menu height maximum is required.", nameof(menuHeightMax)) : menuHeightMax.Trim();
        ToolstripHeightMax = string.IsNullOrWhiteSpace(toolstripHeightMax) ? throw new ArgumentException("Toolstrip height maximum is required.", nameof(toolstripHeightMax)) : toolstripHeightMax.Trim();
        WorkspaceContextStripRequired = workspaceContextStripRequired;
        TabStripHeightMax = string.IsNullOrWhiteSpace(tabStripHeightMax) ? throw new ArgumentException("Tab-strip height maximum is required.", nameof(tabStripHeightMax)) : tabStripHeightMax.Trim();
        LeftNavigationWidthMin = string.IsNullOrWhiteSpace(leftNavigationWidthMin) ? throw new ArgumentException("Left-navigation width minimum is required.", nameof(leftNavigationWidthMin)) : leftNavigationWidthMin.Trim();
        LeftNavigationWidthMax = string.IsNullOrWhiteSpace(leftNavigationWidthMax) ? throw new ArgumentException("Left-navigation width maximum is required.", nameof(leftNavigationWidthMax)) : leftNavigationWidthMax.Trim();
        RightInspectorWidthMin = string.IsNullOrWhiteSpace(rightInspectorWidthMin) ? throw new ArgumentException("Right-inspector width minimum is required.", nameof(rightInspectorWidthMin)) : rightInspectorWidthMin.Trim();
        RightInspectorWidthMax = string.IsNullOrWhiteSpace(rightInspectorWidthMax) ? throw new ArgumentException("Right-inspector width maximum is required.", nameof(rightInspectorWidthMax)) : rightInspectorWidthMax.Trim();
        MenuAndToolstripCombinedHeightMax = string.IsNullOrWhiteSpace(menuAndToolstripCombinedHeightMax) ? throw new ArgumentException("Menu and toolstrip combined height maximum is required.", nameof(menuAndToolstripCombinedHeightMax)) : menuAndToolstripCombinedHeightMax.Trim();
        StatusStripHeightMax = string.IsNullOrWhiteSpace(statusStripHeightMax) ? throw new ArgumentException("Status strip height maximum is required.", nameof(statusStripHeightMax)) : statusStripHeightMax.Trim();
        CenterPaneMustDominate = centerPaneMustDominate;
        SectionRhythmMustRemainVisible = sectionRhythmMustRemainVisible;
        HeaderToContentRatioMax = string.IsNullOrWhiteSpace(headerToContentRatioMax) ? throw new ArgumentException("Header-to-content ratio maximum is required.", nameof(headerToContentRatioMax)) : headerToContentRatioMax.Trim();
        DenseListRowHeightMax = string.IsNullOrWhiteSpace(denseListRowHeightMax) ? throw new ArgumentException("Dense-list row-height maximum is required.", nameof(denseListRowHeightMax)) : denseListRowHeightMax.Trim();
        DenseListVisibleRowMin = string.IsNullOrWhiteSpace(denseListVisibleRowMin) ? throw new ArgumentException("Dense list visible row minimum is required.", nameof(denseListVisibleRowMin)) : denseListVisibleRowMin.Trim();
        DenseDetailGroupVisibleFieldMin = string.IsNullOrWhiteSpace(denseDetailGroupVisibleFieldMin) ? throw new ArgumentException("Dense detail-group visible field minimum is required.", nameof(denseDetailGroupVisibleFieldMin)) : denseDetailGroupVisibleFieldMin.Trim();
        BuilderRouteVisibleRowsAt1440x900Min = string.IsNullOrWhiteSpace(builderRouteVisibleRowsAt1440x900Min) ? throw new ArgumentException("Builder-route visible row minimum for 1440x900 is required.", nameof(builderRouteVisibleRowsAt1440x900Min)) : builderRouteVisibleRowsAt1440x900Min.Trim();
        BuilderRouteVisibleRowsAt1366x768Min = string.IsNullOrWhiteSpace(builderRouteVisibleRowsAt1366x768Min) ? throw new ArgumentException("Builder-route visible row minimum for 1366x768 is required.", nameof(builderRouteVisibleRowsAt1366x768Min)) : builderRouteVisibleRowsAt1366x768Min.Trim();
        ProofFamilyIds = PrimitiveGuards.NormalizeExactContractIdList(
            proofFamilyIds,
            nameof(proofFamilyIds),
            defaultValues: RequiredProofFamilyIds);
        ChromeRegressionSentinels = PrimitiveGuards.NormalizeExactContractIdList(
            chromeRegressionSentinels,
            nameof(chromeRegressionSentinels),
            defaultValues: BuildExpectedChromeRegressionSentinels(
                HeroBannerHeightMax,
                DashboardTileCountInToolstripMax,
                DecorativeLandingChromeInWorkbenchMax,
                MenuHeightMax,
                ToolstripHeightMax,
                StatusStripHeightMax,
                PersistentBannerCountMax,
                PersistentSecondaryBadgeClusterMax,
                CardNestingDepthMax,
                CenterPaneMustDominate));
        FlagshipDefaultForAvalonia = flagshipDefaultForAvalonia;
    }

    public string PresetId { get; }
    public string DenseWorkbenchBudgetVersion { get; }
    public bool TopMenuBarEnabled { get; }
    public bool ToolstripEnabled { get; }
    public string TabStripDensity { get; }
    public bool CompactListDetailPanes { get; }
    public bool CompactInspectorForms { get; }
    public string StatusStripPosture { get; }
    public string CompactSpacingScale { get; }
    public string CompactHeaderScale { get; }
    public string RowSpacingMax { get; }
    public string CardPaddingMax { get; }
    public string InputPaddingHorizontalMax { get; }
    public string InputPaddingVerticalMax { get; }
    public string BannerHeightCeiling { get; }
    public string BadgeDensityCeiling { get; }
    public string PersistentBannerCountMax { get; }
    public string PersistentSecondaryBadgeClusterMax { get; }
    public string CompactFieldHeight { get; }
    public string CompactButtonHeight { get; }
    public string CompactButtonMinHeightMax { get; }
    public string CompactIconButtonSizeMax { get; }
    public string HeroBannerHeightMax { get; }
    public string CardNestingDepthMax { get; }
    public string DashboardTileCountInToolstripMax { get; }
    public string DecorativeLandingChromeInWorkbenchMax { get; }
    public string MenuHeightMax { get; }
    public string ToolstripHeightMax { get; }
    public bool WorkspaceContextStripRequired { get; }
    public string TabStripHeightMax { get; }
    public string LeftNavigationWidthMin { get; }
    public string LeftNavigationWidthMax { get; }
    public string RightInspectorWidthMin { get; }
    public string RightInspectorWidthMax { get; }
    public string MenuAndToolstripCombinedHeightMax { get; }
    public string StatusStripHeightMax { get; }
    public bool CenterPaneMustDominate { get; }
    public bool SectionRhythmMustRemainVisible { get; }
    public string HeaderToContentRatioMax { get; }
    public string DenseListRowHeightMax { get; }
    public string DenseListVisibleRowMin { get; }
    public string DenseDetailGroupVisibleFieldMin { get; }
    public string BuilderRouteVisibleRowsAt1440x900Min { get; }
    public string BuilderRouteVisibleRowsAt1366x768Min { get; }
    public IReadOnlyList<string> ProofFamilyIds { get; }
    public IReadOnlyList<string> ChromeRegressionSentinels { get; }
    public bool FlagshipDefaultForAvalonia { get; }

    private ClassicDenseWorkbenchPreset(TokenCanon tokenCanon)
        : this(
            presetId: ReadRequiredToken(tokenCanon, "classic.dense.workbench.preset.id"),
            denseWorkbenchBudgetVersion: ReadRequiredToken(tokenCanon, "classic.dense.workbench.budget.version"),
            topMenuBarEnabled: ReadRequiredBooleanToken(tokenCanon, "workbench.layout.top.menu.enabled"),
            toolstripEnabled: ReadRequiredBooleanToken(tokenCanon, "workbench.layout.toolstrip.enabled"),
            tabStripDensity: ReadRequiredToken(tokenCanon, "workbench.layout.tab.strip.density"),
            compactListDetailPanes: ReadRequiredBooleanToken(tokenCanon, "workbench.layout.list.detail.compact"),
            compactInspectorForms: ReadRequiredBooleanToken(tokenCanon, "workbench.layout.inspector.forms.compact"),
            statusStripPosture: ReadRequiredToken(tokenCanon, "workbench.layout.status.strip.posture"),
            compactSpacingScale: ReadRequiredToken(tokenCanon, "noise.budget.compact.spacing.scale"),
            compactHeaderScale: ReadRequiredToken(tokenCanon, "noise.budget.compact.header.scale"),
            rowSpacingMax: ReadRequiredToken(tokenCanon, "noise.budget.row.spacing.max"),
            cardPaddingMax: ReadRequiredToken(tokenCanon, "noise.budget.card.padding.max"),
            inputPaddingHorizontalMax: ReadRequiredToken(tokenCanon, "noise.budget.input.padding.horizontal.max"),
            inputPaddingVerticalMax: ReadRequiredToken(tokenCanon, "noise.budget.input.padding.vertical.max"),
            bannerHeightCeiling: ReadRequiredToken(tokenCanon, "noise.budget.banner.height.max"),
            badgeDensityCeiling: ReadRequiredToken(tokenCanon, "noise.budget.badge.density.max"),
            persistentBannerCountMax: ReadRequiredToken(tokenCanon, "noise.budget.persistent.banner.count.max"),
            persistentSecondaryBadgeClusterMax: ReadRequiredToken(tokenCanon, "noise.budget.badge.cluster.secondary.max"),
            compactFieldHeight: ReadRequiredToken(tokenCanon, "noise.budget.field.height.compact"),
            compactButtonHeight: ReadRequiredToken(tokenCanon, "noise.budget.button.height.compact"),
            compactButtonMinHeightMax: ReadRequiredToken(tokenCanon, "noise.budget.button.min.height.max"),
            compactIconButtonSizeMax: ReadRequiredToken(tokenCanon, "noise.budget.icon.button.size.compact.max"),
            heroBannerHeightMax: ReadRequiredToken(tokenCanon, "noise.budget.hero.banner.height.max"),
            cardNestingDepthMax: ReadRequiredToken(tokenCanon, "noise.budget.card.nesting.depth.max"),
            dashboardTileCountInToolstripMax: ReadRequiredToken(tokenCanon, "noise.budget.toolstrip.dashboard.tile.max"),
            decorativeLandingChromeInWorkbenchMax: ReadRequiredToken(tokenCanon, "noise.budget.decorative.landing.chrome.max"),
            menuHeightMax: ReadRequiredToken(tokenCanon, "workbench.layout.menu.height.max"),
            toolstripHeightMax: ReadRequiredToken(tokenCanon, "workbench.layout.toolstrip.height.max"),
            workspaceContextStripRequired: ReadRequiredBooleanToken(tokenCanon, "workbench.layout.workspace.context.strip.required"),
            tabStripHeightMax: ReadRequiredToken(tokenCanon, "workbench.layout.tab.strip.height.max"),
            leftNavigationWidthMin: ReadRequiredToken(tokenCanon, "workbench.layout.left.navigation.width.min"),
            leftNavigationWidthMax: ReadRequiredToken(tokenCanon, "workbench.layout.left.navigation.width.max"),
            rightInspectorWidthMin: ReadRequiredToken(tokenCanon, "workbench.layout.right.inspector.width.min"),
            rightInspectorWidthMax: ReadRequiredToken(tokenCanon, "workbench.layout.right.inspector.width.max"),
            menuAndToolstripCombinedHeightMax: ReadRequiredToken(tokenCanon, "workbench.layout.menu.toolstrip.height.max"),
            statusStripHeightMax: ReadRequiredToken(tokenCanon, "workbench.layout.status.strip.height.max"),
            centerPaneMustDominate: ReadRequiredBooleanToken(tokenCanon, "workbench.layout.center.pane.must.dominate"),
            sectionRhythmMustRemainVisible: ReadRequiredBooleanToken(tokenCanon, "workbench.layout.section.rhythm.must.remain.visible"),
            headerToContentRatioMax: ReadRequiredToken(tokenCanon, "workbench.layout.header.to.content.ratio.max"),
            denseListRowHeightMax: ReadRequiredToken(tokenCanon, "workbench.visible.list.row.height.max"),
            denseListVisibleRowMin: ReadRequiredToken(tokenCanon, "workbench.visible.dense.list.row.min"),
            denseDetailGroupVisibleFieldMin: ReadRequiredToken(tokenCanon, "workbench.visible.dense.detail.group.field.min"),
            builderRouteVisibleRowsAt1440x900Min: ReadRequiredToken(tokenCanon, "workbench.visible.builder.rows.1440x900.min"),
            builderRouteVisibleRowsAt1366x768Min: ReadRequiredToken(tokenCanon, "workbench.visible.builder.rows.1366x768.min"),
            proofFamilyIds: ReadRequiredTokenList(tokenCanon, "classic.dense.workbench.proof.family.ids"),
            chromeRegressionSentinels: ReadRequiredTokenList(tokenCanon, "classic.dense.workbench.chrome.regression.sentinels"),
            flagshipDefaultForAvalonia: ReadRequiredBooleanToken(tokenCanon, "classic.dense.workbench.flagship.avalonia.default"))
    {
    }

    private static IReadOnlyList<string> BuildExpectedChromeRegressionSentinels(
        string heroBannerHeightMax,
        string dashboardTileCountInToolstripMax,
        string decorativeLandingChromeInWorkbenchMax,
        string menuHeightMax,
        string toolstripHeightMax,
        string statusStripHeightMax,
        string persistentBannerCountMax,
        string persistentSecondaryBadgeClusterMax,
        string cardNestingDepthMax,
        bool centerPaneMustDominate) =>
        new[]
        {
            $"hero_banner_height_max={heroBannerHeightMax}",
            $"dashboard_tile_count_in_toolstrip_max={dashboardTileCountInToolstripMax}",
            $"decorative_landing_chrome_in_workbench_max={decorativeLandingChromeInWorkbenchMax}",
            $"menu_height_max={menuHeightMax}",
            $"toolstrip_height_max={toolstripHeightMax}",
            $"status_strip_height_max={statusStripHeightMax}",
            $"persistent_banner_count_max={persistentBannerCountMax}",
            $"persistent_secondary_badge_cluster_max={persistentSecondaryBadgeClusterMax}",
            $"card_nesting_depth_max={cardNestingDepthMax}",
            $"center_pane_must_dominate={centerPaneMustDominate.ToString().ToLowerInvariant()}",
        };

    private static string ReadRequiredToken(TokenCanon tokenCanon, string key)
    {
        ArgumentNullException.ThrowIfNull(tokenCanon);

        return tokenCanon[key];
    }

    private static bool ReadRequiredBooleanToken(TokenCanon tokenCanon, string key)
    {
        var value = ReadRequiredToken(tokenCanon, key);
        if (bool.TryParse(value, out var parsed))
        {
            return parsed;
        }

        throw new ArgumentException($"Token '{key}' must contain a boolean value.", nameof(tokenCanon));
    }

    private static IReadOnlyList<string> ReadRequiredTokenList(TokenCanon tokenCanon, string key)
    {
        var value = ReadRequiredToken(tokenCanon, key);
        return value
            .Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
    }
}

public enum DenseSortDirection
{
    None,
    Asc,
    Desc
}

public enum DenseRowEmphasis
{
    Normal,
    Muted,
    Highlighted,
    Critical
}

public enum ExplainChipTone
{
    Neutral,
    Info,
    Success,
    Warning,
    Error
}

public sealed record DenseTableHeader
{
    public DenseTableHeader(string key, string label, bool sortable = false, DenseSortDirection sortDirection = DenseSortDirection.None)
    {
        Key = string.IsNullOrWhiteSpace(key) ? throw new ArgumentException("Key is required.", nameof(key)) : key.Trim();
        Label = string.IsNullOrWhiteSpace(label) ? throw new ArgumentException("Label is required.", nameof(label)) : label.Trim();
        Sortable = sortable;
        SortDirection = sortDirection;
    }

    public string Key { get; }
    public string Label { get; }
    public bool Sortable { get; }
    public DenseSortDirection SortDirection { get; }
}

public sealed record DenseRowMetadata
{
    public DenseRowMetadata(string rowId, DenseRowEmphasis emphasis = DenseRowEmphasis.Normal, bool selected = false, bool explainAffinity = false)
    {
        RowId = string.IsNullOrWhiteSpace(rowId) ? throw new ArgumentException("Row id is required.", nameof(rowId)) : rowId.Trim();
        Emphasis = emphasis;
        Selected = selected;
        ExplainAffinity = explainAffinity;
    }

    public string RowId { get; }
    public DenseRowEmphasis Emphasis { get; }
    public bool Selected { get; }
    public bool ExplainAffinity { get; }
}

internal static class PrimitiveGuards
{
    internal static string NormalizeLocaleSafeLabel(string value, string argumentName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Label is required.", argumentName);
        }

        var normalized = value.Trim();
        if (normalized.Any(char.IsControl))
        {
            throw new ArgumentException("Label cannot include control characters.", argumentName);
        }

        return normalized;
    }

    internal static string NormalizeContractId(string value, string argumentName)
    {
        var normalized = NormalizeLocaleSafeLabel(value, argumentName);
        if (normalized.Any(char.IsWhiteSpace))
        {
            throw new ArgumentException("Identifier cannot include whitespace.", argumentName);
        }

        return normalized;
    }

    internal static int NormalizeCount(int value, string argumentName)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(argumentName, "Count values cannot be negative.");
        }

        return value;
    }

    internal static int NormalizePositiveCount(int value, string argumentName)
    {
        if (value <= 0)
        {
            throw new ArgumentOutOfRangeException(argumentName, "Count values must be greater than zero.");
        }

        return value;
    }

    internal static IReadOnlyList<string> NormalizeContractIdList(
        IReadOnlyList<string>? values,
        string argumentName,
        IReadOnlyList<string>? defaultValues = null)
    {
        var effective = values ?? defaultValues ?? Array.Empty<string>();
        if (effective.Count == 0)
        {
            throw new ArgumentException("Identifier list cannot be empty.", argumentName);
        }

        var normalized = new List<string>(effective.Count);
        foreach (var value in effective)
        {
            normalized.Add(NormalizeContractId(value, argumentName));
        }

        return normalized.AsReadOnly();
    }

    internal static IReadOnlyList<string> NormalizeRequiredContractIdList(
        IReadOnlyList<string>? values,
        string argumentName,
        IReadOnlyList<string> defaultValues)
    {
        var normalized = NormalizeContractIdList(values, argumentName, defaultValues);
        var missing = defaultValues
            .Where(required => !normalized.Contains(required, StringComparer.Ordinal))
            .ToArray();
        if (missing.Length > 0)
        {
            throw new ArgumentException(
                $"Identifier list must include required contract ids: {string.Join(", ", missing)}.",
                argumentName);
        }

        return normalized;
    }

    internal static IReadOnlyList<string> NormalizeExactContractIdList(
        IReadOnlyList<string>? values,
        string argumentName,
        IReadOnlyList<string> defaultValues)
    {
        var normalized = NormalizeRequiredContractIdList(values, argumentName, defaultValues);
        var extras = normalized
            .Where(value => !defaultValues.Contains(value, StringComparer.Ordinal))
            .ToArray();
        if (extras.Length > 0)
        {
            throw new ArgumentException(
                $"Identifier list cannot include non-canonical contract ids: {string.Join(", ", extras)}.",
                argumentName);
        }

        if (normalized.Count != defaultValues.Count)
        {
            throw new ArgumentException(
                $"Identifier list must contain exactly {defaultValues.Count} canonical contract ids.",
                argumentName);
        }

        for (var i = 0; i < defaultValues.Count; i++)
        {
            if (!string.Equals(normalized[i], defaultValues[i], StringComparison.Ordinal))
            {
                throw new ArgumentException("Identifier list must preserve canonical contract-id ordering.", argumentName);
            }
        }

        return normalized;
    }
}

public sealed record ExplainChip
{
    public ExplainChip(string label, ExplainChipTone tone = ExplainChipTone.Neutral, bool active = false, string? hint = null)
    {
        Label = string.IsNullOrWhiteSpace(label) ? throw new ArgumentException("Label is required.", nameof(label)) : label.Trim();
        Tone = tone;
        Active = active;
        Hint = string.IsNullOrWhiteSpace(hint) ? null : hint.Trim();
    }

    public string Label { get; }
    public ExplainChipTone Tone { get; }
    public bool Active { get; }
    public string? Hint { get; }
}

public sealed record SpiderStatusCard
{
    public SpiderStatusCard(string title, string status, string summary, bool stale = false)
    {
        Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("Title is required.", nameof(title)) : title.Trim();
        Status = string.IsNullOrWhiteSpace(status) ? throw new ArgumentException("Status is required.", nameof(status)) : status.Trim();
        Summary = string.IsNullOrWhiteSpace(summary) ? throw new ArgumentException("Summary is required.", nameof(summary)) : summary.Trim();
        Stale = stale;
    }

    public string Title { get; }
    public string Status { get; }
    public string Summary { get; }
    public bool Stale { get; }
}

public sealed record ArtifactStatusCard
{
    public ArtifactStatusCard(string title, string artifactType, string status, bool available = true)
    {
        Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("Title is required.", nameof(title)) : title.Trim();
        ArtifactType = string.IsNullOrWhiteSpace(artifactType) ? throw new ArgumentException("Artifact type is required.", nameof(artifactType)) : artifactType.Trim();
        Status = string.IsNullOrWhiteSpace(status) ? throw new ArgumentException("Status is required.", nameof(status)) : status.Trim();
        Available = available;
    }

    public string Title { get; }
    public string ArtifactType { get; }
    public string Status { get; }
    public bool Available { get; }
}

public sealed class UiAdapterPayload
{
    public UiAdapterPayload(string rootClass, IReadOnlyDictionary<string, string> attributes)
    {
        RootClass = rootClass;
        Attributes = attributes ?? throw new ArgumentNullException(nameof(attributes));
    }

    public string RootClass { get; }
    public IReadOnlyDictionary<string, string> Attributes { get; }

    public static UiAdapterPayload Banner(string tone, string title, IReadOnlyDictionary<string, string>? additional = null)
    {
        var dict = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["role"] = "status",
            ["data-tone"] = tone,
            ["data-title"] = title
        };

        if (additional is not null)
        {
            foreach (var pair in additional)
            {
                dict[pair.Key] = pair.Value;
            }
        }

        return new UiAdapterPayload($"chummer-banner chummer-banner-{tone}", new ReadOnlyDictionary<string, string>(dict));
    }
}
