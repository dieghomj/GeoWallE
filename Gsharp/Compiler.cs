using System.Data;
using System.Diagnostics;
using System.Timers;

namespace Gsharp;

public static class Compiler
{
    private static List<Statement> syntaxStatements = new List<Statement>();
    private static List<BoundStatement> boundStatements = new List<BoundStatement>();

    private static List<(Figure figure, Color color, string message)> figures =
        new List<(Figure, Color, string)>();
    private static Color currentColor = Color.Black;
    private static bool isModified = false;
    private static readonly System.Timers.Timer timer = new System.Timers.Timer();

    private static Dictionary<string, NodeState> GraphState = new Dictionary<string, NodeState>();

    public static void Compile(string code)
    {
        Reset();

        GetSyntaxStatements(code);

        Dictionary<string, GType> visibleVariables = new Dictionary<string, GType>();

        foreach (Statement statement in syntaxStatements)
            AddBoundStatement(statement.GetBoundStatement(visibleVariables));
    }

    public static void Evaluate()
    {
        Dictionary<string, GObject> visibleVariables = new();

        foreach (BoundStatement boundStatement in boundStatements)
            boundStatement.EvaluateStatement(visibleVariables);
    }

    public static void Reset()
    {
        syntaxStatements = new List<Statement>();
        boundStatements = new List<BoundStatement>();
        GraphState = new Dictionary<string, NodeState>();
        figures = new List<(Figure, Color, string)>();
    }

    public static void GetSyntaxStatements(string code)
    {
        Parser parser = new Parser(code);

        List<ImportStatement> importStatements = parser.GetImportStatements();

        foreach (ImportStatement import in importStatements)
        {
            BoundImportStatement boundImport = (BoundImportStatement)
                import.GetBoundStatement(new Dictionary<string, GType>());

            boundImport.EvaluateStatement(new Dictionary<string, GObject>());
        }

        List<Statement> statements = parser.Parse();

        foreach (Statement statement in statements)
            AddSyntaxStatement(statement);
    }

    public static void AddSyntaxStatement(Statement statement) => syntaxStatements.Add(statement);

    private static void AddBoundStatement(BoundStatement boundStatement) =>
        boundStatements.Add(boundStatement);

    public static void AddFigure(Figure figure, string message)
    {
        timer.Start();
        isModified = true;
        figures.Add((figure, CurrentColor, message));
    }

    public static void Update()
    {
        //Esto aparentemente funciona
        var time = timer.Interval;
        if (time >= 3000)
            isModified = false;
    }

    public static NodeState GetState(string directory)
    {
        if (GraphState.ContainsKey(directory))
        {
            return GraphState[directory];
        }
        else
            return NodeState.UnProcessed;
    }

    public static void AddState(string directory, NodeState state) => GraphState[directory] = state;

    public static bool IsModified => isModified;

    public static List<(Figure, Color, string)> Figures => figures;

    public static Color CurrentColor
    {
        get => currentColor;
        set => currentColor = value;
    }
}
