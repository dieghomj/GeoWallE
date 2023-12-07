public class MultiplicationExpression : BinaryExpression
{
    public MultiplicationExpression(Expression left, Expression right)
        : base(left, right) { }
    public override ExpressionKind Kind => ExpressionKind.MultiplicationExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.StarToken;

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = ResultType;
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundMultiplicationExpression(left, right, resultType);
        
    }
}
