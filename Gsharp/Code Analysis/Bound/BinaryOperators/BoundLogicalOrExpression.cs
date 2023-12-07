public class BoundLogicalOrExpression : BoundBinaryExpression
{
    public BoundLogicalOrExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.LogicalOr;

    public override GObject Evaluate()
    {
        dynamic left = Left.Evaluate();
        dynamic right = Right.Evaluate();
        return left | right;
    }
}
