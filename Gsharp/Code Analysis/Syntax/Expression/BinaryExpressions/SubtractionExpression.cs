public class SubtractionExpression : BinaryExpression
{
    public SubtractionExpression(Expression left, Expression right)
        : base(left, right) { }
    public override ExpressionKind Kind => ExpressionKind.SubtractionExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.MinusToken;

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = ResultType;
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundSubtractionExpression(left, right, resultType);
        
    }
}
