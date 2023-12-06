
public class GreaterExpression : BinaryExpression
{
    public GreaterExpression(Expression left, Expression right)
        : base(left, right) { }

    public override SyntaxKind OperatorKind => SyntaxKind.GreaterToken;

    public override ExpressionKind Kind => throw new NotImplementedException();

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundGreaterExpression(left, right, resultType);
    }
}
