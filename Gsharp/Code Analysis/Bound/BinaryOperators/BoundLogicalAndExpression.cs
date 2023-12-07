public class BoundLogicalAndExpression : BoundBinaryExpression
{
    public BoundLogicalAndExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.LogicalAnd;

    public override GObject Evaluate()
    {
        dynamic left = Left.Evaluate();
        dynamic right = Right.Evaluate();
        return left & right;
    }
}
