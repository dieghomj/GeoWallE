public class SequenceLiteralExpression : Expression
{
    public SequenceLiteralExpression(List<Expression> elements)
    {
        Elements = elements;
    }

    public SequenceLiteralExpression(Expression start, Expression? end = null)
    {
        Start = start;
        End = end;
    }

    public override ExpressionKind Kind => ExpressionKind.SequenceLiteralExpression;

    public List<Expression> Elements { get; }
    public Expression Start { get; }
    public Expression? End { get; }

    protected override GType BindExpression(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
