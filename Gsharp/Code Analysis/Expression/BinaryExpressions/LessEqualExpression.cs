public class LessEqualExpression : BinaryExpression
{
    public LessEqualExpression(Expression left, Expression right)
        : base(left, right) { }

    public override SyntaxKind Kind => SyntaxKind.LessEqualExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.LessEqualToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundLessEqualExpression(left, right, resultType);
        
    }
}
