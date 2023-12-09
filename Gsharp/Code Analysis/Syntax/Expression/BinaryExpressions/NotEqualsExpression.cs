public class NotEqualsExpression : BinaryExpression
{
    public NotEqualsExpression(Expression left, Expression right)
        : base(left, right) { }
    public override ExpressionKind Kind => ExpressionKind.NotEqualExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.BangEqualToken;

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = ResultType;
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundNotEqualExpression(left, right, resultType);
        
    }
}
