using Gsharp;

public class BoundDrawStatement : BoundStatement
{
    public BoundDrawStatement(BoundExpression boundFigure, BoundExpression? boundMessage = null)
    {
        BoundFigure = boundFigure;
        BoundMessage = boundMessage;
    }

    public BoundExpression BoundFigure { get; }
    public BoundExpression? BoundMessage { get; }

    public override void EvaluateStatement(Dictionary<string, GObject> visibleVariables)
    {
        string message = "";
        if (BoundMessage is not null)
            message = (string)BoundMessage.Evaluate(visibleVariables).GetValue();

        Compiler.AddFigure((Figure)BoundFigure.Evaluate(visibleVariables), message);
    }
}
