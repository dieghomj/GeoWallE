public abstract class BoundBinaryExpression : BoundExpression
{
    public BoundBinaryExpression(BoundExpression left, BoundExpression right, GType resultType)
    {
        Left = left;
        Right = right;
        ResultType = resultType;
    }

    public abstract BinaryOperatorKind OperatorKind { get; }
    protected BoundExpression Left { get; }
    protected BoundExpression Right { get; }
    protected GType ResultType { get; }
    public override GType Type => ResultType;
}
