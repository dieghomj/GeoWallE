using System.Data;
using System.Timers;

namespace Gsharp;

public class Compiler
{

    private static readonly List<Figure> figures = new List<Figure>();
    private static bool isModified = false;
    private static readonly System.Timers.Timer timer = new System.Timers.Timer() ;
    public Compiler()
    {
    }

    public void Evaluate(){}

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
        if(time >= 3000)
            isModified = false;
    }
    public static bool IsModified => isModified;

    public static List<Figure> Figures => figures;
}
