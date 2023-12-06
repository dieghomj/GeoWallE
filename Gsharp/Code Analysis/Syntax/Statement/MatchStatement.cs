public class MatchStatement : Statement
{
    public MatchStatement(List<SyntaxToken> nameTokens, Expression rightExpression)
    {
        NameTokens = nameTokens;
        RightExpression = rightExpression;
    }

    private List<SyntaxToken> NameTokens;
    private Expression RightExpression;

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
