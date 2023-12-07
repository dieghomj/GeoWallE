public class BoundIdentityExpression : BoundUnaryExpression
{
    public BoundIdentityExpression(BoundExpression operand, GType operatorType)
        : base(operand, operatorType) { }

    public override UnaryOperatorKind OperatorKind => UnaryOperatorKind.Identity;

    public override GObject Evaluate()
    {
        dynamic operand = Operand.Evaluate();
        return +operand;
    }
}
