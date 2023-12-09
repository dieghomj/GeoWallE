public class PredefinedFunctionExpression : Expression
{
    public PredefinedFunctionExpression(SyntaxToken functionToken, List<Expression> arguments)
    {
        FunctionToken = functionToken;
        Arguments = arguments;
    }

    private SyntaxToken FunctionToken;
    private List<Expression> Arguments { get; }
    public override ExpressionKind Kind => ExpressionKind.PredefinedFunctionExpression;

    protected override GType BindExpression(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
} 
