public class Point : Figure
{
    public override GFigureKind Kind => GFigureKind.Point;

    public override GType GetGType()
    {
        throw new NotImplementedException();
    }

    public override object GetValue()
    {
        throw new NotImplementedException();
    }
}
