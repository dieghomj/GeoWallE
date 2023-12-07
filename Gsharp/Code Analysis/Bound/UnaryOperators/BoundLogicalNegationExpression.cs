internal class BoundLogicalNegationExpression : BoundUnaryExpression
{
    public BoundLogicalNegationExpression(BoundExpression operand, GType operatorType)
        : base(operand, operatorType) { }

    public override UnaryOperatorKind OperatorKind => UnaryOperatorKind.LogicalNegation;

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        dynamic operand = Operand.Evaluate(visibleVariables);
        return !operand;
    }
}
