using System.Collections;
using System.Reflection.Emit;

public class Sequence<T> : GObject, IEnumerable<T>
    where T : GObject
{
    public Sequence(IEnumerable<T> elements, int count = -1)
    {
        Elements = elements;
        Count = count;
    }

    private IEnumerable<T> Elements { get; }
    public int Count { get; private set; }

    public override GType GetGType() => Elements.First().GetGType().GetSequenceType();

    public override object GetValue() => this;

    public override bool IsTrue()
    {
        if (Count == 0)
            return false;
        return true;
    }

    public override string ToString()
    {
        if (IsInfinite())
            return "{Infinite Sequence}";

        string output = "{ ";
        foreach (var x in Elements)
            output += x.ToString() + ' ';
        return output + "}";
    }

    public bool IsInfinite() => Count == -1;

    public IEnumerator<T> GetEnumerator() => Elements.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public static Sequence<T> operator +(Sequence<T> a, Sequence<T> b)
    {
        int count = -1;
        if (!a.IsInfinite() && !b.IsInfinite())
            count = a.Count + b.Count;

        return new Sequence<T>(Concat(a, b), count);
    }

    private static IEnumerable<T> Concat(Sequence<T> a, Sequence<T> b)
    {
        foreach (T element in a)
            yield return element;

        foreach (T element in b)
            yield return element;
    }
}
