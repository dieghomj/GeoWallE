public class BoundGreaterEqualExpression : BoundBinaryExpression
{
    public BoundGreaterEqualExpression(BoundExpression left, BoundExpression right, GType resultType) 
        : base(left, right, resultType) { }
    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.GreaterEqual;
}