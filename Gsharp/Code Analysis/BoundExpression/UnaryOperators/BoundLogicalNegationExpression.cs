internal class BoundLogicalNegationExpression : BoundUnaryExpression
{
    public BoundLogicalNegationExpression(BoundExpression operand) : base(operand)
    {
    }

    public override SyntaxKind OperatorKind => SyntaxKind.BangToken;
}