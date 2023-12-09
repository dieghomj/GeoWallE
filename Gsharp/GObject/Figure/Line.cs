public class Line : Figure
{
    public Line() 
    { 
        StartPoint = (Random.Shared.Next(100,200),Random.Shared.Next(100,200));
        EndPoint =  (-Random.Shared.Next(0,100),-Random.Shared.Next(0,100));
    }

    public override GFigureKind Kind => GFigureKind.Line;

    public virtual (float x, float y) StartPoint { get; }
    public virtual (float x, float y) EndPoint { get; }
    public override (float x, float y) Position { get => throw new NotImplementedException(); }

    public override GType GetGType()
    {
        throw new NotImplementedException();
    }

    public override object GetValue()
    {
        throw new NotImplementedException();
    }
}
