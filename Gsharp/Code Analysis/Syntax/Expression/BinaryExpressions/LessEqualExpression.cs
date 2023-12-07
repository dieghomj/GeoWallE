public class LessEqualExpression : BinaryExpression
{
    public LessEqualExpression(Expression left, Expression right)
        : base(left, right) { }

    public override ExpressionKind Kind => ExpressionKind.LessEqualExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.LessEqualToken;
    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = ResultType;
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundLessEqualExpression(left, right, resultType);
        
    }
}
