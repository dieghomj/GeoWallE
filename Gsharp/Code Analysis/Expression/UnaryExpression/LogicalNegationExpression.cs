public class LogicalNegationExpression : UnaryExpression
{
    public LogicalNegationExpression(Expression operand)
        : base(operand) { }
    public override ExpressionKind Kind => ExpressionKind.LogicalNegationExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.BangToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var operatorType = Bind(visibleVariables);
        var operand = Operand.GetBoundExpression(visibleVariables);
        return new BoundLogicalNegationExpression(operand);
    }
}
