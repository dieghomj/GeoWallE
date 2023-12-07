internal class BoundNegationExpression : BoundUnaryExpression
{
    public BoundNegationExpression(BoundExpression operand, GType operatorType) : base(operand,operatorType)
    {
    }

    public override UnaryOperatorKind OperatorKind => UnaryOperatorKind.Negation;
}