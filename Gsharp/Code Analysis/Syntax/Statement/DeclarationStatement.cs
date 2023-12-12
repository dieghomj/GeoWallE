public class DeclarationStatement : Statement
{
    public DeclarationStatement(SyntaxToken keywordToken, SyntaxToken nameToken)
    {
        KeywordToken = keywordToken;
        NameToken = nameToken;
    }

    public SyntaxToken KeywordToken { get; private set; }
    public SyntaxToken NameToken { get; private set; }

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        var name = NameToken.Text;
        var kind = KeywordToken.Kind;
        if(!SyntaxFacts.DeclarationKeywordsTypes.ContainsKey(kind))
        {
            throw new Exception($"! SEMANTIC ERROR : {KeywordToken.Text} type doesn't exist");
        }
        if(visibleVariables.Keys.FirstOrDefault(k => k == name) != null)
        {
            throw new Exception($"! SEMANTIC ERROR : Constant {name} is already defined");
        }
        visibleVariables[name] = SyntaxFacts.DeclarationKeywordsTypes[kind];
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        var type = SyntaxFacts.DeclarationKeywordsTypes[KeywordToken.Kind];
        return new BoundDeclarationStatement(new VariableSymbol(NameToken.Text,type));
    }

}
