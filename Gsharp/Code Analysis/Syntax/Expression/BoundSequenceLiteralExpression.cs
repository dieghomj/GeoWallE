public class BoundSequenceLiteralExpression : BoundExpression
{
    public BoundSequenceLiteralExpression(List<BoundExpression> boundElements)
    {
        BoundElements = boundElements;
    }

    public BoundSequenceLiteralExpression(BoundExpression start, BoundExpression? end = null)
    {
        Start = start;
        End = end;
    }

    public override GType Type => Start.Type;

    public BoundExpression Start { get; }
    public BoundExpression End { get; }
    public List<BoundExpression> BoundElements { get; }

    public override object Evaluate()
    {
        throw new NotImplementedException();
    }
}