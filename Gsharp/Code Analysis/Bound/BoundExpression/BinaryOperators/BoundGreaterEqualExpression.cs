public class BoundGreaterEqualExpression : BoundBinaryExpression
{
    public BoundGreaterEqualExpression(
        BoundExpression left,
        BoundExpression right,
        GType resultType
    )
        : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.GreaterEqual;

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        dynamic left = Left.Evaluate(visibleVariables);
        dynamic right = Right.Evaluate(visibleVariables);
        return left >= right;
    }
}
