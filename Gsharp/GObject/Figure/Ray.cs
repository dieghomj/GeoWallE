public class Ray : Line
{
    public Ray()
    {
        StartPoint = (Random.Shared.Next(0, 1000), Random.Shared.Next(0, 1000));
        EndPoint = (Random.Shared.Next(1000, 2000), Random.Shared.Next(1000, 2000));
    }

    public Ray(Point a, Point b)
    {
        StartPoint = (a.Position.x, a.Position.y);
        EndPoint = (b.Position.x, b.Position.y);
        EndPoint = (1000, this.Slope * 1000 + Intercept);
    }

    public override GFigureKind Kind => GFigureKind.Ray;

    public override GType GetGType() => GType.Ray;

    public override (float x, float y) StartPoint { get; }
    public override (float x, float y) EndPoint { get; }
    public override (float x, float y) Position => StartPoint;
}
