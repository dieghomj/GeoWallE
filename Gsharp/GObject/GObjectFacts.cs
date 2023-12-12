public static class GObjectFacts
{
    public static List<GType> GTypeList =
        new() { GType.Point, GType.Line, GType.Circle, GType.Arc, GType.Ray, GType.Segment, };

    public static bool IsFigure(this GType type)
    {
        switch (type)
        {
            case GType.Circle:
            case GType.Arc:
            case GType.Line:
            case GType.Segment:
            case GType.Ray:
            case GType.Point:
                return true;
            default:
                return false;
        }
    }
    public static bool IsFigureSequence(this GType type)
    {
        switch (type)
        {
            case GType.CircleSequence:
            case GType.ArcSequence:
            case GType.LineSequence:
            case GType.SegmentSequence:
            case GType.RaySequence:
            case GType.PointSequence:
                return true;
            default:
                return false;
        }
    }
    public static bool IsSequence(this GType type)
    {
        switch (type)
        {
            case GType.NumberSequence:
            case GType.MeasureSequence:
            case GType.StringSequence:
            case GType.FigureSequence:
            case GType.PointSequence:
            case GType.LineSequence:
            case GType.SegmentSequence:
            case GType.RaySequence:
            case GType.ArcSequence:
            case GType.CircleSequence:
                return true;
            default:
                return false;
        }
    }

    public static GType GetSequenceType(this GType type)
    {
        switch (type)
        {
            case GType.Number:
                return GType.NumberSequence;
            case GType.Measure:
                return GType.MeasureSequence;
            case GType.String:
                return GType.StringSequence;
            case GType.Figure:
                return GType.FigureSequence;
            case GType.Point:
                return GType.PointSequence;
            case GType.Line:
                return GType.LineSequence;
            case GType.Segment:
                return GType.SegmentSequence;
            case GType.Ray:
                return GType.RaySequence;
            case GType.Arc:
                return GType.ArcSequence;
            case GType.Circle:
                return GType.CircleSequence;
            default:
                return GType.Undefined;
        }
    }

    public static GType ToSingleType(this GType type)
    {
        switch (type)
        {
            case GType.NumberSequence:
                return GType.Number;    
            case GType.MeasureSequence:
                return GType.Measure;
            case GType.StringSequence:
                return GType.String;
            case GType.FigureSequence:
                return GType.Figure;
            case GType.PointSequence:
                return GType.Point;
            case GType.LineSequence:
                return GType.Line;
            case GType.SegmentSequence:
                return GType.Segment;
            case GType.RaySequence:
                return GType.Ray;
            case GType.ArcSequence:
                return GType.Arc;
            case GType.CircleSequence:
                return GType.Circle;
            default:
                return GType.Undefined;
        }
    }
    internal static IEnumerable<Number> GetRangeSequence(int start, int? end)
    {
        if (end is null)
        {
            for (int i = start; ; ++i)
                yield return new Number(i);
        }
        else
        {
            if (start <= end)
            {
                for (int i = start; i <= end; ++i)
                    yield return new Number(i);
            }
            else
                yield break;
        }
    }
}
