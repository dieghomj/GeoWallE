public class Binder
{

    private static Dictionary<string, GType> sequenceVariables = new Dictionary<string, GType>();

    /// <summary>
    /// Inicializa un analizador semantico para una lista de Statement
    /// </summary>
    /// <param name="roots"></param>
    public Binder(List<Statement> roots)
    {
        Roots = roots;
    }

    public List<Statement> Roots { get; }

    /// <summary>
    /// Analiza semanticamente una lista de Statement
    /// </summary>
    /// <param name="visibleVariables"></param>
    /// <returns> Un IEnumerable de BoundStatement</returns>
    public IEnumerable<BoundStatement> Bind(Dictionary<string, GType> visibleVariables)
    {
        foreach (var statement in Roots)
        {
            statement.BindStatement(visibleVariables);
            yield return statement.GetBoundStatement(visibleVariables);
        }
    }

    public static void AddSequenceVariable(string name, GType type)
    {
        sequenceVariables.Add(name, type);
    }

    public static GType GetSequenceVariable(string name)
    {
        return sequenceVariables.FirstOrDefault(x => x.Key == name).Value;
    }
}
