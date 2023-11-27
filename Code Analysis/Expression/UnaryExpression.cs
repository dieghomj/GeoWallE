public abstract class UnaryExpression : Expression
{
    protected UnaryExpression(Expression operand)
    {
        Operand = operand;
    }

    public Expression Operand { get; }
    public override SyntaxKind Kind => SyntaxKind.UnaryExpression;
}
