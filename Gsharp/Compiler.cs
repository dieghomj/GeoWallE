using System.Data;
using System.Diagnostics;
using System.Timers;

namespace Gsharp;

public static class Compiler
{
    private static string? debugLog = "";
    private static List<Error> errors = new List<Error>();
    private static List<Statement> syntaxStatements = new List<Statement>();
    private static List<BoundStatement> boundStatements = new List<BoundStatement>();
    private readonly static Stack<Color> ColorStack = new Stack<Color>();
    private static List<(Figure figure, Color color, string message)> figures = new List<(Figure, Color, string)>();
    private static bool isModified = false;
    private static readonly System.Timers.Timer timer = new System.Timers.Timer();
    private static Dictionary<string, NodeState> GraphState = new Dictionary<string, NodeState>();
    private static Dictionary<FunctionSymbol, Expression> syntaxFunctionDefinitions = new Dictionary<FunctionSymbol, Expression>();

    public static void Compile(string code)
    {
        Reset();

        GetSyntaxStatements(code);

        Dictionary<string, GType> visibleVariables = new Dictionary<string, GType>();

        Binder binder = new Binder(syntaxStatements);
        boundStatements = binder.Bind(visibleVariables).ToList();
    }

    public static void Evaluate()
    {
        figures.Clear();
        ColorStack.Clear();
        ColorStack.Push(Color.Black);
        debugLog = "";
        Dictionary<string, GObject> visibleVariables = new Dictionary<string, GObject>();

        foreach (BoundStatement boundStatement in boundStatements)
            boundStatement.EvaluateStatement(visibleVariables);
    }

    public static void Reset()
    {
        ColorStack.Clear();
        debugLog = "";
        errors = new List<Error>();
        syntaxStatements = new List<Statement>();
        boundStatements = new List<BoundStatement>();
        syntaxFunctionDefinitions = new Dictionary<FunctionSymbol, Expression>();
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

    public static void AddFigure(Figure figure, string message)
    {
        timer.Start();
        isModified = true;
        figures.Add((figure, CurrentColor, message));
    }

    public static void Update()
    {
        //Esto aparentemente funciona o no
        var time = timer.Interval;
        if (time >= 1500)
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

    public static FunctionSymbol GetFunctionSymbol(Func<FunctionSymbol, bool> predicate)
    {
        return syntaxFunctionDefinitions.Keys.FirstOrDefault(predicate)!;
    }

    public static Expression GetFunctionDefinition(FunctionSymbol symbol)
    {
        if (!syntaxFunctionDefinitions.ContainsKey(symbol))
            return null!;
        return syntaxFunctionDefinitions[symbol];
    }

    public static void AddFunctionDefinition(FunctionSymbol symbol, Expression expression) =>
        syntaxFunctionDefinitions[symbol] = expression;

    public static void AddState(string directory, NodeState state) => GraphState[directory] = state;

    public static bool IsModified => isModified;

    public static List<(Figure figure, Color color, string message)> Figures => figures;

    public static List<Error> GetErrors() => new List<Error>(errors);

    public static void AddError(Error error) => errors.Add(error);

    public static string Print(string print)
    {
        debugLog += print + "\n";
        return debugLog;
    }

    internal static void ColorRestore() => ColorStack.Pop();

    public static Color CurrentColor
    {
        get => ColorStack.Peek();
        set => ColorStack.Push(value);
    }
}
