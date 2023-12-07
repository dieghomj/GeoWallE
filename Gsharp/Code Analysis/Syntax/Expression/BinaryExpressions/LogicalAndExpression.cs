public class LogicalAndExpression : BinaryExpression
{
    public LogicalAndExpression(Expression left, Expression right)
        : base(left, right) { }
    public override ExpressionKind Kind => ExpressionKind.LogicalAndExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.AmpersandToken;

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = ResultType;
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundLogicalAndExpression(left, right, resultType);
        
    }
}
