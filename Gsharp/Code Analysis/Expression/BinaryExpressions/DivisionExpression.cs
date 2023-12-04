public class DivisionExpression : BinaryExpression
{
    public DivisionExpression(Expression left, Expression right)
        : base(left, right) { }
    public override SyntaxKind OperatorKind => SyntaxKind.DivToken;
    public override SyntaxKind Kind => SyntaxKind.DivisionExpression;
    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundDivisionExpression(left,right,resultType);
    }
}

