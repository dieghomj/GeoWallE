public class LiteralExpression : Expression
{
    public LiteralExpression(SyntaxToken literalToken, object? value)
    {
        LiteralToken = literalToken;
        Value = value;
    }

    public override ExpressionKind Kind => ExpressionKind.LiteralExpression;
    public SyntaxToken LiteralToken { get; }
    public object? Value { get; }

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var type = Bind(visibleVariables);
        var value = Value ?? 0.0;
        return new BoundLiteralExpression(value, type);
    }

    public override GType Bind(Dictionary<string, GType> visibleVariables)
    {
        switch (Value)
        {
            case int:
            case double:
                return GType.Number;
            case string:
                return GType.String;
            default:
                return GType.Undefined;
        }
    }
}
