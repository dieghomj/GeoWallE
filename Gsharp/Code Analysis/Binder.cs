public class Binder
{
    public Binder(List<Statement> roots)
    {
        Roots = roots;
    }

    public List<Statement> Roots { get; }

    public IEnumerable<BoundStatement> Bind(Dictionary<string,GType> visibleVariables) 
    {
        foreach (var statement in Roots)
            yield return statement.GetBoundStatement(visibleVariables);
    }
}