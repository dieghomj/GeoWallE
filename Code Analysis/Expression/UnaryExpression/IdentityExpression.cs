public class IdentityExpression : UnaryExpression
{
    public IdentityExpression(Expression operand)
        : base(operand) { }

    protected override GType Bind(Dictionary<VariableSymbol, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
