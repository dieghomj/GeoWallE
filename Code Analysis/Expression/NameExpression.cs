
public class NameExpression : Expression
{
    public NameExpression(SyntaxToken identifierToken)
    {
        IdentifierToken = identifierToken;
    }

    public override SyntaxKind Kind => SyntaxKind.NameExpression;

    public SyntaxToken IdentifierToken { get; }

    public override Func<object> Evaluate => throw new NotImplementedException();

    public override Func<Type> Bind => throw new NotImplementedException();

    public override Type Type => throw new NotImplementedException();
}
