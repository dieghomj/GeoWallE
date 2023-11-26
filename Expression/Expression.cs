public abstract class Expression
{
    public abstract Func<object> Evaluate { get; }
    public abstract Func<Type> Bind { get; }
    public abstract Type Type { get; }
    public abstract SyntaxKind Kind { get; }
}
