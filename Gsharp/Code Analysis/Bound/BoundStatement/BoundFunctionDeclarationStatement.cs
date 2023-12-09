public class BoundFunctionDeclarationStatement : BoundStatement
{
    public BoundFunctionDeclarationStatement(FunctionSymbol functionSymbol, BoundExpression boundExpression)
    {
        FunctionSymbol = functionSymbol;
        BoundExpression = boundExpression;
    }

    public FunctionSymbol FunctionSymbol { get; }
    public BoundExpression BoundExpression { get; }

    public override void EvaluateStatement(Dictionary<string, GObject> visibleVariables)
    {
        throw new NotImplementedException();
    }
}