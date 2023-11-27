public class NameExpression : Expression
{
    public NameExpression(SyntaxToken identifierToken)
    {
        IdentifierToken = identifierToken;
    }

    public override SyntaxKind Kind => SyntaxKind.NameExpression;

    public SyntaxToken IdentifierToken { get; }

    protected override GType Bind(Dictionary<VariableSymbol, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
