internal class BoundNegationExpression : BoundUnaryExpression
{
    public BoundNegationExpression(BoundExpression operand) : base(operand)
    {
    }

    public override SyntaxKind OperatorKind => SyntaxKind.MinusToken;
}