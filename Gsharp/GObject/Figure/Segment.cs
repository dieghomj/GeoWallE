using System.ComponentModel.DataAnnotations;

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

    public override bool Contains(Point p)
    {
        if (Math.Abs(Slope * p.Position.x + Intercept - p.Position.y) < 1e-3)
        {
            float s = Math.Min(StartPoint.x, EndPoint.x);
            float e = Math.Max(StartPoint.x, EndPoint.x);
            if (s <= p.Position.x && p.Position.x <= e)
                return true;
        }
        return false;
    }

    public override GType GetGType() => GType.Segment;

    public override object GetValue()
    {
        throw new NotImplementedException();
    }
}
