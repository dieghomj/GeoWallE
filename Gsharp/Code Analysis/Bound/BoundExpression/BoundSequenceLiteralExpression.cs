using System.Linq.Expressions;

public class BoundSequenceLiteralExpression : BoundExpression
{
    public BoundSequenceLiteralExpression(List<BoundExpression> boundElements)
    {
        BoundElements = boundElements;
        Start = boundElements.FirstOrDefault()!;
        End = boundElements.LastOrDefault()!;
    }

    public BoundSequenceLiteralExpression(BoundExpression start, BoundExpression? end = null)
    {
        Start = start;
        End = end;
        BoundElements = null;
    }

    public GType SequenceType => Start.Type;
    public override GType Type => GType.Sequence;

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
            foreach (BoundExpression boundElement in BoundElements)
                elements.Add(boundElement.Evaluate(visibleVariables));

            return new Sequence<GObject>(elements, elements.Count);
        }
    }
}
