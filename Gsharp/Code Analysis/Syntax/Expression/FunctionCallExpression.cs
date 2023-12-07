public class FunctionCallExpression : Expression
{
    public FunctionCallExpression(SyntaxToken functionToken, List<Expression> arguments)
    {
        FunctionToken = functionToken;
        Arguments = arguments;
    }

    public override ExpressionKind Kind => ExpressionKind.FunctionCallExpression;
    public SyntaxToken FunctionToken { get; }
    public List<Expression> Arguments { get; }

    public override GType Bind(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
