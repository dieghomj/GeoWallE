public class DeclarationStatement : Statement
{
    private SyntaxToken KeywordToken;
    private SyntaxToken NameToken;

    public DeclarationStatement(SyntaxToken keywordToken, SyntaxToken nameToken)
    {
        KeywordToken = keywordToken;
        NameToken = nameToken;
    }

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
