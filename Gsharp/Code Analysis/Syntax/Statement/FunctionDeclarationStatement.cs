using Gsharp;

public class FunctionDeclarationStatement : Statement
{
    public FunctionDeclarationStatement(
        SyntaxToken functionToken,
        List<SyntaxToken> parameters,
        Expression functionExpression
    )
    {
        FunctionToken = functionToken;
        Parameters = parameters;
        FunctionExpression = functionExpression;
    }

    private SyntaxToken FunctionToken { get; }
    private List<SyntaxToken> Parameters { get; }
    private Expression FunctionExpression { get; }

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        var functionName = FunctionToken.Text;
        if(Compiler.GetFunctionSymbol(k => k.FunctionName == functionName) != null)
        {
            throw new Exception($"! SEMANTIC ERROR : Function {functionName} is already defined");
        }

        foreach (var parameter in Parameters)
        {
            var variableName = parameter.Text;
            if(visibleVariables.Keys.FirstOrDefault(k => k == variableName) != null)
            {
                throw new Exception("! SEMANTIC ERROR : Cant use a constant already defined as a parameter");
            }
            var symbol = new VariableSymbol(variableName,GType.Undefined);
            visibleVariables.Add(variableName,symbol.Type);
        }
        FunctionExpression.Bind(visibleVariables);
    }
    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        List<string> parameters = new List<string>();
        var boundExpression = FunctionExpression.GetBoundExpression(visibleVariables);
        var functionName = FunctionToken.Text;
        foreach (var parameter in Parameters)
        {
            parameters.Add(parameter.Text);
        }
        var functionSymbol = new FunctionSymbol(functionName, parameters);
        Compiler.AddFunctionDefinition(functionSymbol,FunctionExpression);
        return new BoundFunctionDeclarationStatement(functionSymbol,boundExpression);
    }


}
