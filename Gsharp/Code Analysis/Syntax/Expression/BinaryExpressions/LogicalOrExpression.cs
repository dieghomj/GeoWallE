public class LogicalOrExpression : BinaryExpression
{
    public LogicalOrExpression(Expression left, Expression right)
        : base(left, right) { }
    public override ExpressionKind Kind => ExpressionKind.LogicalOrExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.BangToken;

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = ResultType;
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundLogicalOrExpression(left, right, resultType);
        
    }
}
