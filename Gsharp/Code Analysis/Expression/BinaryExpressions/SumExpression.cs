public class SumExpression : BinaryExpression
{
    public SumExpression(Expression left, Expression right)
        : base(left, right) { }

    public override SyntaxKind Kind => SyntaxKind.SumExpression;

    protected override GType Bind(Dictionary<VariableSymbol, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
