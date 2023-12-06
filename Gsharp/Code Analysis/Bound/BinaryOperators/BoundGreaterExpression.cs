
public class BoundGreaterExpression : BoundBinaryExpression
{
    public BoundGreaterExpression(BoundExpression left, BoundExpression right, GType resultType) 
        : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Greater;
}