public class BoundLetInExpression : BoundExpression
{
    public BoundLetInExpression(List<BoundStatement> instructions, BoundExpression expression)
    {
        Instructions = instructions;
        Expression = expression;
    }

    public override GType Type => Expression.Type;

    protected List<BoundStatement> Instructions { get; }
    protected BoundExpression Expression { get; }

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        Dictionary<string, GObject> localVariables = new();
        foreach (string key in visibleVariables.Keys)
            localVariables[key] = visibleVariables[key];

        foreach (var instruction in Instructions)
            instruction.EvaluateStatement(localVariables);

        return Expression.Evaluate(localVariables);
    }
}
