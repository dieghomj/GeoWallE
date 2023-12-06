public class BoundLetInExpression : BoundExpression
{
    public BoundLetInExpression(List<BoundExpression> instructions, BoundExpression expression)
    {
        Instructions = instructions;
        Expression = expression;
    }

    public override GType Type => Expression.Type;

    public List<BoundExpression> Instructions { get; }
    public BoundExpression Expression { get; }

    public override object Evaluate()
    {
        throw new NotImplementedException();
    }
}