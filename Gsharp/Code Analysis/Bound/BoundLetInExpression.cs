public class BoundLetInExpression : BoundExpression
{
    public BoundLetInExpression(List<BoundStatement> instructions, BoundExpression expression)
    {
        Instructions = instructions;
        Expression = expression;
    }

    public override GType Type => Expression.Type;

    public List<BoundStatement> Instructions { get; }
    public BoundExpression Expression { get; }

    public override GObject Evaluate()
    {
        throw new NotImplementedException();
    }

    public override void EvaluateStatement()
    {
        throw new NotImplementedException();
    }
}