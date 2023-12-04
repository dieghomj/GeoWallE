public class LogicalNegationExpression : UnaryExpression
{
    public LogicalNegationExpression(Expression operand)
        : base(operand) { }
    public override SyntaxKind Kind => SyntaxKind.LogicalNegationExpression;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var operatorType = Bind(visibleVariables);
        var operand = Operand.GetBoundExpression(visibleVariables);
        return new BoundLogicalNegationExpression(operand);
    }
}
