using Gsharp;

public class BoundPrintStatement : BoundStatement
{
    public BoundPrintStatement(BoundExpression boundExpression)
    {
        BoundExpression = boundExpression;
    }

    private BoundExpression BoundExpression { get; }

    public override void EvaluateStatement(Dictionary<string, GObject> visibleVariables)
    {
        /* Implementacion temporal */
        Compiler.Print(BoundExpression.Evaluate(visibleVariables).ToString());
    }
}
