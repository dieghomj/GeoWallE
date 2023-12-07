public class LessExpression : BinaryExpression
{
    public LessExpression(Expression left, Expression right)
        : base(left, right) { }
    public override ExpressionKind Kind => ExpressionKind.LessExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.LessToken;

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = ResultType;
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundLessExpression(left, right, resultType);

    }
}
