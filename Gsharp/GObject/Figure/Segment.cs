public class Segment : Line
{
    public Segment()
    {
        StartPoint = (Random.Shared.Next(0, 1000), Random.Shared.Next(0, 1000));
        EndPoint = (Random.Shared.Next(0, 1000), Random.Shared.Next(0, 1000));
    }

    public Segment(Point a, Point b)
    {
        StartPoint = (a.Position.x, a.Position.y);
        EndPoint = (b.Position.x, b.Position.y);
    }

    public override GFigureKind Kind => GFigureKind.Segment;

    public override (float x, float y) StartPoint { get; }
    public override (float x, float y) EndPoint { get; }
    public override (float x, float y) Position
    {
        get => throw new NotImplementedException();
    }

    public override GType GetGType()
    {
        throw new NotImplementedException();
    }

    public override object GetValue()
    {
        throw new NotImplementedException();
    }
}
