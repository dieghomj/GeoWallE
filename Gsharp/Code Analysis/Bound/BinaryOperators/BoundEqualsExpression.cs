public class BoundEqualsExpression : BoundBinaryExpression
{
    public BoundEqualsExpression(BoundExpression left, BoundExpression right, GType resultType)
        : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Equals;

    public override GObject Evaluate()
    {
        if (Left.Evaluate().Equals(Right.Evaluate()))
            return new Number(1);
        return new Number(0);
    }
}
