public class AdditionExpression : BinaryExpression
{
    public AdditionExpression(Expression left, Expression right)
        : base(left, right) { }

    public override SyntaxKind Kind => SyntaxKind.AdditionExpression;

    protected override GType Bind(Dictionary<VariableSymbol, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
