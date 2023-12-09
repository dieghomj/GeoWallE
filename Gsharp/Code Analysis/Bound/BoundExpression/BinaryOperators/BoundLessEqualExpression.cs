public class BoundLessEqualExpression : BoundBinaryExpression
{
    public BoundLessEqualExpression(BoundExpression left, BoundExpression right, GType resultType)
        : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.LessEqual;

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        dynamic left = Left.Evaluate(visibleVariables);
        dynamic right = Right.Evaluate(visibleVariables);
        return left <= right;
    }
}
