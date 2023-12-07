public class BoundRemainderExpression : BoundBinaryExpression
{
    public BoundRemainderExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Remainder;

    public override GObject Evaluate()
    {
        dynamic left = Left.Evaluate();
        dynamic right = Right.Evaluate();
        return left % right;
    }
}
