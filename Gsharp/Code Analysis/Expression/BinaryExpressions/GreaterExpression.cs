
public class GreaterExpression : BinaryExpression
{
    public GreaterExpression(Expression left, Expression right)
        : base(left, right) { }

    public override SyntaxKind OperatorKind => SyntaxKind.GreaterToken;

    public override SyntaxKind Kind => throw new NotImplementedException();

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundGreaterExpression(left, right, resultType);
    }
}

public class BoundGreaterExpression : BoundBinaryExpression
{
    public BoundGreaterExpression(BoundExpression left, BoundExpression right, GType resultType) 
        : base(left, right, resultType) { }

    public override SyntaxKind OperatorKind => SyntaxKind.GreaterToken;
}