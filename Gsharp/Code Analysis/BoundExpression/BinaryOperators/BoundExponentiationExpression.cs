
public class BoundExponentiationExpression : BoundBinaryExpression
{
    public BoundExponentiationExpression(BoundExpression left, BoundExpression right, GType resultType)
        : base(left,right,resultType) { }
    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Exponentiation;
}