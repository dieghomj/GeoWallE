public class BoundDrawStatement : BoundStatement
{
    public BoundDrawStatement(BoundExpression boundFigure)
    {
        BoundFigure = boundFigure;
    }

    public BoundDrawStatement(BoundExpression boundFigure, BoundExpression boundMessage) : this(boundFigure)
    {
        BoundMessage = boundMessage;
    }

    public BoundExpression BoundFigure { get; }
    public BoundExpression BoundMessage { get; }

    public override void EvaluateStatement()
    {
        throw new NotImplementedException();
    }
}