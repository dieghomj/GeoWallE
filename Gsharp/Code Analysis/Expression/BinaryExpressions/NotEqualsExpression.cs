public class NotEqualsExpression : BinaryExpression
{
    public NotEqualsExpression(Expression left, Expression right)
        : base(left, right) { }

    public override SyntaxKind Kind => throw new NotImplementedException();

    protected override GType Bind(Dictionary<VariableSymbol, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}