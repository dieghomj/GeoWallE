public class BoundRemainderExpression : BoundBinaryExpression
{
    public BoundRemainderExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Remainder;
}
