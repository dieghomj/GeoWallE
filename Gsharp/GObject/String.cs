public class String : GObject
{
    public String(string value)
    {
        Value = value;
    }

    private GType Type = GType.String;
    private string Value;

    public override GType GetGType() => Type;

    public override object GetValue() => Value;

    public override bool IsTrue()
    {
        if(this.Value == "")
            return false;
        return true;
    }

    public static String operator +(String a, String b) => new String(string.Concat(a, b));
}
