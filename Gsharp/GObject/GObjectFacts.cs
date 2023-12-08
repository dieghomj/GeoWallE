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
}
