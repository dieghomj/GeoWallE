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

    protected override GType Bind(Dictionary<VariableSymbol, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
