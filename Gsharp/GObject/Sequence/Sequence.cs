public class Sequence<T> : GObject
    where T : GObject
{
    private SequenceEnumerable<T> elements;
    private bool isInfinite;

    public Sequence() { }

    public override GType GetGType()
    {
        throw new NotImplementedException();
    }

    public override object GetValue()
    {
        throw new NotImplementedException();
    }

    public override bool IsTrue()
    {
        throw new NotImplementedException();
    }
}
