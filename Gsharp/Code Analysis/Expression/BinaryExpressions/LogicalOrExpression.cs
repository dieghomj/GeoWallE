public class LogicalOrExpression : BinaryExpression
{
    public LogicalOrExpression(Expression left, Expression right)
        : base(left, right) { }
    public override SyntaxKind Kind => SyntaxKind.LogicalOrExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.PipeToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var left = Left.GetBoundExpression(visibleVariables);
        var right = Right.GetBoundExpression(visibleVariables);
        return new BoundLogicalOrExpression(left, right, resultType);
        
    }
}

public class BoundLogicalOrExpression : BoundBinaryExpression
{
    public BoundLogicalOrExpression(BoundExpression left, BoundExpression right, GType resultType) 
    : base(left, right, resultType) { }

    public override SyntaxKind OperatorKind => SyntaxKind.PipeToken;
}
