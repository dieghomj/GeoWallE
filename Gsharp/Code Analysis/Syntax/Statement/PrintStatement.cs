public class PrintStatement : Statement
{
    public PrintStatement(Expression expression)
    {
        Expression = expression;
    }

    private Expression Expression { get; }

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        return new BoundPrintStatement(Expression.GetBoundExpression(visibleVariables));
    }
}
