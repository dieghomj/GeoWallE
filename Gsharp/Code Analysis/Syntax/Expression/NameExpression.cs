public class NameExpression : Expression
{
    private GType Type;
    public NameExpression(SyntaxToken identifierToken)
    {
        IdentifierToken = identifierToken;
    }

    public override ExpressionKind Kind => ExpressionKind.NameExpression;

    public SyntaxToken IdentifierToken { get; }
    public bool IsSequence() => GType.Sequence == Type;
    public GType SequenceType => IsSequence() ? Binder.GetSequenceVariable(IdentifierToken.Text) : GType.Any;
    protected override GType BindExpression(Dictionary<string, GType> visibleVariables)
    {
        var variable = visibleVariables.Keys.FirstOrDefault(k => k == IdentifierToken.Text);
        if(variable == null)
        {
            throw new Exception($"!SEMANTIC ERROR: Constant {IdentifierToken.Text} doesn't exist");
        }   
        else
        {
            Type = visibleVariables[variable];
            return Type;
        } 
    }
    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        return new BoundVariableExpression(new VariableSymbol(IdentifierToken.Text,Type));
    }

}
