public class Line : Figure
{
    //y = mx+b
    public Line()
    {
        StartPoint = (Random.Shared.Next(1000, 2000), Random.Shared.Next(1000, 2000));
        EndPoint = (-Random.Shared.Next(0, 1000), -Random.Shared.Next(0, 1000));
    }

    public Line(Point a, Point b)
    {
        StartPoint = (a.Position.x, a.Position.y);
        EndPoint = (b.Position.x, b.Position.y);
        StartPoint = (-1000, this.Slope * -1000 + Intercept);
        EndPoint = (1000, this.Slope * 1000 + Intercept);
    }

    public override GFigureKind Kind => GFigureKind.Line;
    public float Slope
    {
        get
        {
            float deltaY = EndPoint.y - StartPoint.y;
            float deltaX = EndPoint.x - StartPoint.x;
            return deltaY / deltaX;
        }
    }

    public float Intercept
    {
        get
        {
            // y = mx + b , b = y - mx
            return StartPoint.y - Slope * StartPoint.x;
        }
    }
    public virtual (float x, float y) StartPoint { get; }
    public virtual (float x, float y) EndPoint { get; }
    public override (float x, float y) Position =>
        (EndPoint.x - StartPoint.x / 2, EndPoint.y - StartPoint.y / 2);

    public override (float x, float y) GetPoint()
    {
        Random random = new Random();
        var x = random.Next(0, 1000);
        return (x, Slope * x + Intercept);
    }

    public override GType GetGType() => GType.Line;

    public override object GetValue()
    {
        throw new NotImplementedException();
    }

    public override bool Contains(Point p)
    {
        if (Math.Abs(Slope * p.Position.x + Intercept - p.Position.y) < 1e-3)
        {
            float s = Math.Min(StartPoint.x, EndPoint.x);
            float e = Math.Max(StartPoint.x, EndPoint.x);
            if (s <= p.Position.x && p.Position.x <= e)
                return true;
        }
        return false;
    }
}
