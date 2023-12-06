public class BoundNotEqualExpression : BoundBinaryExpression
{
    public BoundNotEqualExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.NotEquals;
}
