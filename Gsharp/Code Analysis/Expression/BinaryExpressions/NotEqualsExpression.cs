public class NotEqualsExpression : BinaryExpression
{
    public NotEqualsExpression(Expression left, Expression right)
        : base(left, right) { }
    public override SyntaxKind Kind => SyntaxKind.NotEqualExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.BangEqualToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundNotEqualExpression(left, right, resultType);
        
    }
}

public class BoundNotEqualExpression : BoundBinaryExpression
{
    public BoundNotEqualExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override SyntaxKind OperatorKind => SyntaxKind.BangEqualToken;
}
