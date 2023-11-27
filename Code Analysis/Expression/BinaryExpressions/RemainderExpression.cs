public class RemainderExpression : BinaryExpression
{
    public RemainderExpression(Expression left, Expression right)
        : base(left, right) { }

    public override SyntaxKind Kind => throw new NotImplementedException();

    protected override GType Bind(Dictionary<VariableSymbol, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
