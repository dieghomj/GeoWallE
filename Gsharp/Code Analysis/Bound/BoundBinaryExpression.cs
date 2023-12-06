public abstract class BoundBinaryExpression : BoundExpression
{
    public BoundBinaryExpression(BoundExpression left, BoundExpression right, GType resultType)
    {
        Left = left;
        Right = right;
        ResultType = resultType;
    }
    public abstract BinaryOperatorKind OperatorKind { get; }
    public BoundExpression Left { get; }
    public BoundExpression Right { get; }
    public GType ResultType { get; }
    public override GType Type => ResultType;
    protected Func<object,object,object> Calculate => BinaryOperator.GetOperatorFunc(OperatorKind);
    public override object Evaluate()
    {
        var left = Left.Evaluate();
        var right = Right.Evaluate();
        return Calculate(left, right);
    }
}
