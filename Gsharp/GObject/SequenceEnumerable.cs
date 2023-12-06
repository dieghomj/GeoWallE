using System.Collections;
using System.Runtime.CompilerServices;

internal class SequenceEnumerable<T> : IEnumerable<T>
    where T : GObject
{
    public IEnumerator<T> GetEnumerator()
    {
        return new SequenceEnumerator<T>();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
