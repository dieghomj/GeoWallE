using Godot;
using Gsharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

public partial class PanelDraw : Panel
{
    private static PanelDraw panelDraw;
    private Dictionary<GFigureKind,Action<Figure,Color,string>> FigureDrawings = new Dictionary<GFigureKind, Action<Figure,Color,string>>
    {
        {GFigureKind.Point, GDrawPoint},
        {GFigureKind.Line, GDrawLine},
        {GFigureKind.Ray, GDrawRay},
        {GFigureKind.Segment, GDrawSegment},
        {GFigureKind.Arc, GDrawArc},
        {GFigureKind.Circle, GDrawCircle},

    };
    
    public override void _Ready()
    {
        panelDraw = this;
    }
    public override void _Process(double delta)
    {
        if(Compiler.IsModified)
        {
            QueueRedraw();
            Compiler.Update();
        }
    }
    public override void _Draw()
    {
        foreach (var item in Compiler.Figures)
        {
            var figure = item.figure;
            var color = item.color;
            var message = item.message;   
            Action<Figure,Color,string> DrawFigure = FigureDrawings[item.figure.Kind];
            DrawFigure(figure,color,message);
        }
        
    }
    public static void GDrawCircle(Figure figure, Color color, string message)
    {
    }

    private static void GDrawArc(Figure figure, Color color, string message)
    {
        throw new NotImplementedException();
    }

    private static void GDrawSegment(Figure figure, Color color, string message)
    {
        throw new NotImplementedException();
    }

    private static void GDrawRay(Figure figure, Color color, string message)
    {
        throw new NotImplementedException();
    }

    private static void GDrawLine(Figure figure, Color color, string message)
    {
        throw new NotImplementedException();
    }

    private static void GDrawPoint(Figure figure, Color color, string message)
    {
    }

}
    
