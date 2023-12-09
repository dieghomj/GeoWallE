internal class BoundNegationExpression : BoundUnaryExpression
{
    public BoundNegationExpression(BoundExpression operand, GType operatorType)
        : base(operand, operatorType) { }

    public override UnaryOperatorKind OperatorKind => UnaryOperatorKind.Negation;

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        dynamic operand = Operand.Evaluate(visibleVariables);
        return -operand;
    }
}
