internal class BoundIfElseExpression : BoundExpression
{
    public BoundIfElseExpression(BoundExpression condition, BoundExpression trueExpression, BoundExpression falseExpression)
    {
        Condition = condition;
        TrueExpression = trueExpression;
        FalseExpression = falseExpression;
    }

    public override GType Type => TrueExpression.Type;

    public BoundExpression Condition { get; }
    public BoundExpression TrueExpression { get; }
    public BoundExpression FalseExpression { get; }

    public override GObject Evaluate()
    {
        throw new NotImplementedException();
    }
}