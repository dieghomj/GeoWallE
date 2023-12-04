
public class IdentityExpression : UnaryExpression
{
    public IdentityExpression(Expression operand)
        : base(operand) { }

    public override SyntaxKind Kind => SyntaxKind.IdentityExpression;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var operatorType = Bind(visibleVariables);
        var operand = Operand.GetBoundExpression(visibleVariables);
        return new BoundIdentityExpression(operand);
    }
}
