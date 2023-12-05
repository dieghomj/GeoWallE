using Godot;
using Gsharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

public partial class PanelDraw : Panel
{
    private static PanelDraw panelDraw;
    private Dictionary<GFigureKind,Action<Figure>> FigureDrawings = new Dictionary<GFigureKind, Action<Figure>>
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
        foreach (var figure in Compiler.Figures)
        {
            Action<Figure> DrawFigure = FigureDrawings[figure.Kind];
            DrawFigure(figure);
        }
        
    }
    public static void GDrawCircle(Figure figure)
    {
    }

    private static void GDrawArc(Figure figure)
    {
        throw new NotImplementedException();
    }

    private static void GDrawSegment(Figure figure)
    {
        throw new NotImplementedException();
    }

    private static void GDrawRay(Figure figure)
    {
        throw new NotImplementedException();
    }

    private static void GDrawLine(Figure figure)
    {
        throw new NotImplementedException();
    }

    private static void GDrawPoint(Figure figure)
    {
    }

}
    
