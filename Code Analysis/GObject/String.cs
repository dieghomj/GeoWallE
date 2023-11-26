public class String : GObject
{
    public String(string value)
    {
        Value = value;
    }

    private GType Type = GType.STRING;
    private string Value;

    public override GType GetGType() => Type;

    public override object GetValue() => Value;
}
