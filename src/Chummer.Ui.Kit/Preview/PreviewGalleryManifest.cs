using System.Collections.ObjectModel;

namespace Chummer.Ui.Kit.Preview;

public sealed class PreviewGalleryManifest
{
    public PreviewGalleryManifest(
        PreviewGalleryOwnership ownership,
        IReadOnlyDictionary<string, string> previews)
    {
        Ownership = ownership ?? throw new ArgumentNullException(nameof(ownership));
        ArgumentNullException.ThrowIfNull(previews);

        if (previews.Count == 0)
        {
            throw new ArgumentException("At least one preview entry is required.", nameof(previews));
        }

        Previews = new ReadOnlyDictionary<string, string>(
            new Dictionary<string, string>(
                previews.ToDictionary(pair => pair.Key, pair => pair.Value, StringComparer.Ordinal),
                StringComparer.Ordinal));
    }

    public PreviewGalleryOwnership Ownership { get; }

    public IReadOnlyDictionary<string, string> Previews { get; }

    public static PreviewGalleryManifest CreateDefault()
    {
        return new PreviewGalleryManifest(
            PreviewGalleryOwnership.CreateDefault(),
            new Dictionary<string, string>(StringComparer.Ordinal)
            {
                ["token_canon"] = "Canonical token surface and raw values.",
                ["theme_compilation"] = "Compiled theme output and CSS variable inspection.",
                ["shell_chrome"] = "Shell chrome primitive and adapter mappings.",
                ["banner"] = "Banner primitive and adapter mappings.",
                ["stale_state_badge"] = "Stale-state badge primitive and adapter mappings.",
                ["approval_chip"] = "Approval chip primitive and adapter mappings.",
                ["offline_banner"] = "Offline banner primitive and adapter mappings.",
                ["accessibility_state"] = "Accessibility state primitive and adapter mappings."
            });
    }
}
