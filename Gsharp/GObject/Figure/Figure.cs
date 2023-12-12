using Gsharp;

public abstract class Figure : GObject
{
    public abstract GFigureKind Kind { get; }
    public abstract (float x, float y) Position { get; }
    public abstract (float x, float y) GetPoint();
    public abstract bool Contain(Point p);

    public void DrawFigure() => Compiler.AddFigure(this, "");

    public override bool IsTrue() => true;
}
