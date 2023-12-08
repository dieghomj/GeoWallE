using System.Collections;

public class Sequence<T> : GObject, IEnumerable<T>
    where T : GObject
{
    private List<T> elements;
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

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
