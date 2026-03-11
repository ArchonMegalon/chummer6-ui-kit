namespace Chummer.Ui.Kit.Theming;

public sealed class CompiledTheme
{
    public CompiledTheme(string name, IReadOnlyDictionary<string, string> resolvedTokens, string cssVariables)
    {
        Name = name;
        ResolvedTokens = resolvedTokens;
        CssVariables = cssVariables;
    }

    public string Name { get; }

    public IReadOnlyDictionary<string, string> ResolvedTokens { get; }

    public string CssVariables { get; }
}
