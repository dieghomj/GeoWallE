public class FunctionDeclarationStatement : Statement
{
    public FunctionDeclarationStatement(
        SyntaxToken functionToken,
        List<SyntaxToken> parameters,
        Expression functionExpression
    )
    {
        FunctionToken = functionToken;
        Parameters = parameters;
        FunctionExpression = functionExpression;
    }

    private SyntaxToken FunctionToken { get; }
    private List<SyntaxToken> Parameters { get; }
    private Expression FunctionExpression { get; }

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
