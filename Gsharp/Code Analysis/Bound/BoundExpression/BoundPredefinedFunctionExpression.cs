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
    public GType ResultType => Function.ResultType;

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        List<GObject> arguments = new List<GObject>();
        foreach (var argument in Arguments)
            arguments.Add(argument.Evaluate(visibleVariables));

        return Function.Evaluate(arguments.ToArray());
    }
}
