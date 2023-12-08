public class Undefined : GObject
{
    public Undefined() { }

    private GType Type = GType.Undefined;

    public override GType GetGType() => Type;

    public override object GetValue()
    {
        throw new NotImplementedException();
    }

    public override bool IsTrue() => false;
}
