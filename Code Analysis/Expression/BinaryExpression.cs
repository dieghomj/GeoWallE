public class BinaryExpression : Expression
{
    public BinaryExpression(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }

    public Expression Left { get; }
    public Expression Right { get; }
    public override SyntaxKind Kind => SyntaxKind.BinaryExpression;

    public override GType Bind(Dictionary<VariableSymbol, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }

    public override GObject Evaluate(Dictionary<VariableSymbol, GObject> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
