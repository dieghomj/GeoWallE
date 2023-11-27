public class LiteralExpression : Expression
{
    public LiteralExpression(SyntaxToken literalToken, object value)
    {
        LiteralToken = literalToken;
        Value = value;
    }

    public override SyntaxKind Kind => SyntaxKind.LiteralExpression;
    public SyntaxToken LiteralToken { get; }
    public object Value { get; }

    protected override GType Bind(Dictionary<VariableSymbol, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
