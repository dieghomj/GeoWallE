public class BoundLiteralExpression : BoundExpression
{
    public BoundLiteralExpression(object value, GType type)
    {
        Value = value;
        GType = type;
    }

    private GType GType { get; }
    public object Value { get; }

    public override GType Type => GType;

    public override GObject Evaluate(Dictionary<string, GObject> visibleVariables)
    {
        switch (GType)
        {
            case GType.String:
                return new String((string)Value);
            case GType.Number:
                return new Number((double)Value);
            default:
                return new Number(0);
        }
    }
}
