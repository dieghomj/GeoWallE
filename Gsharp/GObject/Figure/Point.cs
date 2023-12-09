public class Point : Figure
{
    public Point()
    {
        Position = (Random.Shared.Next(0,100),Random.Shared.Next(0,100));
    }

    public Point(float x, float y)
    {
        Position = (x, y);
    }

    public override GFigureKind Kind => GFigureKind.Point;

    public override (float x, float y) Position { get; }

    public override GType GetGType()
    {
        throw new NotImplementedException();
    }

    public override object GetValue()
    {
        throw new NotImplementedException();
    }
}
