public class BoundExponentiationExpression : BoundBinaryExpression
{
    public BoundExponentiationExpression(
        BoundExpression left,
        BoundExpression right,
        GType resultType
    )
        : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Exponentiation;

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        dynamic left = Left.Evaluate(visibleVariables);
        dynamic right = Right.Evaluate(visibleVariables);
        return left ^ right;
    }
}
