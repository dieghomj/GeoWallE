using GInterfaces;

public abstract class Figure : GObject, IDrawable
{
    // public abstract void Draw();
    public void Draw() => PanelDraw.AddFigure(this);

    public abstract void DrawFigure();
}
