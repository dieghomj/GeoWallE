using System.Collections;

public class Sequence<T> : GObject, IEnumerable<T>
    where T : GObject
{
    public Sequence(List<T> elements)
    {
        Elements = elements;
        Length = elements.Count;
    }

    public Sequence(int start, int? end = null)
    {
        Start = start;
        End = end;

        if (End is not null)
        {
            Length = (int)End - Start + 1;
            isRange = true;
        }
        else
            isInfinite = true;

        Elements = new List<T>();
    }

    private readonly GType Type = GType.Sequence;
    private readonly bool isInfinite = false;
    private readonly bool isRange = false;

    private List<T> Elements { get; }
    private int Length { get; }

    private int Start { get; }
    private int? End { get; }

    public override GType GetGType() => Type;

    public override object GetValue() => this;

    public override bool IsTrue()
    {
        if(Length == 0)
            return false;
        return true;
    }

    public IEnumerator<T> GetEnumerator()
    {
        if (!isInfinite && !isRange)
            return Elements.GetEnumerator();
        return new SequenceEnumerator<T>(Start, End);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
