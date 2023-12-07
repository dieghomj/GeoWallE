public class RemainderExpression : BinaryExpression
{
    public RemainderExpression(Expression left, Expression right)
        : base(left, right) { }
    public override ExpressionKind Kind => ExpressionKind.RemainderExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.PercentToken;

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = ResultType;
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundRemainderExpression(left, right, resultType);
        
    }
}
