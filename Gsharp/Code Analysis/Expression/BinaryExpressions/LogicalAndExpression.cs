public class LogicalAndExpression : BinaryExpression
{
    public LogicalAndExpression(Expression left, Expression right)
        : base(left, right) { }
    public override ExpressionKind Kind => ExpressionKind.LogicalAndExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.AmpersandToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundLogicalAndExpression(left, right, resultType);
        
    }
}
