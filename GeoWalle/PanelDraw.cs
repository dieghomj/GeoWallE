using Godot;
using Gsharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

public partial class PanelDraw : Panel
{
    [Export]
    public static Font Font;
    private static PanelDraw panelDraw;
    private Dictionary<GFigureKind, Action<Figure, Color, string>> FigureDrawings = new Dictionary<GFigureKind, Action<Figure, Color, string>>
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
        var x = circle.Position.x;
        var y = circle.Position.y;

        var radius = circle.Radius;
        var position = new Vector2(x, y);
        panelDraw.DrawArc(position, radius, 0, 360, 50, GetColor(color));
        DrawMessage(message, position);

    }
    private static void GDrawArc(Figure figure, Color color, string message)
    {
        var arc = (Arc)figure;
        var radius = arc.Radius;
        var center = new Vector2(arc.Position.x, arc.Position.y);
        var startAngle = arc.StartAngle;
        var endAngle = arc.EndAngle;

        panelDraw.DrawArc(center, radius, startAngle, endAngle, 50, GetColor(color));
        DrawMessage(message, center);

    }

    private static void GDrawSegment(Figure figure, Color color, string message)
    {
        var segment = (Segment)figure;
        var start = segment.StartPoint;
        var end = segment.EndPoint;

        panelDraw.DrawLine(new Vector2(start.x, start.y), new Vector2(end.x, end.y), GetColor(color));
        DrawMessage(message, new Vector2(start.x, start.y));
    }

    private static void GDrawRay(Figure figure, Color color, string message)
    {
        var ray = (Ray)figure;
        var start = ray.StartPoint;
        var end = ray.EndPoint;
        panelDraw.DrawLine(new Vector2(start.x,start.y), new Vector2(end.x,end.y),GetColor(color));
        DrawMessage(message, new Vector2(start.x, start.y));
    }

    private static void GDrawLine(Figure figure, Color color, string message)
    {
        var line = (Line)figure;
        var start = line.StartPoint;
        var end = line.EndPoint;
        panelDraw.DrawLine(new Vector2(start.x,start.y), new Vector2(end.x,end.y),GetColor(color));
        DrawMessage(message, new Vector2(start.x, start.y));

    }

    private static void GDrawPoint(Figure figure, Color color, string message)
    {
        var position = figure.Position;

        panelDraw.DrawCircle(new Vector2(position.x,position.y),5,GetColor(color));

        DrawMessage(message,new Vector2(position.x,position.y));
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

    private static void DrawMessage(string message, Vector2 position)
    {
        if (!string.IsNullOrEmpty(message))
            panelDraw.DrawString(Font, position, message);
    }
}

