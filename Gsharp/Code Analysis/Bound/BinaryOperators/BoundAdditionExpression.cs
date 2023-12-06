public class BoundAdditionExpression : BoundBinaryExpression
{
    public BoundAdditionExpression(BoundExpression left, BoundExpression right, GType resultType)
        : base(left, right, resultType) { }
    public override GType Type => ResultType;
    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Addition;
}
