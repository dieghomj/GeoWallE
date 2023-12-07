public class SequenceLiteralExpression : Expression
{
    private List<Expression> Elements;
    private Expression? Start = null;
    private Expression? End = null;

    public SequenceLiteralExpression(List<Expression> elements)
    {
        Elements = elements;
    }

    public SequenceLiteralExpression(Expression start, Expression? end = null)
    {
        Elements = new List<Expression>();
        Start = start;
        End = end;
    }

    public override ExpressionKind Kind => ExpressionKind.SequenceLiteralExpression;

    public override GType Bind(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
