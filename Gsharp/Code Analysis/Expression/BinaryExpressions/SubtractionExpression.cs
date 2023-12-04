public class SubtractionExpression : BinaryExpression
{
    public SubtractionExpression(Expression left, Expression right)
        : base(left, right) { }
    public override SyntaxKind Kind => SyntaxKind.SubtractionExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.MinusToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundSubtractionExpression(left, right, resultType);
        
    }
}

public class BoundSubtractionExpression : BoundBinaryExpression
{
    public BoundSubtractionExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override SyntaxKind OperatorKind => SyntaxKind.MinusToken;
}