public abstract class BinaryExpression : Expression
{
    public BinaryExpression(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }

    public Expression Left { get; }
    public Expression Right { get; }
    public override SyntaxKind Kind => SyntaxKind.BinaryExpression;
}

