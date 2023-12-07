public abstract class BoundExpression : BoundStatement
{
    public abstract GType Type { get; }
    public abstract object Evaluate();
    public override void EvaluateStatement() { }

}
