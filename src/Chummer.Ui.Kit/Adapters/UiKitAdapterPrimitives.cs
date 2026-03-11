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
