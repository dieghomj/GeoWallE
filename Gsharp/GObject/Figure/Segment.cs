public class Segment : Figure
{
    public Segment() { }

    public override GFigureKind Kind => throw new NotImplementedException();

    public (float x, float y) StartPoint { get; set; }
    public (float x, float y) EndPoint { get; set; }
    public override (float x, float y) Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public override GType GetGType()
    {
        throw new NotImplementedException();
    }

    public override object GetValue()
    {
        throw new NotImplementedException();
    }
}
