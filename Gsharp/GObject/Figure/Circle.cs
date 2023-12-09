public class Circle : Figure
{
    public Circle() { }

    public override GFigureKind Kind => GFigureKind.Circle;

    public float Radius { get; set; }
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
