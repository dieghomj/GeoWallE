using Gsharp;

public abstract class Figure : GObject
{
    public abstract GFigureKind Kind { get; }

    public void DrawFigure() => Compiler.AddFigure(this);
}
