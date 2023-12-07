public class BoundVariableExpression : BoundExpression
{
    public BoundVariableExpression(VariableSymbol variable)
    {
        Variable = variable;
    }

    public override GType Type => Variable.Type;

    public VariableSymbol Variable { get; }

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        return visibleVariables[Variable.Name];
    }
}
