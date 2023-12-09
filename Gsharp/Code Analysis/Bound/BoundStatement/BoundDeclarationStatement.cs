internal class BoundDeclarationStatement : BoundStatement
{
    public BoundDeclarationStatement(VariableSymbol variableSymbol)
    {
        VariableSymbol = variableSymbol;
    }

    public VariableSymbol VariableSymbol { get; }

    public override void EvaluateStatement(Dictionary<string, GObject> visibleVariables)
    {
        throw new NotImplementedException();
    }
}