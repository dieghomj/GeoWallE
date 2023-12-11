public class BoundMatchStatement : BoundStatement
{
    public BoundMatchStatement(List<VariableSymbol> boundVariables, BoundExpression boundSequence)
    {
        BoundVariables = boundVariables;
        BoundSequence = boundSequence;
    }

    public List<VariableSymbol> BoundVariables { get; }
    public BoundExpression BoundSequence { get; }

    public override void EvaluateStatement(Dictionary<string, GObject> visibleVariables)
    {
        if (BoundSequence.Type == GType.Undefined)
        {
            foreach (var variable in BoundVariables)
                visibleVariables[variable.Name] = new Undefined();
            return;
        }

        dynamic sequence = BoundSequence.Evaluate(visibleVariables);
        IEnumerator<GObject> sequenceEnumerator = sequence.GetEnumerator();

        for (int i = 0; i < BoundVariables.Count - 1; ++i)
        {
            if (sequenceEnumerator.MoveNext())
                visibleVariables[BoundVariables[i].Name] = sequenceEnumerator.Current;
            else
                visibleVariables[BoundVariables[i].Name] = new Undefined();
        }

        int count = sequence.Count;
        if (!sequence.IsInfinite())
            count = Math.Max(0, count - BoundVariables.Count + 1);

            visibleVariables[BoundVariables[BoundVariables.Count - 1].Name] = new Sequence<GObject>(
                GetRemainderEnumerable(sequenceEnumerator, BoundVariables.Count - 1),
                count
            );
        }
    }

    private IEnumerable<GObject> GetRemainderEnumerable(IEnumerator<GObject> sequenceEnumerator,int ignore)
    {
        sequenceEnumerator.Reset();

        while (ignore > 0)
        {
            sequenceEnumerator.MoveNext();
            ignore--;
        }

        while (sequenceEnumerator.MoveNext())
            yield return sequenceEnumerator.Current;

        sequenceEnumerator.Reset();
    }
}
