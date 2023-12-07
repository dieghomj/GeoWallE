internal class BoundLogicalNegationExpression : BoundUnaryExpression
{
    public BoundLogicalNegationExpression(BoundExpression operand, GType operatorType) : base(operand,operatorType)
    {
    }

    public override UnaryOperatorKind OperatorKind => UnaryOperatorKind.LogicalNegation;
}