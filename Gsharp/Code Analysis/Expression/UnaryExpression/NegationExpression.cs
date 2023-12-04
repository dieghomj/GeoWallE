public class NegationExpression : UnaryExpression
{
    public NegationExpression(Expression operand) : base(operand)
    {
    }

    public override SyntaxKind Kind => SyntaxKind.NegationExpression;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var operatorType = Bind(visibleVariables);
        var operand = Operand.GetBoundExpression(visibleVariables);
        return new BoundNegationExpression(operand);
    }
}
