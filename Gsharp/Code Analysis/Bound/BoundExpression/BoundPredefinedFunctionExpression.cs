public class BoundPredefinedFunctionExpression : BoundExpression
{
    public BoundPredefinedFunctionExpression(string name, List<BoundExpression> arguments, BoundPredefinedFunction function)
    {
        Name = name;
        Arguments = arguments;
        Function = function;
    }

    public override GType Type => ResultType;

    public string Name { get; }
    public List<BoundExpression> Arguments { get; }
    public BoundPredefinedFunction Function { get; }
    public GType ResultType { get; }

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        List<object> arguments = new List<object>();
        foreach (var argument in Arguments)
            arguments.Add(argument.Evaluate(visibleVariables));

        return Function.Evaluate(arguments);
    }
}
