public class Boolean : GObject {
    
    public Boolean(bool value)
    {
        Value = value;
    }

    private GType Type = GType.BOOL;
    private bool Value;

    public override GType GetGType() => Type;

    public override object GetValue() => Value;
}