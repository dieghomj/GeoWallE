public class LogicalNegationExpression : UnaryExpression
{
    public LogicalNegationExpression(Expression operand)
        : base(operand) { }

    protected override GType Bind(Dictionary<VariableSymbol, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
