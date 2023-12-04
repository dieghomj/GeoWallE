using GInterfaces;
using Godot;
using System;
using System.Collections.Generic;
using System.Data;

public partial class PanelDraw : Panel
{
    //
    static private List<IDrawable> figures = new List<IDrawable>();
    public override void _Process(double delta)
    {
    }
    public override void _Draw()
    {
        
    }

    public static void AddFigure(IDrawable figure)
    {
        figures.Add(figure);
    }
}
    
