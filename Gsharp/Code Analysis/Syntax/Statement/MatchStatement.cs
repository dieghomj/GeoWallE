public class MatchStatement : Statement
{
    public MatchStatement(List<SyntaxToken> nameTokens, Expression sequenceExpression)
    {
        NameTokens = nameTokens;
        SequenceExpression = sequenceExpression;
    }

    private List<SyntaxToken> NameTokens;
    private Expression SequenceExpression;

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        var sequenceType = SequenceExpression.Bind(visibleVariables);
        foreach (var nameToken in NameTokens)
        {
            var variableName = nameToken.Text;

            if (variableName == "_")
                continue;

            if (visibleVariables.Keys.FirstOrDefault(k => k == variableName) != null)
            {
                throw new Exception($"Constant {variableName} is already defined");
            }

            visibleVariables[variableName] = sequenceType;
        }
        var lastVariable = NameTokens.Last().Text;
        
        Binder.AddSequenceVariable(lastVariable,sequenceType);
        visibleVariables[lastVariable] = GType.Sequence;
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        var boundSequence = SequenceExpression.GetBoundExpression(visibleVariables);

        List<VariableSymbol> boundVariables = new List<VariableSymbol>();

        foreach (var nameToken in NameTokens)
        {
            var variableSymbol = new VariableSymbol(nameToken.Text, boundSequence.Type);
            boundVariables.Add(variableSymbol);
        }

        return new BoundMatchStatement(boundVariables, boundSequence);

    }
}
