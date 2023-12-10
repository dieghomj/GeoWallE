using System.Linq.Expressions;

public class BoundSequenceLiteralExpression : BoundExpression
{
    public BoundSequenceLiteralExpression(List<BoundExpression> boundElements)
    {
        BoundElements = boundElements;
        Start = boundElements.FirstOrDefault()!;
        End = null;
    }

    public BoundSequenceLiteralExpression(BoundExpression start, BoundExpression? end = null)
    {
        Start = start;
        End = end;
        BoundElements = null;
    }

    public override GType Type => Start.Type;

    public BoundExpression Start { get; }
    public BoundExpression? End { get; }
    public List<BoundExpression>? BoundElements { get; }

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        if (BoundElements is null)
        {
            int count = -1;
            int start = (int)Start.Evaluate(visibleVariables).GetValue();
            int? end = null;

            if (End is not null)
            {
                end = (int)End.Evaluate(visibleVariables).GetValue();
                count = (int)end - start + 1;
            }

            return new Sequence<Number>(GObjectFacts.GetRangeSequence(start, end), count);
        }
        else
        {
            List<GObject> elements = new List<GObject>();
            foreach (BoundExpression boundelement in BoundElements)
                elements.Add(boundelement.Evaluate(visibleVariables));

            return new Sequence<GObject>(elements, elements.Count);
        }
    }
}
