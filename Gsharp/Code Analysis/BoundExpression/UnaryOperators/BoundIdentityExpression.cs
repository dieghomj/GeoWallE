
public class BoundIdentityExpression : BoundUnaryExpression
{
    public BoundIdentityExpression(BoundExpression operand) : base(operand)
    {
    }

    public override SyntaxKind OperatorKind => SyntaxKind.PlusToken;
}