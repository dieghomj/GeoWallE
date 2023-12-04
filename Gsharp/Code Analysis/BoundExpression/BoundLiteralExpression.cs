public class BoundLiteralExpression : BoundExpression
{
    public BoundLiteralExpression(object value, GType type)
    {
        Value = value;
        GType = type;
    }

    public object Value { get; }
    private GType GType { get; }

    public override GType Type => GType;

    public override GObject Evaluate()
    {
        throw new NotImplementedException();
    }
}