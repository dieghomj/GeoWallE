public class BoundLessExpression : BoundBinaryExpression
{
    public BoundLessExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Less;
}
