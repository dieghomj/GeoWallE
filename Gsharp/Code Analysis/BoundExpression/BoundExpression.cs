public abstract class BoundExpression
{
    public abstract GType Type { get; }
    public abstract object Evaluate();
}
