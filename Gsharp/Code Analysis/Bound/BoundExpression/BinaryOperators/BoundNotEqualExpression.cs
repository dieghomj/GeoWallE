public class BoundNotEqualExpression : BoundBinaryExpression
{
    public BoundNotEqualExpression(BoundExpression left, BoundExpression right, GType resultType)
        : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.NotEquals;

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        dynamic left = Left.Evaluate(visibleVariables);
        dynamic right = Right.Evaluate(visibleVariables);
        return left != right;
    }
}
