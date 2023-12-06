
public class AdditionExpression : BinaryExpression
{
    public AdditionExpression(Expression left, Expression right)
        : base(left, right) { }

    public override ExpressionKind Kind => ExpressionKind.AdditionExpression;

    public override SyntaxKind OperatorKind => SyntaxKind.PlusToken;

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        var resultType = Bind(visibleVariables);
        var leftExpression = Left.GetBoundExpression(visibleVariables);
        var rightExpression = Right.GetBoundExpression(visibleVariables);
        return new BoundAdditionExpression(leftExpression,rightExpression,resultType);
    }

}
