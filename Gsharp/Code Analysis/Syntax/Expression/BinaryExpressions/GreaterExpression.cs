
public class GreaterExpression : BinaryExpression
{
    public GreaterExpression(Expression left, Expression right)
        : base(left, right) { }

    public override SyntaxKind OperatorKind => SyntaxKind.GreaterToken;

    public override ExpressionKind Kind => throw new NotImplementedException();

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = ResultType;
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundGreaterExpression(left, right, resultType);
    }
}
