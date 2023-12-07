public class BoundEqualsExpression : BoundBinaryExpression
{
    public BoundEqualsExpression(BoundExpression left, BoundExpression right, GType resultType)
        : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Equals;

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        if (Left.Evaluate(visibleVariables).Equals(Right.Evaluate(visibleVariables)))
            return new Number(1);
        return new Number(0);
    }
}
