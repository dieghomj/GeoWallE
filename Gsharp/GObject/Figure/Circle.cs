public class Circle : Figure
{
    public Circle()
    {
        Position = (Random.Shared.Next(0, 1000), Random.Shared.Next(0, 1000));
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
        Random random = new Random();
        var x = random.Next(0, 1000);
        var y = MathF.Sqrt(Radius * Radius - ((x - Position.x) * (x - Position.x))) + Position.y;
        return (x, y);
    }

    public override object GetValue()
    {
        throw new NotImplementedException();
    }

    public override bool Contain(Point p)
    {
        double dist = Math.Sqrt(
            (p.Position.x - Position.x) * (p.Position.x - Position.x)
                + (p.Position.y - Position.y) * (p.Position.y - Position.y)
        );
        // if (Math.Abs(dist - Radius) < 1e-5)
            return true;
        // return false;
    }
}
