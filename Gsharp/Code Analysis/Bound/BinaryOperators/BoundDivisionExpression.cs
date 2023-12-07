public class BoundDivisionExpression : BoundBinaryExpression
{
    public BoundDivisionExpression(BoundExpression left, BoundExpression right, GType resultType)
        : base(left,right,resultType) { }
    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Division;

    public override GObject Evaluate()
    {
        dynamic left = Left.Evaluate();
        dynamic right = Right.Evaluate();
        return left / right;
    }
}