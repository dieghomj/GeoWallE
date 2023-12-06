
public class BoundIdentityExpression : BoundUnaryExpression
{
    public BoundIdentityExpression(BoundExpression operand) : base(operand)
    {
    }

    public override UnaryOperatorKind OperatorKind => UnaryOperatorKind.Identity;
}