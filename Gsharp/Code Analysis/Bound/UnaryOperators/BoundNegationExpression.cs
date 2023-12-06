internal class BoundNegationExpression : BoundUnaryExpression
{
    public BoundNegationExpression(BoundExpression operand) : base(operand)
    {
    }

    public override UnaryOperatorKind OperatorKind => UnaryOperatorKind.Negation;
}