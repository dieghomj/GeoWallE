public abstract class BoundExpression : BoundStatement
{
    public abstract GType Type { get; }
    public abstract GObject Evaluate(Dictionary<string, GObject> visibleVariables);

    public override void EvaluateStatement(Dictionary<string, GObject> visibleVariables) =>
        Evaluate(visibleVariables);
}
