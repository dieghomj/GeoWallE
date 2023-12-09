public class Ray : Line
{
    public Ray() 
    { 
        StartPoint = (Random.Shared.Next(0,100),Random.Shared.Next(0,100));
        EndPoint = (Random.Shared.Next(100,200),Random.Shared.Next(100,200));
    }

    public override GFigureKind Kind => GFigureKind.Ray;

    public override (float x, float y) StartPoint { get; }
    public override (float x, float y) EndPoint { get; }
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
