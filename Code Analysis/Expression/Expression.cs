public abstract class Expression
{
    public abstract SyntaxKind Kind { get; }
    protected abstract GType Bind(Dictionary<VariableSymbol, GType> visibleVariables);
}
