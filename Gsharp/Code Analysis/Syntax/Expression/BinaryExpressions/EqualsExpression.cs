
public class EqualsExpression : BinaryExpression
{
    public EqualsExpression(Expression left, Expression right)
        : base(left, right) { }
    public override SyntaxKind OperatorKind => SyntaxKind.EqualEqualToken;
    public override ExpressionKind Kind => ExpressionKind.EqualsExpression;
    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundEqualsExpression(left,right,resultType);
    }
    
}
