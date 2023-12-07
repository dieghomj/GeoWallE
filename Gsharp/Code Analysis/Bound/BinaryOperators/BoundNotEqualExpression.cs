public class BoundNotEqualExpression : BoundBinaryExpression
{
    public BoundNotEqualExpression(BoundExpression left, BoundExpression right, GType resultType)
        : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.NotEquals;

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        if (!Left.Evaluate(visibleVariables).Equals(Right.Evaluate(visibleVariables)))
            return new Number(1);
        return new Number(0);
    }
}
