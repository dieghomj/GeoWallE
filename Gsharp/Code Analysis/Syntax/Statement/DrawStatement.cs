public class DrawStatement : Statement
{

    public DrawStatement(Expression figure)
    {
        Figure = figure;
    }

    public DrawStatement(Expression figure, Expression message) : this(figure)
    {
        Message = message;
    }

    public Expression Figure { get; }
    public Expression? Message { get; }

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        if(!Figure.Bind(visibleVariables).IsFigure())
        {
            throw new Exception("! SEMMANTIC ERROR : Expected figure is not a figure");
        }
        if (Message is not null)
        {
            var messageType = Message.Bind(visibleVariables);
            if (messageType != GType.String)
            {
                throw new Exception("! SEMANTIC ERROR: Expected message of type <string>");
            }
        }
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        
        var boundFigure = Figure.GetBoundExpression(visibleVariables);

        if (Message is not null)
        {
            var boundMessage = Message.GetBoundExpression(visibleVariables);
            return new BoundDrawStatement(boundFigure, boundMessage);
        }

        return new BoundDrawStatement(boundFigure);
    }
}
