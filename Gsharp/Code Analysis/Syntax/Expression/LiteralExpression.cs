public class LiteralExpression : Expression
{
    private GType Type;
    public LiteralExpression(SyntaxToken literalToken, object? value)
    {
        LiteralToken = literalToken;
        Value = value;
    }

    public override ExpressionKind Kind => ExpressionKind.LiteralExpression;
    public SyntaxToken LiteralToken { get; }
    public object? Value { get; }

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var type = Type;
        var value = Value ?? 0.0;
        return new BoundLiteralExpression(value, type);
    }

    protected override GType BindExpression(Dictionary<string, GType> visibleVariables)
    {
        switch (Value)
        {
            case int:
            case double:
                Type = GType.Number;
                return GType.Number;
            case string:
                Type = GType.String;
                return GType.String;
            default:
                Type = GType.Undefined;
                return GType.Undefined;
        }
    }
}
