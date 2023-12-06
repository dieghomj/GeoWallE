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

    public override GType Bind(Dictionary<string, GType> visibleVariables)
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

    public override BoundExpression GetBoundExpression(Dictionary<string, GType> visibleVariables)
    {
        
        if( Bind(visibleVariables) == GType.Undefined)
        {
            throw new Exception();
        }
        
        var boundCondition = Condition.GetBoundExpression(visibleVariables);
        var boundTrueExpression = TrueExpression.GetBoundExpression(visibleVariables);
        var boundFalseExpression = FalseExpression.GetBoundExpression(visibleVariables);

        return new BoundIfElseExpression(boundCondition,boundTrueExpression,boundFalseExpression);
    }

}
