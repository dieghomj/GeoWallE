public class Arc : Figure
{
    public Arc() { }

    public Arc(Point center, Point p1, Point p2, Measure radius)
    {
        Position = (center.Position.x, center.Position.y);
        Radius = (float)radius.GetValue();
        var deltaYP1 = p1.Position.y - Position.y;
        var deltaXP1 = p1.Position.x - Position.x;
        var deltaXP2 = p2.Position.x - Position.x;
        var deltaYP2 = p2.Position.y - Position.y;
        var hP1 = Math.Sqrt(deltaXP1 * deltaXP1 + deltaYP1 * deltaYP1);
        var hP2 = Math.Sqrt(deltaXP2 * deltaXP2 + deltaYP2 * deltaYP2);
        StartAngle = (float)Math.Acos(deltaXP1/hP1);
        EndAngle = (float)Math.Acos(deltaXP2/hP2);
    }

    public override GFigureKind Kind => GFigureKind.Arc;

    public float Radius { get; }
    public float StartAngle { get;}
    public float EndAngle { get; }
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
