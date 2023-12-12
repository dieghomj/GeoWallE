using System.Security.Cryptography.X509Certificates;

public class Point : Figure
{
    public Point()
    {
        Position = (Random.Shared.Next(0, 1000), Random.Shared.Next(0, 1000));
    }

    public Point(float x, float y)
    {
        Position = (x, y);
    }

    public Point((float x, float y) position)
    {
        Position = position;
    }

    public override GFigureKind Kind => GFigureKind.Point;

    public override (float x, float y) Position { get; }

    public override GType GetGType()
    {
        throw new NotImplementedException();
    }

    public override (float x, float y) GetPoint() => Position;

    public override object GetValue()
    {
        throw new NotImplementedException();
    }

    public override bool Contains(Point p)
    {
        if (
            Math.Abs(p.Position.x - Position.x) < 1e-3 && Math.Abs(p.Position.y - Position.y) < 1e-3
        )
            return true;
        return false;
    }
}
