public class DeclarationSequenceStatement : Statement
{

    public DeclarationSequenceStatement(SyntaxToken keywordToken, SyntaxToken nameToken)
    {
        KeywordToken = keywordToken;
        NameToken = nameToken;
    }
    private SyntaxToken KeywordToken { get; } 
    private SyntaxToken NameToken { get; }

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        var name = NameToken.Text;
        var kind = SyntaxFacts.DeclarationKeywordsTypes[KeywordToken.Kind];
        if(visibleVariables.Keys.FirstOrDefault(k => k == name) != null)
        {
            throw new Exception($"! SEMANTIC ERROR : Constant {name} is already defined");
        }
        // Binder.AddSequenceVariable(name,kind);
        visibleVariables[name] = kind.GetSequenceType();
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        var type = SyntaxFacts.DeclarationKeywordsTypes[KeywordToken.Kind].GetSequenceType();
        return new BoundSequenceDeclarationStatement(new VariableSymbol(NameToken.Text,type));
    }
}
