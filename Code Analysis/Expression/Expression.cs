public abstract class Expression
{
    public abstract GObject Evaluate(Dictionary<VariableSymbol, GObject> visibleVariables);
    public abstract GType Bind(Dictionary<VariableSymbol, GType> visibleVariables);
    public abstract SyntaxKind Kind { get; }
}
