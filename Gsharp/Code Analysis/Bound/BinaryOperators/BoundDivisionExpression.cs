public class BoundDivisionExpression : BoundBinaryExpression
{
    public BoundDivisionExpression(BoundExpression left, BoundExpression right, GType resultType)
        : base(left,right,resultType) { }
    public override BinaryOperatorKind OperatorKind => BinaryOperatorKind.Division;
}