using Gsharp;

public class BoundDrawStatement : BoundStatement
{
    public BoundDrawStatement(List<BoundExpression>? figures, BoundExpression? message)
    {
        Figures = figures;
        Message = message;
    }

    public BoundDrawStatement(BoundExpression figure, BoundExpression? message = null)
    {
        Figure = figure;
        Message = message;
    }

    public BoundExpression Figure { get; }
    public BoundExpression? Message { get; }
    public List<BoundExpression>? Figures { get; }

    public override void EvaluateStatement(Dictionary<string, GObject> visibleVariables)
    {
        string message = "";
        if (Message is not null)
            message = (string)Message.Evaluate(visibleVariables).GetValue();

        if(Figures is not null)
        {
            foreach (var figure in Figures)
                Compiler.AddFigure((Figure)figure.Evaluate(visibleVariables), message);
            return ;
        }
        
        if(Figure.Type == GType.Sequence)
        {
            dynamic sequence = Figure.Evaluate(visibleVariables);
            foreach (var figure in sequence) 
                Compiler.AddFigure((Figure)figure,message);
            return;
        }

        Compiler.AddFigure((Figure)Figure.Evaluate(visibleVariables), message);
    }
}
