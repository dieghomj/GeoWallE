public class LessExpression : BinaryExpression
{
    public LessExpression(Expression left, Expression right)
        : base(left, right) { }
    public override SyntaxKind Kind => SyntaxKind.LessExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.LessToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundLessExpression(left, right, resultType);
        
    }
}
