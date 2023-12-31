using System.Data.Common;
using System.Threading.Tasks.Dataflow;
using Gsharp;

public class Arc : Circle
{
    public Arc() { }

    public Arc(Point center, Point p1, Point p2, Measure radius)
    {
        Position = (center.Position.x, center.Position.y);
        Radius = (float)radius.GetValue();
        var deltaYP1 = p1.Position.y - Position.y;
        var deltaXP1 = p1.Position.x - Position.x;
        var deltaXP2 = p2.Position.x - Position.x;
        var deltaYP2 = p2.Position.y - Position.y;
        var hP1 = Math.Sqrt(deltaXP1 * deltaXP1 + deltaYP1 * deltaYP1);
        var hP2 = Math.Sqrt(deltaXP2 * deltaXP2 + deltaYP2 * deltaYP2);

        StartAngle = (float)Math.Acos(Math.Abs(deltaXP1) / hP1);
        EndAngle = (float)Math.Acos(Math.Abs(deltaXP2) / hP2);

        if (deltaXP1 < 0)
        {
            if (deltaYP1 < 0)
                StartAngle += (float)Math.PI;
            else
                StartAngle = (float)Math.PI - StartAngle;
        }
        else
        {
            if (deltaYP1 < 0)
                StartAngle = (float)Math.PI * 2 - StartAngle;
        }

        if (deltaXP2 < 0)
        {
            if (deltaYP2 < 0)
                EndAngle += (float)Math.PI;
            else
                EndAngle = (float)Math.PI - EndAngle;
        }
        else
        {
            if (deltaYP2 < 0)
                EndAngle = (float)Math.PI * 2 - EndAngle;
        }
    }

    public override GFigureKind Kind => GFigureKind.Arc;

    public float StartAngle { get; }
    public float EndAngle { get; }
    public override (float x, float y) Position { get; }

    public override bool Contains(Point p)
    {
        double dist = Math.Sqrt(
            (p.Position.x - Position.x) * (p.Position.x - Position.x)
                + (p.Position.y - Position.y) * (p.Position.y - Position.y)
        );
        
        if (Math.Abs(dist - Radius) < 1e-3)
        {
            var deltaY = p.Position.y - Position.y;
            var deltaX = p.Position.x - Position.x;
            var h = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

            float angle = (float)Math.Acos(Math.Abs(deltaX) / h);

            if (deltaX < 0)
            {
                if (deltaY < 0)
                    angle += (float)Math.PI;
                else
                    angle = (float)Math.PI - angle;
            }
            else
            {
                if (deltaY < 0)
                    angle = (float)Math.PI * 2 - angle;
            }
            if (StartAngle < angle && angle < EndAngle)
                return true;
        }
        return false;
    }

    public override GType GetGType()
    {
        throw new NotImplementedException();
    }

    public override (float x, float y) GetPoint()
    {
        throw new NotImplementedException();
    }

    public override object GetValue()
    {
        throw new NotImplementedException();
    }
}
