public class Circle : Figure
{
    public Circle() { }

    public override GFigureKind Kind => GFigureKind.Circle;

    public override GType GetGType()
    {
        throw new NotImplementedException();
    }

    public override object GetValue()
    {
        throw new NotImplementedException();
    }
}
