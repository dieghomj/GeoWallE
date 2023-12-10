public class Arc : Figure
{
    public Arc() { }

    public override GFigureKind Kind => throw new NotImplementedException();

    public float Radius { get; set; }
    public float StartAngle { get; set; }
    public float EndAngle { get; set; }
    public override (float x, float y) Position { get => throw new NotImplementedException();}

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
