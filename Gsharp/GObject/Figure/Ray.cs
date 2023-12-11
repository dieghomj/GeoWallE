public class Ray : Line
{
    public Ray() 
    { 
        StartPoint = (Random.Shared.Next(0,100),Random.Shared.Next(0,100));
        EndPoint = (Random.Shared.Next(100,200),Random.Shared.Next(100,200));
    }

    public Ray(Point a, Point b)
    {
        StartPoint = (a.Position.x, a.Position.y);
        EndPoint = (b.Position.x, b.Position.y);
    }

    public override GFigureKind Kind => GFigureKind.Ray;
    public override GType GetGType() => GType.Ray;
    public override (float x, float y) StartPoint { get; }
    public override (float x, float y) EndPoint { get; }
    public override (float x, float y) Position => StartPoint;
}
