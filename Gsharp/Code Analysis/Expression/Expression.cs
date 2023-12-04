public abstract class Expression
{
    public abstract SyntaxKind Kind { get; }
    public abstract GType Bind(Dictionary<string, GType> visibleVariables);
    public abstract BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables);
}
