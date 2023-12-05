using GInterfaces;
using Godot;
using System;
using System.Collections.Generic;
using System.Data;

public partial class PanelDraw : Panel
{
    static private List<IDrawable> figures = new List<IDrawable>();
    static private bool isModified = false;
    public override void _Process(double delta)
    {
        if(isModified)
            QueueRedraw();
    }
    public override void _Draw()
    {
        foreach(var figure in figures)
        {
            figure.DrawFigure();
        }
    }

    public static void AddFigure(IDrawable figure)
    {
        figures.Add(figure);
    }
}
    
