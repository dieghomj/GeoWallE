public class DeclarationSequenceStatement : Statement
{
    private SyntaxToken KeywordToken;
    private SyntaxToken NameToken;

    public DeclarationSequenceStatement(SyntaxToken keywordToken, SyntaxToken nameToken)
    {
        KeywordToken = keywordToken;
        NameToken = nameToken;
    }

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        var name = NameToken.Text;
        var kind = KeywordToken.Kind;
        if(visibleVariables.Keys.FirstOrDefault(k => k == name) != null)
        {
            System.Console.WriteLine($"! SEMANTIC ERROR : Constant {name} is already defined");
            return;
        }
        visibleVariables[name] = SyntaxFacts.DeclarationKeywordsTypes[kind];
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        var type = SyntaxFacts.DeclarationKeywordsTypes[KeywordToken.Kind];
        return new BoundSequenceDeclarationStatement(new VariableSymbol(NameToken.Text,type));
    }
}
