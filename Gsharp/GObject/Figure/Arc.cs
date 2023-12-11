public class Arc : Figure
{
    public Arc() { }

    public Arc(Point center, Point p1, Point p2, Measure radius)
    {
        Position = (center.Position.x, center.Position.y);
        Radius = (float)radius.GetValue();
        
    }

    public override GFigureKind Kind => throw new NotImplementedException();

    public float Radius { get; set; }
    public float StartAngle { get; set; }
    public float EndAngle { get; set; }
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
