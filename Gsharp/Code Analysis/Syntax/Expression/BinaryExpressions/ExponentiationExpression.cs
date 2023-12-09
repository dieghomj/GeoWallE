
public class ExponentiationExpression : BinaryExpression
{
    public ExponentiationExpression(Expression left, Expression right)
        : base(left, right) { }
    public override ExpressionKind Kind => ExpressionKind.ExponentiationExpression;
    public override SyntaxKind OperatorKind => SyntaxKind.CircumflexToken;
    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = ResultType;
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundExponentiationExpression(left,right,resultType);
    }
}
