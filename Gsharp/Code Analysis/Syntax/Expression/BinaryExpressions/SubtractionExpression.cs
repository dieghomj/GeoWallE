public class SubtractionExpression : BinaryExpression
{
    public SubtractionExpression(Expression left, Expression right)
        : base(left, right) { }
    public override ExpressionKind Kind => ExpressionKind.SubtractionExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.MinusToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundSubtractionExpression(left, right, resultType);
        
    }
}
