
public class IdentityExpression : UnaryExpression
{
    public IdentityExpression(Expression operand)
        : base(operand) { }

    public override ExpressionKind Kind => ExpressionKind.IdentityExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.PlusToken;

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var operatorType = ResultType;
        var operand = Operand.GetBoundExpression(visibleVariables);
        return new BoundIdentityExpression(operand, operatorType);
    }
}
