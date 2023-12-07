using System.Data;
using System.Timers;

namespace Gsharp;

public class Compiler
{
    private static readonly List<(Figure figure, Color color, string message)> figures = new List<(Figure, Color, string)>();
    private static Color currentColor = Color.Black;
    private static bool isModified = false;
    private static readonly System.Timers.Timer timer = new System.Timers.Timer();

    public Compiler(string code) { 

    }

    public static void Evaluate() { }

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

    public static bool IsModified => isModified;

    public static List<(Figure, Color, string)> Figures => figures;

    public static Color CurrentColor { get => currentColor; set => currentColor = value; }
}
