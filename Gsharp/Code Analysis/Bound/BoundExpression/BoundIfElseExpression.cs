internal class BoundIfElseExpression : BoundExpression
{
    public BoundIfElseExpression(
        BoundExpression condition,
        BoundExpression trueExpression,
        BoundExpression falseExpression
    )
    {
        Condition = condition;
        TrueExpression = trueExpression;
        FalseExpression = falseExpression;
    }

    public override GType Type => TrueExpression.Type;

    public BoundExpression Condition { get; }
    public BoundExpression TrueExpression { get; }
    public BoundExpression FalseExpression { get; }

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        if (Condition.Evaluate(visibleVariables).IsTrue())
            return TrueExpression.Evaluate(visibleVariables);
        else
            return FalseExpression.Evaluate(visibleVariables);
    }
}
