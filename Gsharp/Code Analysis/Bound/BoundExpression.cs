public abstract class BoundExpression : BoundStatement
{
    public abstract GType Type { get; }
    public abstract GObject Evaluate();

    public override void EvaluateStatement() => Evaluate();
}
