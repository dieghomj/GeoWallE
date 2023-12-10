using Gsharp;

public abstract class Figure : GObject
{
    public abstract GFigureKind Kind { get; }
    public abstract (float x, float y) Position { get;}
    public abstract (float x, float y) GetPoint();
    public void DrawFigure() => Compiler.AddFigure(this,null);
    public override bool IsTrue() => true;

}
