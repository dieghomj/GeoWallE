
public class ExponentiationExpression : BinaryExpression
{
    public ExponentiationExpression(Expression left, Expression right)
        : base(left, right) { }
    public override SyntaxKind Kind => SyntaxKind.ExponentiationExpression;
    public override SyntaxKind OperatorKind => SyntaxKind.CircumflexToken;
    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundExponentiationExpression(left,right,resultType);
    }
}
