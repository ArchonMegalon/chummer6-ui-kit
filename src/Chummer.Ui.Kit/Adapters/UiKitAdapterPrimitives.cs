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
