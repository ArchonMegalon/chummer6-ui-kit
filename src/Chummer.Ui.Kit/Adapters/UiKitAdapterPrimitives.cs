using System.Collections.ObjectModel;

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

public enum DenseSortDirection
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

public enum ExplainChipTone
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

public sealed class DenseColumnHeader
{
    public DenseColumnHeader(string key, string label, DenseSortDirection sortDirection = DenseSortDirection.None, bool sortable = false, bool numeric = false)
    {
        Key = string.IsNullOrWhiteSpace(key) ? throw new ArgumentException("Key is required.", nameof(key)) : key.Trim();
        Label = string.IsNullOrWhiteSpace(label) ? throw new ArgumentException("Label is required.", nameof(label)) : label.Trim();
        SortDirection = sortDirection;
        Sortable = sortable;
        Numeric = numeric;
    }

    public string Key { get; }
    public string Label { get; }
    public DenseSortDirection SortDirection { get; }
    public bool Sortable { get; }
    public bool Numeric { get; }
}

public sealed class DenseRowMetadata
{
    public DenseRowMetadata(string rowKey, string primaryText, string? secondaryText = null, RowEmphasis emphasis = RowEmphasis.Default, ExplainAffinity explainAffinity = ExplainAffinity.None, bool selected = false, bool disabled = false)
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

public sealed class DenseTableSummary
{
    public DenseTableSummary(string label, int rowCount, int visibleColumnCount, bool compact = true, bool zebraStripes = true)
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

public sealed class ExplainChip
{
    public ExplainChip(string label, string evidenceCountLabel, ExplainChipTone tone = ExplainChipTone.Neutral, bool interactive = false)
    {
        Label = string.IsNullOrWhiteSpace(label) ? throw new ArgumentException("Label is required.", nameof(label)) : label.Trim();
        EvidenceCountLabel = string.IsNullOrWhiteSpace(evidenceCountLabel) ? throw new ArgumentException("Evidence count label is required.", nameof(evidenceCountLabel)) : evidenceCountLabel.Trim();
        Tone = tone;
        Interactive = interactive;
    }

    public string Label { get; }
    public string EvidenceCountLabel { get; }
    public ExplainChipTone Tone { get; }
    public bool Interactive { get; }
}

public sealed class SpiderStatusCard
{
    public SpiderStatusCard(string title, string summary, string postureLabel, CardTone tone = CardTone.Neutral, bool requiresAttention = false)
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

public sealed class ArtifactStatusCard
{
    public ArtifactStatusCard(string title, string statusLabel, string detail, CardTone tone = CardTone.Neutral, bool previewReady = false)
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
