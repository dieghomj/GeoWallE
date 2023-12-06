public class NameExpression : Expression
{
    public NameExpression(SyntaxToken identifierToken)
    {
        IdentifierToken = identifierToken;
    }

    public override ExpressionKind Kind => ExpressionKind.NameExpression;

    public SyntaxToken IdentifierToken { get; }

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var type = Bind(visibleVariables);
        if(type == GType.Undefined)
            throw new Exception($"Variable {IdentifierToken.Text} doesn't exist");
        else return new BoundVariableExpression(new VariableSymbol(IdentifierToken.Text,type));
    }

    public override GType Bind(Dictionary<string, GType> visibleVariables)
    {
        var variable = visibleVariables.Keys.FirstOrDefault(k => k == IdentifierToken.Text);
        if(variable == null)
        {
            System.Console.WriteLine($"!SEMANTIC ERROR: Variable {variable} doesn't exist");
            return GType.Undefined;
        }
        else return visibleVariables[variable];
    }
}
