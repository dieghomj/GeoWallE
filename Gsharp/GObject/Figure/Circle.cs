public class Circle : Figure
{
    public Circle()
    {
        Position = (Random.Shared.Next(0,100),Random.Shared.Next(0,100));
        Radius = Random.Shared.Next(0,100);
    }

    public Circle(float x, float y, int radius)
    {
        Position = (x,y);
        Radius = radius;
    }

    public override GFigureKind Kind => GFigureKind.Circle;

    public float Radius { get; set; }
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
