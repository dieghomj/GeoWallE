public class BoundMultiplicationExpression : BoundBinaryExpression
{
    public BoundMultiplicationExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Multiplication;

    public override GObject Evaluate()
    {
        dynamic left = Left.Evaluate();
        dynamic right = Right.Evaluate();
        return left * right;
    }
}
