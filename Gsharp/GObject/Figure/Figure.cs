using Gsharp;

public abstract class Figure : GObject
{
    public abstract GFigureKind Kind { get; }

    public override bool IsTrue() => true;
}
