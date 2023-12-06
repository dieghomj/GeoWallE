public abstract class Expression : Statement
{
    public abstract ExpressionKind Kind { get; }
    public abstract GType Bind(Dictionary<string, GType> visibleVariables);
    public abstract BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables);
    public override void BindStatement(Dictionary<string, GType> visibleVariables) => Bind(visibleVariables);
    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables) => GetBoundExpression(visibleVariables);

}
