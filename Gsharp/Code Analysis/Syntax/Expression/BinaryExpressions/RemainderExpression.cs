public class RemainderExpression : BinaryExpression
{
    public RemainderExpression(Expression left, Expression right)
        : base(left, right) { }
    public override ExpressionKind Kind => ExpressionKind.RemainderExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.PercentToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundRemainderExpression(left, right, resultType);
        
    }
}
