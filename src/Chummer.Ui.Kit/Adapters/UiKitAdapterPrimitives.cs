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

public enum ClassicDenseSortDirection
{
    None,
    Ascending,
    Descending
}

public enum RowEmphasis
{
    Default,
    Accent,
    Warning,
    Danger,
    Success
}

public enum ExplainAffinity
{
    None,
    Low,
    Medium,
    High
}

public enum ClassicExplainChipTone
{
    Neutral,
    Informative,
    Warning,
    Critical
}

public enum CardTone
{
    Neutral,
    Informative,
    Warning,
    Critical,
    Success
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

public sealed class ClassicDenseColumnHeader
{
    public ClassicDenseColumnHeader(string key, string label, ClassicDenseSortDirection sortDirection = ClassicDenseSortDirection.None, bool sortable = false, bool numeric = false)
    {
        Key = string.IsNullOrWhiteSpace(key) ? throw new ArgumentException("Key is required.", nameof(key)) : key.Trim();
        Label = string.IsNullOrWhiteSpace(label) ? throw new ArgumentException("Label is required.", nameof(label)) : label.Trim();
        SortDirection = sortDirection;
        Sortable = sortable;
        Numeric = numeric;
    }

    public string Key { get; }
    public string Label { get; }
    public ClassicDenseSortDirection SortDirection { get; }
    public bool Sortable { get; }
    public bool Numeric { get; }
}

public sealed class ClassicDenseRowMetadata
{
    public ClassicDenseRowMetadata(string rowKey, string primaryText, string? secondaryText = null, RowEmphasis emphasis = RowEmphasis.Default, ExplainAffinity explainAffinity = ExplainAffinity.None, bool selected = false, bool disabled = false)
    {
        RowKey = string.IsNullOrWhiteSpace(rowKey) ? throw new ArgumentException("Row key is required.", nameof(rowKey)) : rowKey.Trim();
        PrimaryText = string.IsNullOrWhiteSpace(primaryText) ? throw new ArgumentException("Primary text is required.", nameof(primaryText)) : primaryText.Trim();
        SecondaryText = string.IsNullOrWhiteSpace(secondaryText) ? null : secondaryText.Trim();
        Emphasis = emphasis;
        ExplainAffinity = explainAffinity;
        Selected = selected;
        Disabled = disabled;
    }

    public string RowKey { get; }
    public string PrimaryText { get; }
    public string? SecondaryText { get; }
    public RowEmphasis Emphasis { get; }
    public ExplainAffinity ExplainAffinity { get; }
    public bool Selected { get; }
    public bool Disabled { get; }
}

public sealed class ClassicDenseTableSummary
{
    public ClassicDenseTableSummary(string label, int rowCount, int visibleColumnCount, bool compact = true, bool zebraStripes = true)
    {
        Label = string.IsNullOrWhiteSpace(label) ? throw new ArgumentException("Label is required.", nameof(label)) : label.Trim();
        RowCount = rowCount < 0 ? throw new ArgumentOutOfRangeException(nameof(rowCount)) : rowCount;
        VisibleColumnCount = visibleColumnCount < 0 ? throw new ArgumentOutOfRangeException(nameof(visibleColumnCount)) : visibleColumnCount;
        Compact = compact;
        ZebraStripes = zebraStripes;
    }

    public string Label { get; }
    public int RowCount { get; }
    public int VisibleColumnCount { get; }
    public bool Compact { get; }
    public bool ZebraStripes { get; }
}

public sealed class ClassicExplainChip
{
    public ClassicExplainChip(string label, string evidenceCountLabel, ClassicExplainChipTone tone = ClassicExplainChipTone.Neutral, bool interactive = false)
    {
        Label = string.IsNullOrWhiteSpace(label) ? throw new ArgumentException("Label is required.", nameof(label)) : label.Trim();
        EvidenceCountLabel = string.IsNullOrWhiteSpace(evidenceCountLabel) ? throw new ArgumentException("Evidence count label is required.", nameof(evidenceCountLabel)) : evidenceCountLabel.Trim();
        Tone = tone;
        Interactive = interactive;
    }

    public string Label { get; }
    public string EvidenceCountLabel { get; }
    public ClassicExplainChipTone Tone { get; }
    public bool Interactive { get; }
}

public sealed class ClassicSpiderStatusCard
{
    public ClassicSpiderStatusCard(string title, string summary, string postureLabel, CardTone tone = CardTone.Neutral, bool requiresAttention = false)
    {
        Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("Title is required.", nameof(title)) : title.Trim();
        Summary = string.IsNullOrWhiteSpace(summary) ? throw new ArgumentException("Summary is required.", nameof(summary)) : summary.Trim();
        PostureLabel = string.IsNullOrWhiteSpace(postureLabel) ? throw new ArgumentException("Posture label is required.", nameof(postureLabel)) : postureLabel.Trim();
        Tone = tone;
        RequiresAttention = requiresAttention;
    }

    public string Title { get; }
    public string Summary { get; }
    public string PostureLabel { get; }
    public CardTone Tone { get; }
    public bool RequiresAttention { get; }
}

public sealed class ClassicArtifactStatusCard
{
    public ClassicArtifactStatusCard(string title, string statusLabel, string detail, CardTone tone = CardTone.Neutral, bool previewReady = false)
    {
        Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("Title is required.", nameof(title)) : title.Trim();
        StatusLabel = string.IsNullOrWhiteSpace(statusLabel) ? throw new ArgumentException("Status label is required.", nameof(statusLabel)) : statusLabel.Trim();
        Detail = string.IsNullOrWhiteSpace(detail) ? throw new ArgumentException("Detail is required.", nameof(detail)) : detail.Trim();
        Tone = tone;
        PreviewReady = previewReady;
    }

    public string Title { get; }
    public string StatusLabel { get; }
    public string Detail { get; }
    public CardTone Tone { get; }
    public bool PreviewReady { get; }
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
        string? presetId = null,
        string? denseWorkbenchBudgetVersion = null,
        bool? topMenuBarEnabled = null,
        bool? toolstripEnabled = null,
        string? tabStripDensity = null,
        bool? compactListDetailPanes = null,
        bool? compactInspectorForms = null,
        string? statusStripPosture = null,
        string? compactSpacingScale = null,
        string? compactHeaderScale = null,
        string? rowSpacingMax = null,
        string? cardPaddingMax = null,
        string? inputPaddingHorizontalMax = null,
        string? inputPaddingVerticalMax = null,
        string? bannerHeightCeiling = null,
        string? badgeDensityCeiling = null,
        string? persistentBannerCountMax = null,
        string? persistentSecondaryBadgeClusterMax = null,
        string? compactFieldHeight = null,
        string? compactButtonHeight = null,
        string? compactButtonMinHeightMax = null,
        string? compactIconButtonSizeMax = null,
        string? heroBannerHeightMax = null,
        string? cardNestingDepthMax = null,
        string? dashboardTileCountInToolstripMax = null,
        string? decorativeLandingChromeInWorkbenchMax = null,
        string? menuHeightMax = null,
        string? toolstripHeightMax = null,
        bool? workspaceContextStripRequired = null,
        string? tabStripHeightMax = null,
        string? leftNavigationWidthMin = null,
        string? leftNavigationWidthMax = null,
        string? rightInspectorWidthMin = null,
        string? rightInspectorWidthMax = null,
        string? menuAndToolstripCombinedHeightMax = null,
        string? statusStripHeightMax = null,
        bool? centerPaneMustDominate = null,
        bool? sectionRhythmMustRemainVisible = null,
        string? headerToContentRatioMax = null,
        string? denseListRowHeightMax = null,
        string? denseListVisibleRowMin = null,
        string? denseDetailGroupVisibleFieldMin = null,
        string? builderRouteVisibleRowsAt1440x900Min = null,
        string? builderRouteVisibleRowsAt1366x768Min = null,
        IReadOnlyList<string>? proofFamilyIds = null,
        IReadOnlyList<string>? chromeRegressionSentinels = null,
        bool? flagshipDefaultForAvalonia = null)
    {
        var defaultCanon = TokenCanon.CreateDefault();

        PresetId = ResolveTokenOrDefault(defaultCanon, presetId, "classic.dense.workbench.preset.id", nameof(presetId), "Preset id is required.");
        DenseWorkbenchBudgetVersion = ResolveTokenOrDefault(defaultCanon, denseWorkbenchBudgetVersion, "classic.dense.workbench.budget.version", nameof(denseWorkbenchBudgetVersion), "Dense workbench budget version is required.");
        TopMenuBarEnabled = topMenuBarEnabled ?? ReadRequiredBooleanToken(defaultCanon, "workbench.layout.top.menu.enabled");
        ToolstripEnabled = toolstripEnabled ?? ReadRequiredBooleanToken(defaultCanon, "workbench.layout.toolstrip.enabled");
        TabStripDensity = ResolveTokenOrDefault(defaultCanon, tabStripDensity, "workbench.layout.tab.strip.density", nameof(tabStripDensity), "Tab strip density is required.");
        CompactListDetailPanes = compactListDetailPanes ?? ReadRequiredBooleanToken(defaultCanon, "workbench.layout.list.detail.compact");
        CompactInspectorForms = compactInspectorForms ?? ReadRequiredBooleanToken(defaultCanon, "workbench.layout.inspector.forms.compact");
        StatusStripPosture = ResolveTokenOrDefault(defaultCanon, statusStripPosture, "workbench.layout.status.strip.posture", nameof(statusStripPosture), "Status strip posture is required.");
        CompactSpacingScale = ResolveTokenOrDefault(defaultCanon, compactSpacingScale, "noise.budget.compact.spacing.scale", nameof(compactSpacingScale), "Compact spacing scale is required.");
        CompactHeaderScale = ResolveTokenOrDefault(defaultCanon, compactHeaderScale, "noise.budget.compact.header.scale", nameof(compactHeaderScale), "Compact header scale is required.");
        RowSpacingMax = ResolveTokenOrDefault(defaultCanon, rowSpacingMax, "noise.budget.row.spacing.max", nameof(rowSpacingMax), "Row spacing maximum is required.");
        CardPaddingMax = ResolveTokenOrDefault(defaultCanon, cardPaddingMax, "noise.budget.card.padding.max", nameof(cardPaddingMax), "Card padding maximum is required.");
        InputPaddingHorizontalMax = ResolveTokenOrDefault(defaultCanon, inputPaddingHorizontalMax, "noise.budget.input.padding.horizontal.max", nameof(inputPaddingHorizontalMax), "Input padding horizontal maximum is required.");
        InputPaddingVerticalMax = ResolveTokenOrDefault(defaultCanon, inputPaddingVerticalMax, "noise.budget.input.padding.vertical.max", nameof(inputPaddingVerticalMax), "Input padding vertical maximum is required.");
        BannerHeightCeiling = ResolveTokenOrDefault(defaultCanon, bannerHeightCeiling, "noise.budget.banner.height.max", nameof(bannerHeightCeiling), "Banner height ceiling is required.");
        BadgeDensityCeiling = ResolveTokenOrDefault(defaultCanon, badgeDensityCeiling, "noise.budget.badge.density.max", nameof(badgeDensityCeiling), "Badge density ceiling is required.");
        PersistentBannerCountMax = ResolveTokenOrDefault(defaultCanon, persistentBannerCountMax, "noise.budget.persistent.banner.count.max", nameof(persistentBannerCountMax), "Persistent banner count maximum is required.");
        PersistentSecondaryBadgeClusterMax = ResolveTokenOrDefault(defaultCanon, persistentSecondaryBadgeClusterMax, "noise.budget.badge.cluster.secondary.max", nameof(persistentSecondaryBadgeClusterMax), "Persistent secondary badge-cluster maximum is required.");
        CompactFieldHeight = ResolveTokenOrDefault(defaultCanon, compactFieldHeight, "noise.budget.field.height.compact", nameof(compactFieldHeight), "Compact field height is required.");
        CompactButtonHeight = ResolveTokenOrDefault(defaultCanon, compactButtonHeight, "noise.budget.button.height.compact", nameof(compactButtonHeight), "Compact button height is required.");
        CompactButtonMinHeightMax = ResolveTokenOrDefault(defaultCanon, compactButtonMinHeightMax, "noise.budget.button.min.height.max", nameof(compactButtonMinHeightMax), "Compact button minimum-height maximum is required.");
        CompactIconButtonSizeMax = ResolveTokenOrDefault(defaultCanon, compactIconButtonSizeMax, "noise.budget.icon.button.size.compact.max", nameof(compactIconButtonSizeMax), "Compact icon-button size maximum is required.");
        HeroBannerHeightMax = ResolveTokenOrDefault(defaultCanon, heroBannerHeightMax, "noise.budget.hero.banner.height.max", nameof(heroBannerHeightMax), "Hero banner height maximum is required.");
        CardNestingDepthMax = ResolveTokenOrDefault(defaultCanon, cardNestingDepthMax, "noise.budget.card.nesting.depth.max", nameof(cardNestingDepthMax), "Card nesting depth maximum is required.");
        DashboardTileCountInToolstripMax = ResolveTokenOrDefault(defaultCanon, dashboardTileCountInToolstripMax, "noise.budget.toolstrip.dashboard.tile.max", nameof(dashboardTileCountInToolstripMax), "Dashboard tile count maximum is required.");
        DecorativeLandingChromeInWorkbenchMax = ResolveTokenOrDefault(defaultCanon, decorativeLandingChromeInWorkbenchMax, "noise.budget.decorative.landing.chrome.max", nameof(decorativeLandingChromeInWorkbenchMax), "Decorative landing chrome maximum is required.");
        MenuHeightMax = ResolveTokenOrDefault(defaultCanon, menuHeightMax, "workbench.layout.menu.height.max", nameof(menuHeightMax), "Menu height maximum is required.");
        ToolstripHeightMax = ResolveTokenOrDefault(defaultCanon, toolstripHeightMax, "workbench.layout.toolstrip.height.max", nameof(toolstripHeightMax), "Toolstrip height maximum is required.");
        WorkspaceContextStripRequired = workspaceContextStripRequired ?? ReadRequiredBooleanToken(defaultCanon, "workbench.layout.workspace.context.strip.required");
        TabStripHeightMax = ResolveTokenOrDefault(defaultCanon, tabStripHeightMax, "workbench.layout.tab.strip.height.max", nameof(tabStripHeightMax), "Tab-strip height maximum is required.");
        LeftNavigationWidthMin = ResolveTokenOrDefault(defaultCanon, leftNavigationWidthMin, "workbench.layout.left.navigation.width.min", nameof(leftNavigationWidthMin), "Left-navigation width minimum is required.");
        LeftNavigationWidthMax = ResolveTokenOrDefault(defaultCanon, leftNavigationWidthMax, "workbench.layout.left.navigation.width.max", nameof(leftNavigationWidthMax), "Left-navigation width maximum is required.");
        RightInspectorWidthMin = ResolveTokenOrDefault(defaultCanon, rightInspectorWidthMin, "workbench.layout.right.inspector.width.min", nameof(rightInspectorWidthMin), "Right-inspector width minimum is required.");
        RightInspectorWidthMax = ResolveTokenOrDefault(defaultCanon, rightInspectorWidthMax, "workbench.layout.right.inspector.width.max", nameof(rightInspectorWidthMax), "Right-inspector width maximum is required.");
        MenuAndToolstripCombinedHeightMax = ResolveTokenOrDefault(defaultCanon, menuAndToolstripCombinedHeightMax, "workbench.layout.menu.toolstrip.height.max", nameof(menuAndToolstripCombinedHeightMax), "Menu and toolstrip combined height maximum is required.");
        StatusStripHeightMax = ResolveTokenOrDefault(defaultCanon, statusStripHeightMax, "workbench.layout.status.strip.height.max", nameof(statusStripHeightMax), "Status strip height maximum is required.");
        CenterPaneMustDominate = centerPaneMustDominate ?? ReadRequiredBooleanToken(defaultCanon, "workbench.layout.center.pane.must.dominate");
        SectionRhythmMustRemainVisible = sectionRhythmMustRemainVisible ?? ReadRequiredBooleanToken(defaultCanon, "workbench.layout.section.rhythm.must.remain.visible");
        HeaderToContentRatioMax = ResolveTokenOrDefault(defaultCanon, headerToContentRatioMax, "workbench.layout.header.to.content.ratio.max", nameof(headerToContentRatioMax), "Header-to-content ratio maximum is required.");
        DenseListRowHeightMax = ResolveTokenOrDefault(defaultCanon, denseListRowHeightMax, "workbench.visible.list.row.height.max", nameof(denseListRowHeightMax), "Dense-list row-height maximum is required.");
        DenseListVisibleRowMin = ResolveTokenOrDefault(defaultCanon, denseListVisibleRowMin, "workbench.visible.dense.list.row.min", nameof(denseListVisibleRowMin), "Dense list visible row minimum is required.");
        DenseDetailGroupVisibleFieldMin = ResolveTokenOrDefault(defaultCanon, denseDetailGroupVisibleFieldMin, "workbench.visible.dense.detail.group.field.min", nameof(denseDetailGroupVisibleFieldMin), "Dense detail-group visible field minimum is required.");
        BuilderRouteVisibleRowsAt1440x900Min = ResolveTokenOrDefault(defaultCanon, builderRouteVisibleRowsAt1440x900Min, "workbench.visible.builder.rows.1440x900.min", nameof(builderRouteVisibleRowsAt1440x900Min), "Builder-route visible row minimum for 1440x900 is required.");
        BuilderRouteVisibleRowsAt1366x768Min = ResolveTokenOrDefault(defaultCanon, builderRouteVisibleRowsAt1366x768Min, "workbench.visible.builder.rows.1366x768.min", nameof(builderRouteVisibleRowsAt1366x768Min), "Builder-route visible row minimum for 1366x768 is required.");
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
                MenuAndToolstripCombinedHeightMax,
                StatusStripHeightMax,
                PersistentBannerCountMax,
                PersistentSecondaryBadgeClusterMax,
                CardNestingDepthMax,
                CenterPaneMustDominate));
        FlagshipDefaultForAvalonia = flagshipDefaultForAvalonia ?? ReadRequiredBooleanToken(defaultCanon, "classic.dense.workbench.flagship.avalonia.default");
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
        string menuAndToolstripCombinedHeightMax,
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
            $"menu_and_toolstrip_combined_height_max={menuAndToolstripCombinedHeightMax}",
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

    private static string ResolveTokenOrDefault(
        TokenCanon tokenCanon,
        string? value,
        string tokenKey,
        string paramName,
        string missingValueMessage)
    {
        var resolvedValue = value ?? ReadRequiredToken(tokenCanon, tokenKey);
        return string.IsNullOrWhiteSpace(resolvedValue)
            ? throw new ArgumentException(missingValueMessage, paramName)
            : resolvedValue.Trim();
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
