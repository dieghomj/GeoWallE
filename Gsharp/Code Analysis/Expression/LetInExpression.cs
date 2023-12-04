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
        throw new NotImplementedException();
    }

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }

}
