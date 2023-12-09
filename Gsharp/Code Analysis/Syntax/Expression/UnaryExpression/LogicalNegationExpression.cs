public class LogicalNegationExpression : UnaryExpression
{
    public LogicalNegationExpression(Expression operand)
        : base(operand) { }
    public override ExpressionKind Kind => ExpressionKind.LogicalNegationExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.BangToken;

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var operatorType = ResultType;
        var operand = Operand.GetBoundExpression(visibleVariables);
        return new BoundLogicalNegationExpression(operand, operatorType);
    }
}
