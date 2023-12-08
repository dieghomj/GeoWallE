using System.Data;
using System.Diagnostics;
using System.Timers;

namespace Gsharp;

public class Compiler
{
    public static Dictionary<FunctionSymbol,BoundExpression> FunctionDefinitions = new Dictionary<FunctionSymbol, BoundExpression>();
    public readonly Dictionary<string, GType> bindVariables = new Dictionary<string, GType>();
    public readonly Dictionary<string, GObject> evaluateVariables = new Dictionary<string, GObject>();
    private static readonly List<Figure> figures = new List<Figure>();
    private static bool isModified = false;
    private static readonly System.Timers.Timer timer = new System.Timers.Timer();

    public Compiler(string code)
    {
        FunctionDefinitions = new Dictionary<FunctionSymbol, BoundExpression>();
        var parser = new Parser(code);
        var boundStatements = new Binder(parser.Parse()).Bind(bindVariables);
        Statements = boundStatements;
    }

    public void Evaluate()
    {
        foreach (var statement in Statements)
        {
            Print($"{statement}\n");
            statement.EvaluateStatement(evaluateVariables);
        }

    }

    private void Print(object debug)
    {
        ConsoleDebug += debug.ToString();
    }

    public static void AddFigure(Figure figure)
    {
        timer.Start();
        isModified = true;
        figures.Add(figure);
    }

    public static void Update()
    {
        //Esto aparentemente funciona
        var time = timer.Interval;
        if (time >= 3000)
            isModified = false;
    }

    public static bool IsModified => isModified;
    public static List<Figure> Figures => figures;
    private IEnumerable<BoundStatement> Statements { get; }
    public string ConsoleDebug = "";
}
