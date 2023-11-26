public class LiteralExpression : Expression
{
    public LiteralExpression(SyntaxToken literalToken, object value)
    {
        LiteralToken = literalToken;
        Value = value;
    }

    public override SyntaxKind Kind => SyntaxKind.LiteralExpression;
    public SyntaxToken LiteralToken { get; }
    public object Value { get; }

    public override Func<object> Evaluate => () => Value;

    public override Func<Type> Bind => () => Type;

    public override Type Type => Value.GetType();
}
