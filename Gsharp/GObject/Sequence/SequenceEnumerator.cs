using System.Collections;

internal class SequenceEnumerator<T> : IEnumerator<T>
    where T : GObject
{
    public SequenceEnumerator() { }

    public T Current => throw new NotImplementedException();

    object IEnumerator.Current => throw new NotImplementedException();

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public bool MoveNext()
    {
        throw new NotImplementedException();
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}
