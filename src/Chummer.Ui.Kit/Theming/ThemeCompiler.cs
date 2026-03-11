using System.Collections.ObjectModel;
using System.Text;

namespace Chummer.Ui.Kit.Theming;

public sealed class ThemeCompiler
{
    public CompiledTheme Compile(ThemeDefinition definition)
    {
        ArgumentNullException.ThrowIfNull(definition);

        var resolved = new SortedDictionary<string, string>(
            definition.Canon.Tokens.ToDictionary(pair => pair.Key, pair => pair.Value, StringComparer.Ordinal),
            StringComparer.Ordinal);

        foreach (var pair in definition.Overrides)
        {
            if (!definition.Canon.Contains(pair.Key))
            {
                throw new InvalidOperationException($"Unknown token override '{pair.Key}'.");
            }

            resolved[pair.Key] = pair.Value.Trim();
        }

        var css = new StringBuilder();
        css.Append(":root[data-theme=\"");
        css.Append(definition.Name);
        css.AppendLine("\"] {");

        foreach (var pair in resolved)
        {
            css.Append("  --");
            css.Append(pair.Key.Replace('.', '-'));
            css.Append(": ");
            css.Append(pair.Value);
            css.AppendLine(";");
        }

        css.Append('}');

        return new CompiledTheme(
            definition.Name,
            new ReadOnlyDictionary<string, string>(new Dictionary<string, string>(resolved, StringComparer.Ordinal)),
            css.ToString());
    }
}
