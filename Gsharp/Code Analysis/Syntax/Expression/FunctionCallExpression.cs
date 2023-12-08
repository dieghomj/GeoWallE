using System.Reflection.Metadata.Ecma335;
using Gsharp;

public class FunctionCallExpression : Expression
{
    public FunctionCallExpression(SyntaxToken functionToken, List<Expression> arguments)
    {
        FunctionToken = functionToken;
        Arguments = arguments;
    }

    public SyntaxToken FunctionToken { get; }
    public List<Expression> Arguments { get; }
    public override ExpressionKind Kind => ExpressionKind.FunctionCallExpression;

    protected override GType BindExpression(Dictionary<string, GType> visibleVariables)
    {
        var functionName = FunctionToken.Text;
        var parametersCount = Arguments.Count;
        var functionSymbol = Compiler.GetFunctionSymbol(k => k.FunctionName == functionName && k.Parameters.Count() == parametersCount);
        if (functionSymbol == null)
        {
            throw new Exception($"Function {functionName} with {parametersCount} parameters not found");
        }
        
        var functionExpression = Compiler.GetFunctionDefinition(functionSymbol);
        var parameters = functionSymbol.Parameters.ToList();

        for (int i = 0; i < parametersCount; i++)
        {
            var variableName = parameters[i];
            var argumentType = Arguments[i].Bind(visibleVariables);
            visibleVariables[variableName] = argumentType;
        }

        return functionExpression.Bind(visibleVariables);
    }

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var functionName = FunctionToken.Text;
        var parametersCount = Arguments.Count;
        var functionSymbol = Compiler.GetFunctionSymbol(k => k.FunctionName == functionName);

        var boundFunctionExpression = Compiler.GetFunctionDefinition(functionSymbol).GetBoundExpression(visibleVariables);

        List<BoundExpression> boundArguments = new List<BoundExpression>();
        foreach (var argument in Arguments)
            boundArguments.Add(argument.GetBoundExpression(visibleVariables));

        
        return new BoundFunctionCallExpression(boundArguments,boundFunctionExpression);
    }
}
