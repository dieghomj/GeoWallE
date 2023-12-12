using System.Dynamic;

public static class IntersectFigures
{
    private static Sequence<Point> Contains(Sequence<Point> points, Figure a, Figure b)
    {
        List<Point> intersectPoints = new();
        foreach (Point point in points)
        {
            if (a.Contain(point) && b.Contain(point))
                intersectPoints.Add(point);
        }
        return new Sequence<Point>(intersectPoints, intersectPoints.Count);
    }

    public static Sequence<Point> Get(Point a, Figure b)
    {
        List<Point> points = new List<Point>() { a };
        return Contains(new Sequence<Point>(points), a, b);
    }

    public static Sequence<Point> Get(Figure a, Point b) => Get(b, a);

    public static Sequence<Point> Get(Circle a, Circle b)
    {
        double h1 = a.Position.x;
        double k1 = a.Position.y;

        double h2 = b.Position.x;
        double k2 = b.Position.y;

        double r1 = a.Radius;
        double r2 = b.Radius;

        double D = Math.Sqrt((h2 - h1) * (h2 - h1) + (k2 - k1) * (k2 - k1));

        if (D == 0 || D > r1 + r2)
            return Empty();

        double A = (r1 * r1 - r2 * r2 + D * D) / (2 * D);
        double H = Math.Sqrt(r1 * r1 - A * A);

        double Px = h1 + A * (h2 - h1) / D;
        double Py = k1 + A * (k2 - k1) / D;

        List<Point> points = new();

        double x = Px + H * (k2 - k1) / D;
        double y = Py - H * (h2 - h1) / D;

        points.Add(new Point((float)x, (float)y));

        x = Px - H * (k2 - k1) / D;
        y = Py + H * (h2 - h1) / D;

        points.Add(new Point((float)x, (float)y));

        return Contains(new Sequence<Point>(points, 2), a, b);
    }

    public static Sequence<Point> Get(Circle a, Line b)
    {
        double A = 1 + b.Slope * b.Slope;
        double B = 2 * (b.Slope * b.Intercept - b.Slope * a.Position.x - a.Position.y);
        double C =
            a.Position.x * a.Position.x
            + a.Position.y * a.Position.y
            + b.Intercept * b.Intercept
            - 2 * b.Intercept * a.Position.x
            - a.Radius * a.Radius;

        double D = B * B - 4 * A * C;

        if (D == 0)
            return Empty();

        List<Point> points = new();

        double x = (-B + Math.Sqrt(D)) / (2 * A);
        double y = b.Slope * x + b.Intercept;

        points.Add(new Point((float)x, (float)y));

        x = (-B - Math.Sqrt(D)) / (2 * A);
        y = b.Slope * x + b.Intercept;

        points.Add(new Point((float)x, (float)y));

        return Contains(new Sequence<Point>(points, 2), a, b);
    }

    public static Sequence<Point> Get(Line a, Circle b) => Get(b, a);

    public static Sequence<Point> Get(Line a, Line b)
    {
        if (a.Slope == b.Slope)
            return Empty();

        double x = (b.Intercept - a.Intercept) / (a.Slope - b.Slope);
        double y = a.Slope * x + a.Intercept;

        List<Point> points = new();
        points.Add(new Point((float)x, (float)y));
        return Contains(new Sequence<Point>(points, 1), a, b);
    }

    private static Sequence<Point> Empty() => new Sequence<Point>(new List<Point>(), 0);
}
