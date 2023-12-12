using System.Dynamic;

public static class IntersectFigures
{
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
            return new Sequence<Point>(new List<Point>(), 0);

        double A = (r1 * r1 - r2 * r2 + D * D) / (2 * D);
        double H = Math.Sqrt(r1 * r1 - A * A);

        double Px = h1 + A * (h2 - h1) / D;
        double Py = k1 + A * (k2 - k1) / D;

        List<Point> points = new();
        double x = Px + H * (k2 - k1) / D;
        double y = Px - H * (h2 - h1) / D;
        points.Add(new Point((float)x, (float)y));
        x = Px - H * (k2 - k1) / D;
        y = Px + H * (h2 - h1) / D;
        points.Add(new Point((float)x, (float)y));

        return new Sequence<Point>(points, 2);
    }

    public static Sequence<Point> Get(Line a, Line b)
    {
        if (a.Slope == b.Slope)
            return new Sequence<Point>(new List<Point>(), 0);

        double x = (b.Intercept - a.Intercept) / (a.Slope - b.Slope);
        double y = a.Slope * x + a.Intercept;

        List<Point> points = new();
        points.Add(new Point((float)x, (float)y));
        return new Sequence<Point>(points, 1);
    }
}
