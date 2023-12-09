public class GreaterEqualExpression : BinaryExpression
{
    public GreaterEqualExpression(Expression left, Expression right)
        : base(left, right) { }

    public override ExpressionKind Kind => ExpressionKind.GreaterEqualExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.GreaterEqualToken;

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = ResultType;
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundGreaterEqualExpression(left, right, resultType);
        
    }
}
