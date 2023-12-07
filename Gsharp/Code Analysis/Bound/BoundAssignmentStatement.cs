class BoundAssignmentStatement : BoundStatement
{
    public BoundAssignmentStatement(VariableSymbol variableSymbol, BoundExpression rightExpression)
    {
        VariableSymbol = variableSymbol;
        RightExpression = rightExpression;
    }

    public VariableSymbol VariableSymbol { get; }
    public BoundExpression RightExpression { get; }

    public override void EvaluateStatement(Dictionary<string, GObject> visibleVariables)
    {
        visibleVariables[VariableSymbol.Name] = RightExpression.Evaluate(visibleVariables);
    }
}
