public class BoundLessEqualExpression : BoundBinaryExpression
{
    public BoundLessEqualExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.LessEqual;
}