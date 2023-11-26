public class UnaryExpression : Expression
{
    public UnaryExpression(Expression operand, Func<object> evaluate, Func<Type> bind)
    {
        Operand = operand;
        Evaluate = evaluate;
        Bind = bind;
    }

    public override Func<object> Evaluate { get; }
    public override Func<Type> Bind { get; }
    public Expression Operand;
    public override Type Type => Bind();

    public override SyntaxKind Kind => SyntaxKind.UnaryExpression;
}
