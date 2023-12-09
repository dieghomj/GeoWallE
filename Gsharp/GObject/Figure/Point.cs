public class Point : Figure
{
    public override GFigureKind Kind => GFigureKind.Point;

    public override (float x, float y) Position => (5,5);

    public override GType GetGType()
    {
        throw new NotImplementedException();
    }

    public override object GetValue()
    {
        throw new NotImplementedException();
    }
}
