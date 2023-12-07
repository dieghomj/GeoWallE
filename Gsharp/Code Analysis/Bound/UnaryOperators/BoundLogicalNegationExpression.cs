internal class BoundLogicalNegationExpression : BoundUnaryExpression
{
    public BoundLogicalNegationExpression(BoundExpression operand, GType operatorType)
        : base(operand, operatorType) { }

    public override UnaryOperatorKind OperatorKind => UnaryOperatorKind.LogicalNegation;

    public override GObject Evaluate()
    {
        dynamic operand = Operand.Evaluate();
        return !operand;
    }
}
