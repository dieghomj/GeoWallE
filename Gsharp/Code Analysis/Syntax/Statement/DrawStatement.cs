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
        
        if(!figureOrSequence.IsFigure() && figureOrSequence != GType.Sequence)
        {
            throw new Exception($"! SEMMANTIC ERROR : Expected figure instead of {figureOrSequence}");
        }
        if(figureOrSequence == GType.Sequence && Figure is NameExpression identifier)
        {
            if(!identifier.SequenceType.IsFigure() && identifier.SequenceType != GType.Undefined)
                throw new Exception($"! SEMANTIC ERROR : Expected figure sequence instead of {identifier.SequenceType}");
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
        if (boundFigure is BoundVariableExpression variable)
        {
            return new BoundDrawStatement(variable, boundMessage);
        }
        if (boundFigure.Type is GType.Sequence && boundFigure is BoundSequenceLiteralExpression literal)
        {
            if (!literal.SequenceType.IsFigure())
            {
                throw new Exception($"! SEMANTIC ERROR : Expected figure sequence instead of {literal.SequenceType}");
            }
            return new BoundDrawStatement(literal.BoundElements, boundMessage);
        }
        return new BoundDrawStatement(boundFigure,boundMessage);
    }
}
