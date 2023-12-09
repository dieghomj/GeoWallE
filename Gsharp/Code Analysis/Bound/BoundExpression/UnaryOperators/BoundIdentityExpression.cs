public class BoundIdentityExpression : BoundUnaryExpression
{
    public BoundIdentityExpression(BoundExpression operand, GType operatorType)
        : base(operand, operatorType) { }

    public override UnaryOperatorKind OperatorKind => UnaryOperatorKind.Identity;

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        dynamic operand = Operand.Evaluate(visibleVariables);
        return +operand;
    }
}
