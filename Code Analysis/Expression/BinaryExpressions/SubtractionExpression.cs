public class SubtractionExpression : BinaryExpression
{
    public SubtractionExpression(Expression left, Expression right)
        : base(left, right) { }

    public override SyntaxKind Kind => SyntaxKind.SubtractionExpression;
    protected override GType Bind(Dictionary<VariableSymbol, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
