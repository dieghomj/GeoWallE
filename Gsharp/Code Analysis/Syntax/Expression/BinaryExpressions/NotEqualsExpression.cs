public class NotEqualsExpression : BinaryExpression
{
    public NotEqualsExpression(Expression left, Expression right)
        : base(left, right) { }
    public override ExpressionKind Kind => ExpressionKind.NotEqualExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.BangEqualToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundNotEqualExpression(left, right, resultType);
        
    }
}
