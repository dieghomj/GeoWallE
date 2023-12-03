public class Number : GObject
{
    public Number(double value)
    {
        Value = value;
    }

    private GType Type = GType.Number;
    private double Value;

    public override GType GetGType() => Type;

    public override object GetValue() => Value;
}
