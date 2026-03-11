namespace Chummer.Ui.Kit.Preview;

public sealed class PreviewGalleryOwnership
{
    public PreviewGalleryOwnership(string owner, string route, string notes)
    {
        if (string.IsNullOrWhiteSpace(owner))
        {
            throw new ArgumentException("Owner cannot be null or whitespace.", nameof(owner));
        }

        if (string.IsNullOrWhiteSpace(route))
        {
            throw new ArgumentException("Route cannot be null or whitespace.", nameof(route));
        }

        Owner = owner.Trim();
        Route = route.Trim();
        Notes = string.IsNullOrWhiteSpace(notes) ? string.Empty : notes.Trim();
    }

    public string Owner { get; }

    public string Route { get; }

    public string Notes { get; }

    public static PreviewGalleryOwnership CreateDefault() =>
        new("Chummer.Ui.Kit", "preview/gallery", "Owned by the UI kit package and intentionally free of domain DTOs or HTTP clients.");
}
