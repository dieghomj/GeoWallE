
public class BoundGreaterExpression : BoundBinaryExpression
{
    public BoundGreaterExpression(BoundExpression left, BoundExpression right, GType resultType) 
        : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Greater;

    public override GObject Evaluate()
    {
        dynamic left = Left.Evaluate();
        dynamic right = Right.Evaluate();
        return left > right;
    }
}