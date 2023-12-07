
public class BoundEqualsExpression : BoundBinaryExpression
{
    public BoundEqualsExpression(BoundExpression left, BoundExpression right, GType resultType)
        : base(left,right,resultType) { }
    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Equals;
}