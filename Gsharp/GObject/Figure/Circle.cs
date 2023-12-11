public class Circle : Figure
{
    public Circle()
    {
        Position = (Random.Shared.Next(0, 100), Random.Shared.Next(0, 100));
        Radius = Random.Shared.Next(0, 100);
    }

    public Circle(float x, float y, float radius)
    {
        Position = (x, y);
        Radius = radius;
    }

    public Circle(Point a, Measure radius)
        : this(a.Position.x, a.Position.y, (float)radius.GetValue()) { }

    public override GFigureKind Kind => GFigureKind.Circle;

    public float Radius { get; set; }
    public override (float x, float y) Position { get; }

    public override GType GetGType()
    {
        throw new NotImplementedException();
    }

    public override (float x, float y) GetPoint()
    {
        throw new NotImplementedException();
    }

    public override object GetValue()
    {
        throw new NotImplementedException();
    }
}
