public class LogicalOrExpression : BinaryExpression
{
    public LogicalOrExpression(Expression left, Expression right)
        : base(left, right) { }
    public override ExpressionKind Kind => ExpressionKind.LogicalOrExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.BangToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundLogicalOrExpression(left, right, resultType);
        
    }
}
