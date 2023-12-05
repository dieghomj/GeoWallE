public sealed class VariableSymbol
{
    internal VariableSymbol(string name, GType type)
    {
        Name = name;
        Type = type;
    }

    public string Name { get; }
    public GType Type { get; }
}
