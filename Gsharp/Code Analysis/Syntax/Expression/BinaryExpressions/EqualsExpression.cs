
public class EqualsExpression : BinaryExpression
{
    public EqualsExpression(Expression left, Expression right)
        : base(left, right) { }
    public override SyntaxKind OperatorKind => SyntaxKind.EqualEqualToken;
    public override ExpressionKind Kind => ExpressionKind.EqualsExpression;
    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = ResultType;
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundEqualsExpression(left,right,resultType);
    }
    
}
