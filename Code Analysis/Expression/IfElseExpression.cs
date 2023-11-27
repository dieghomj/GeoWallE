public class IfElseExpression : Expression
{
    public IfElseExpression(
        Expression condition,
        Expression trueExpression,
        Expression falseExpression
    )
    {
        Condition = condition;
        TrueExpression = trueExpression;
        FalseExpression = falseExpression;
    }

    public Expression Condition { get; }
    public Expression TrueExpression { get; }
    public Expression FalseExpression { get; }

    public override SyntaxKind Kind => SyntaxKind.IfElseExpression;

    protected override GType Bind(Dictionary<VariableSymbol, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
