public class BoundFunctionCallExpression : BoundExpression
{
    public BoundFunctionCallExpression(List<BoundExpression> boundArguments, BoundExpression boundFunctionExpression)
    {
        BoundArguments = boundArguments;
        BoundFunctionExpression = boundFunctionExpression;
    }

    public override GType Type => throw new NotImplementedException();

    public List<BoundExpression> BoundArguments { get; }
    public BoundExpression BoundFunctionExpression { get; }

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        throw new NotImplementedException();
    }
}