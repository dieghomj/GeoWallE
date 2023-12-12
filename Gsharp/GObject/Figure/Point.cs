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

    public override bool Contain(Point p)
    {
        if(p.Position.x == Position.x && p.Position.y == Position.y)
            return true;
        return false;
    }
}
