public class DivisionExpression : BinaryExpression
{
    public DivisionExpression(Expression left, Expression right)
        : base(left, right) { }
    public override SyntaxKind OperatorKind => SyntaxKind.DivToken;
    public override ExpressionKind Kind => ExpressionKind.DivisionExpression;
    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = ResultType;
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundDivisionExpression(left,right,resultType);
    }
}

