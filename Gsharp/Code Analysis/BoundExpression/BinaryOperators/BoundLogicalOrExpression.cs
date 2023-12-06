public class BoundLogicalOrExpression : BoundBinaryExpression
{
    public BoundLogicalOrExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.PipeToken;
}
