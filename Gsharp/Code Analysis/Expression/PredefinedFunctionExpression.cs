public class PredefinedFunctionExpression : Expression
{
    public PredefinedFunctionExpression(SyntaxToken functionToken, List<Expression> arguments)
    {
        FunctionToken = functionToken;
        Arguments = arguments;
    }

    private SyntaxToken FunctionToken;
    private List<Expression> Arguments { get; }
    public override SyntaxKind Kind => SyntaxKind.PredefinedFunctionExpression;

    public override GType Bind(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
