public class NegationExpression : UnaryExpression
{
    public NegationExpression(Expression operand) : base(operand)
    {
    }

    public override ExpressionKind Kind => ExpressionKind.NegationExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.MinusToken;

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var operatorType = ResultType;
        var operand = Operand.GetBoundExpression(visibleVariables);
        return new BoundNegationExpression(operand, operatorType);
    }
}
