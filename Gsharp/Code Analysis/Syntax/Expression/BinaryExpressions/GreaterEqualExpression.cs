public class GreaterEqualExpression : BinaryExpression
{
    public GreaterEqualExpression(Expression left, Expression right)
        : base(left, right) { }

    public override ExpressionKind Kind => ExpressionKind.GreaterEqualExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.GreaterEqualToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundGreaterEqualExpression(left, right, resultType);
        
    }
}
