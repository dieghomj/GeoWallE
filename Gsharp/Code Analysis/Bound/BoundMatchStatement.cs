public class BoundMatchStatement : BoundStatement
{
    public BoundMatchStatement(List<VariableSymbol> boundVariables, BoundExpression boundSequence)
    {
        BoundVariables = boundVariables;
        BoundSequence = boundSequence;
    }

    public List<VariableSymbol> BoundVariables { get; }
    public BoundExpression BoundSequence { get; }

    public override void EvaluateStatement()
    {
        throw new NotImplementedException();
    }
}