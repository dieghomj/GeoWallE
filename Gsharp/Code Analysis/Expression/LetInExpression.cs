public class LetInExpression : Expression
{
    public LetInExpression(List<Statement> instructions, Expression inExpression)
    {
        Instructions = instructions;
        InExpression = inExpression;
    }

    public IEnumerable<Statement> Instructions { get; }
    public Expression InExpression { get; }
    public override SyntaxKind Kind => SyntaxKind.LetInExpression;

    public override GType Bind(Dictionary<string, GType> visibleVariables)
    {
        // List<GType> instructionsType = new List<GType>();
        foreach (var instruction in Instructions)
            instruction.BindStatement(visibleVariables);
        // instructionsType.Add(instruction.Bind(visibleVariables));
        var expressionType = InExpression.Bind(visibleVariables);
        return expressionType;
    }

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
        // Modificar para Statement

        // List<BoundExpression> boundInstructions = new List<BoundExpression>();
        // Bind(new Dictionary<string, GType>(visibleVariables));

        // foreach (var instruction in Instructions)
        //     boundInstructions.Add(instruction.GetBoundExpression(visibleVariables));

        // var boundExpression = Expression.GetBoundExpression(visibleVariables);
        // return new BoundLetInExpression(boundInstructions, boundExpression);
    }
}
