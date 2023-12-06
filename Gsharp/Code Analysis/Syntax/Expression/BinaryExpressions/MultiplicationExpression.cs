public class MultiplicationExpression : BinaryExpression
{
    public MultiplicationExpression(Expression left, Expression right)
        : base(left, right) { }
    public override ExpressionKind Kind => ExpressionKind.MultiplicationExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.StarToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundMultiplicationExpression(left, right, resultType);
        
    }
}
