
public class BoundExponentiationExpression : BoundBinaryExpression
{
    public BoundExponentiationExpression(BoundExpression left, BoundExpression right, GType resultType)
        : base(left,right,resultType) { }
    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Exponentiation;

    public override GObject Evaluate()
    {
        dynamic left = Left.Evaluate();
        dynamic right = Right.Evaluate();
        return left ^ right;
    }
}