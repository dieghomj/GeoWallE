public class BoundLogicalAndExpression : BoundBinaryExpression
{
    public BoundLogicalAndExpression(BoundExpression left, BoundExpression right, GType resultType)
        : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.LogicalAnd;

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        dynamic left = Left.Evaluate(visibleVariables);
        dynamic right = Right.Evaluate(visibleVariables);
        return left & right;
    }
}
