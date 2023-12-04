
public class BoundExponentiationExpression : BoundBinaryExpression
{
    public BoundExponentiationExpression(BoundExpression left, BoundExpression right, GType resultType)
        : base(left,right,resultType) { }
    public override SyntaxKind OperatorKind => SyntaxKind.CircumflexToken;
}