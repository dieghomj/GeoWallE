public abstract class Expression : Statement
{
    protected bool IsBinded = false;
    public abstract ExpressionKind Kind { get; }
    public abstract GType Bind(Dictionary<string, GType> visibleVariables);
    protected abstract BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables);
    public virtual BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        if (!IsBinded)
        {
            Bind(visibleVariables);
            IsBinded = true;
        }
        return InstantiateBoundExpression(visibleVariables);
    } 
    public override void BindStatement(Dictionary<string, GType> visibleVariables) => Bind(visibleVariables);
    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables) => GetBoundExpression(visibleVariables);

}
