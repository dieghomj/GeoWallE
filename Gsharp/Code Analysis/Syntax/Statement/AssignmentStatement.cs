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
        var variableName = NameToken.Text;
        var rightType = RightExpression.Bind(visibleVariables);

        if (visibleVariables.ContainsKey(variableName))
        {
            throw new Exception($"Constant {variableName} is already defined");
        }
        visibleVariables[variableName] = rightType;
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        var boundRightExpression = RightExpression.GetBoundExpression(visibleVariables);
        var variableSymbol = new VariableSymbol(NameToken.Text, boundRightExpression.Type);
        return new BoundAssignmentStatement(variableSymbol, boundRightExpression);
    }
}
