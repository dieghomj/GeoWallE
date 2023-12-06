public class LetInExpression : Expression
{
    public LetInExpression(List<Expression> instructions, Expression expression)
    {
        Instructions = instructions;
        Expression = expression;
    }

    public IEnumerable<Expression> Instructions { get; }
    public Expression Expression { get; }
    public override SyntaxKind Kind => SyntaxKind.LetInExpression;

    public override GType Bind(Dictionary<string, GType> visibleVariables)
    {
        List<GType> instructionsType = new List<GType>();
        foreach (var instruction in Instructions)
            instructionsType.Add(instruction.Bind(visibleVariables));
        var expressionType = Expression.Bind(visibleVariables);
        return expressionType;
    
    }

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        List<BoundExpression> boundInstructions  = new List<BoundExpression>();
        Bind(new Dictionary<string, GType>(visibleVariables));

        foreach (var instruction in Instructions)
            boundInstructions.Add(instruction.GetBoundExpression(visibleVariables));

        var boundExpression = Expression.GetBoundExpression(visibleVariables);
        return new BoundLetInExpression(boundInstructions, boundExpression);        
    }

}