public class BoundLogicalAndExpression : BoundBinaryExpression
{
    public BoundLogicalAndExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override SyntaxKind OperatorKind => SyntaxKind.AmpersandToken;
}
