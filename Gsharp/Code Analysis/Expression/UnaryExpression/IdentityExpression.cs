
public class IdentityExpression : UnaryExpression
{
    public IdentityExpression(Expression operand)
        : base(operand) { }

    public override ExpressionKind Kind => ExpressionKind.IdentityExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.PlusToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var operatorType = Bind(visibleVariables);
        var operand = Operand.GetBoundExpression(visibleVariables);
        return new BoundIdentityExpression(operand);
    }
}
