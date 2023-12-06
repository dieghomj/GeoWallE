public class BoundSubtractionExpression : BoundBinaryExpression
{
    public BoundSubtractionExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Subtraction;
}