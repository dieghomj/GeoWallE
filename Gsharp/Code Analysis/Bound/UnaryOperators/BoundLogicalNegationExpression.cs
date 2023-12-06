internal class BoundLogicalNegationExpression : BoundUnaryExpression
{
    public BoundLogicalNegationExpression(BoundExpression operand) : base(operand)
    {
    }

    public override UnaryOperatorKind OperatorKind => UnaryOperatorKind.LogicalNegation;
}