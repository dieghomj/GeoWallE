public class BoundLogicalAndExpression : BoundBinaryExpression
{
    public BoundLogicalAndExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.LogicalAnd;
}
