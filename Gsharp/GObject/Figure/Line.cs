public class Line : Figure
{
    //y = mx+b
    public Line() 
    { 
        StartPoint = (Random.Shared.Next(100,200),Random.Shared.Next(100,200));
        EndPoint =  (-Random.Shared.Next(0,100),-Random.Shared.Next(0,100));
    }

    public override GFigureKind Kind => GFigureKind.Line;
    private float Slope 
    {
        get
        {
            float deltaY = EndPoint.y - StartPoint.y;
            float deltaX = EndPoint.x - StartPoint.x;
            return deltaY/deltaX;
        }
    }

    private float Intercept
    {
        get
        {
            // y = mx + b , b = y - mx
            return StartPoint.y - Slope*StartPoint.x;
        }
    }
    public virtual (float x, float y) StartPoint { get; }
    public virtual (float x, float y) EndPoint { get; }
    public override (float x, float y) Position => (EndPoint.x - StartPoint.x/2,EndPoint.y-StartPoint.y/2);
    public override (float x, float y) GetPoint()
    {
        Random random = new Random();
        var x = random.Next(0,100);
        return (x,Slope*x+Intercept);
    }

    public override GType GetGType() => GType.Line;

    public override object GetValue()
    {
        throw new NotImplementedException();
    }
}
