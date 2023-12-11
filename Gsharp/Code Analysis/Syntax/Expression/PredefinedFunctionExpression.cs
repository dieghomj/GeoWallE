public class PredefinedFunctionExpression : Expression
{
    private BoundPredefinedFunction? function;
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
        var argumentsLog = ""; 
        var argumentsType = new List<GType>();
        foreach (var argument in Arguments)
        {
            argumentsType.Add(argument.Bind(visibleVariables));
            argumentsLog += argumentsType.Last() + " ";
        }


        var name = FunctionToken.Text;
        var predefinedFunction = BoundPredefinedFunction.Bind(name, argumentsType.Count, argumentsType.ToArray());

        if (predefinedFunction == null)
        {
            throw new Exception($"! SEMANTIC ERROR : Predefined function {name} with {Arguments.Count} argument(s) of type {argumentsLog}not found");
        }

        function = predefinedFunction;

        return predefinedFunction.ResultType;
    }

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        List<BoundExpression> arguments = new List<BoundExpression>();
        foreach (var argument in Arguments)
            arguments.Add(argument.GetBoundExpression(visibleVariables));

        return new BoundPredefinedFunctionExpression(FunctionToken.Text, arguments, function);
    }
    
}
