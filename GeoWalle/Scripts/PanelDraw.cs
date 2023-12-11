using Godot;
using Gsharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

public partial class PanelDraw : Panel
{
    [Export]
    public Font Font;
    private static Font font;
    private static PanelDraw panelDraw;
    private Dictionary<GFigureKind, Action<Figure, Color, string>> FigureDrawings = new Dictionary<GFigureKind, Action<Figure, Color, string>>
    {
        {GFigureKind.Point, GDrawPoint},
        {GFigureKind.Line, GDrawLine},
        {GFigureKind.Ray, GDrawLine},
        {GFigureKind.Segment, GDrawLine},
        {GFigureKind.Arc, GDrawArc},
        {GFigureKind.Circle, GDrawCircle},

    };

    public override void _Ready()
    {
        font = Font;
        panelDraw = this;
    }
    public override void _Process(double delta)
    {

        if(Input.IsMouseButtonPressed(MouseButton.WheelDown))
            Scale*=2;
        if(Input.IsMouseButtonPressed(MouseButton.WheelUp))
            Scale/=2;

        if (Compiler.IsModified)
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
            Action<Figure, Color, string> DrawFigure = FigureDrawings[item.figure.Kind];
            DrawFigure(figure, color, message);
        }

    }
    public static void GDrawCircle(Figure figure, Color color, string message)
    {
        var circle = (Circle)figure;

        var radius = circle.Radius * GetNorm()/100;
        GD.Print(radius);
        var position = GetViewportPosition(circle.Position);
        panelDraw.DrawArc(position, radius, 0, 360, 50, GetColor(color));
        DrawMessage(message, position);

    }

    private static float GetNorm()
    {
        float v = panelDraw.Size.Length();
        GD.Print(v);
        return v;  
    }


    private static void GDrawArc(Figure figure, Color color, string message)
    {
        var arc = (Arc)figure;
        var radius = arc.Radius * GetNorm()/100;
        var center = GetViewportPosition(arc.Position);
        var startAngle = arc.StartAngle * 180 / (float)(2 * Math.PI);
        var endAngle = arc.EndAngle * 180 / (float)(2 * Math.PI);
        GD.Print($"radius : {radius}, start angle : {startAngle}, endAngle : {endAngle}");

        panelDraw.DrawArc(center, radius, startAngle, endAngle, 50, GetColor(color));
        DrawMessage(message, center);

    }

    private static void GDrawLine(Figure figure, Color color, string message)
    {
        var line = (Line)figure;
        var start = GetViewportPosition(line.StartPoint);
        var end = GetViewportPosition(line.EndPoint);
        panelDraw.DrawLine(start, end,GetColor(color),-1,true);
        DrawMessage(message, start);

    }

    private static void GDrawPoint(Figure figure, Color color, string message)
    {
        var position = GetViewportPosition(figure.Position);
        
        panelDraw.DrawCircle(position,3,GetColor(color));

        DrawMessage(message,position);
    }
    private static Godot.Color GetColor(Color color)
    {
        switch (color)
        {
            case Color.Red:
                return Godot.Color.Color8(255, 0, 0);
            case Color.Green:
                return Godot.Color.Color8(0, 255, 0);
            case Color.Blue:
                return Godot.Color.Color8(0, 0, 255);
            case Color.White:
                return Godot.Color.Color8(255, 255, 255);
            case Color.Black:
                return Godot.Color.Color8(0, 0, 0);
            case Color.Yellow:
                return Godot.Color.Color8(255, 255, 0);
            case Color.Cyan:
                return Godot.Color.Color8(0, 254, 252);
            case Color.Gray:
                return Godot.Color.Color8(100, 100, 100);
            case Color.Magenta:
                return Godot.Color.Color8(255, 0, 255);
            default:
                return Godot.Color.Color8(0, 0, 0);
        }
    }

    private static Vector2 GetViewportPosition((float x, float y) position)
    {
        var size = panelDraw.Size;
        return new Vector2(position.x*size.X/100, position.y * size.Y/100);
    }

    private static void DrawMessage(string message, Vector2 position)
    {
        if (!string.IsNullOrEmpty(message))
            panelDraw.DrawString(font, position + 10 * Vector2.Right, message,HorizontalAlignment.Left,-1,16,GetColor(Color.Black));
    }
}

