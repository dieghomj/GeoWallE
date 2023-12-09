
public class BoundFunctionCallExpression : BoundExpression
{
    public BoundFunctionCallExpression(IEnumerable<string> parameters, List<BoundExpression> boundArguments, BoundExpression boundFunctionExpression)
    {
        Parameters = parameters;
        BoundArguments = boundArguments;
        BoundFunctionExpression = boundFunctionExpression;
    }

    public override GType Type => throw new NotImplementedException();

    public List<BoundExpression> BoundArguments { get; }
    public BoundExpression BoundFunctionExpression { get; }
    public IEnumerable<string> Parameters { get; }

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        throw new NotImplementedException();
    }
}