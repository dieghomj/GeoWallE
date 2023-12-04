using GInterfaces;

public class Point : Figure, IDrawable
{
    public override GType GetGType()
    {
        throw new NotImplementedException();
    }

    public override object GetValue()
    {
        throw new NotImplementedException();
    }

    public void Draw(Point point) => PanelDraw.AddFigure(this);
}
