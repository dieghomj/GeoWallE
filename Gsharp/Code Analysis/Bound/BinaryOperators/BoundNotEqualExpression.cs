public class BoundNotEqualExpression : BoundBinaryExpression
{
    public BoundNotEqualExpression(BoundExpression left, BoundExpression right, GType resultType)
        : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.NotEquals;

    public override GObject Evaluate()
    {
        if (!Left.Evaluate().Equals(Right.Evaluate()))
            return new Number(1);
        return new Number(0);
    }
}
