using System.Linq.Expressions;

public class IfElseExpression : Expression
{
    public IfElseExpression(
        Expression condition,
        Expression trueExpression,
        Expression falseExpression
    )
    {
        Condition = condition;
        TrueExpression = trueExpression;
        FalseExpression = falseExpression;
    }

    public Expression Condition { get; }
    public Expression TrueExpression { get; }
    public Expression FalseExpression { get; }

    public override ExpressionKind Kind => ExpressionKind.IfElseExpression;

    protected override GType BindExpression(Dictionary<string, GType> visibleVariables)
    {
        Condition.Bind(visibleVariables);
        var trueExpressionType = TrueExpression.Bind(visibleVariables);
        var falseExpressionType = FalseExpression.Bind(visibleVariables);

        if(trueExpressionType != falseExpressionType)
        {
            System.Console.WriteLine($"! SEMANTIC ERROR: <then> is of type {trueExpressionType} and <else> is of type {falseExpressionType}, must be the same");;
            return GType.Undefined;
        }

        return trueExpressionType;
    }

    protected override BoundExpression InstantiateBoundExpression(Dictionary<string, GType> visibleVariables)
    {   
        var boundCondition = Condition.GetBoundExpression(visibleVariables);
        var boundTrueExpression = TrueExpression.GetBoundExpression(visibleVariables);
        var boundFalseExpression = FalseExpression.GetBoundExpression(visibleVariables);

        return new BoundIfElseExpression(boundCondition,boundTrueExpression,boundFalseExpression);
    }

}
