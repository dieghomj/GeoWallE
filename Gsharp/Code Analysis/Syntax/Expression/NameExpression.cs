public class NameExpression : Expression
{
    private GType Type;
    public NameExpression(SyntaxToken identifierToken)
    {
        IdentifierToken = identifierToken;
    }

    public override ExpressionKind Kind => ExpressionKind.NameExpression;

    public SyntaxToken IdentifierToken { get; }

    protected override GType BindExpression(Dictionary<string, GType> visibleVariables)
    {
        var variable = visibleVariables.Keys.FirstOrDefault(k => k == IdentifierToken.Text);
        if(variable == null)
        {
            System.Console.WriteLine($"!SEMANTIC ERROR: Constant {variable} doesn't exist");
            return GType.Undefined;
        }   
        else
        {
            Type = visibleVariables[variable];
            return Type;
        } 
    }
    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        if(Type == GType.Undefined)
            throw new Exception($"Variable {IdentifierToken.Text} doesn't exist");
        else return new BoundVariableExpression(new VariableSymbol(IdentifierToken.Text,Type));
    }
}
