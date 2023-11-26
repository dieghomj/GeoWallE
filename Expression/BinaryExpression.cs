public class BinaryExpression : Expression
{
    public BinaryExpression(Expression left, Expression right, Func<object> evaluate, Func<Type> bind)
    {
        Left = left;
        Right = right;
        Evaluate = evaluate;
        Bind = bind;
    }

    public override Func<object> Evaluate {get; }
    public override Func<Type> Bind { get; }
    public Expression Left { get; }
    public Expression Right { get; }
    public override Type Type => Bind();
    public override SyntaxKind Kind => SyntaxKind.BinaryExpression;
}
