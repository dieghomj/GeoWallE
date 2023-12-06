public class AssignmentStatement : Statement
{
    public AssignmentStatement(SyntaxToken nameToken, Expression rightExpression)
    {
        NameToken = nameToken;
        RightExpression = rightExpression;
    }

    private SyntaxToken NameToken;
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
