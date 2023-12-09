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
