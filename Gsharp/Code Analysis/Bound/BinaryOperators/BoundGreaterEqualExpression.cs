public class BoundGreaterEqualExpression : BoundBinaryExpression
{
    public BoundGreaterEqualExpression(BoundExpression left, BoundExpression right, GType resultType) 
        : base(left, right, resultType) { }
    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.GreaterEqual;

    public override GObject Evaluate()
    {
        dynamic left = Left.Evaluate();
        dynamic right = Right.Evaluate();
        return left >= right;
    }
}