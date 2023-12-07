public class LetInExpression : Expression
{
    public LetInExpression(List<Statement> instructions, Expression inExpression)
    {
        Instructions = instructions;
        InExpression = inExpression;
    }

    public IEnumerable<Statement> Instructions { get; }
    public Expression InExpression { get; }
    public override ExpressionKind Kind => ExpressionKind.LetInExpression;

    public override GType Bind(Dictionary<string, GType> visibleVariables)
    {
        foreach (var instruction in Instructions)
            instruction.BindStatement(visibleVariables);
        var expressionType = InExpression.Bind(visibleVariables);
        return expressionType;
    }

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        List<BoundStatement> boundInstructions = new List<BoundStatement>();

        foreach (var instruction in Instructions)
            boundInstructions.Add(instruction.GetBoundStatement(visibleVariables));

        var boundExpression = InExpression.GetBoundExpression(visibleVariables);
        return new BoundLetInExpression(boundInstructions, boundExpression);
    }

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var copyDictionary = new Dictionary<string, GType>(visibleVariables);
        if(!IsBinded)
        {
            Bind(copyDictionary);
            IsBinded = true;
        }
        return InstantiateBoundExpression(copyDictionary);
    }
}
