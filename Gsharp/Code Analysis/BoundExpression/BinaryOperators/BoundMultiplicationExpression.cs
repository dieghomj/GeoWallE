public class BoundMultiplicationExpression : BoundBinaryExpression
{
    public BoundMultiplicationExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override SyntaxKind OperatorKind => SyntaxKind.StarToken;
}
