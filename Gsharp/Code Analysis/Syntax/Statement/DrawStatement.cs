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
        var figureOrSequence = Figure.Bind(visibleVariables);
        
        if(!figureOrSequence.IsFigure() && !figureOrSequence.IsFigureSequence())
        {
            throw new Exception($"! SEMMANTIC ERROR : Expected figure or figure sequence, instead of <{figureOrSequence}>");
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
        BoundExpression boundMessage;
        if(Message is not null)
        {
            boundMessage = Message.GetBoundExpression(visibleVariables);
        }
        else boundMessage = null;

        var boundFigure = Figure.GetBoundExpression(visibleVariables);
        return new BoundDrawStatement(boundFigure,boundMessage);
    }
}
