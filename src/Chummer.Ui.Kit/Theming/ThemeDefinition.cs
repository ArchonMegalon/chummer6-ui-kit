using Chummer.Ui.Kit.Tokens;

namespace Chummer.Ui.Kit.Theming;

public sealed class ThemeDefinition
{
    public ThemeDefinition(string name, TokenCanon canon, IReadOnlyDictionary<string, string>? overrides = null)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Theme name cannot be null or whitespace.", nameof(name));
        }

        Name = name.Trim();
        Canon = canon ?? throw new ArgumentNullException(nameof(canon));
        Overrides = overrides ?? new Dictionary<string, string>(StringComparer.Ordinal);
    }

    public string Name { get; }

    public TokenCanon Canon { get; }

    public IReadOnlyDictionary<string, string> Overrides { get; }
}
