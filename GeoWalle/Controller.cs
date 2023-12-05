using Godot;
using Gsharp;
using System;

public partial class Controller : Control
{
    private Compiler compiler = new Compiler();
    public void _OnRunButtonButtonDown()
    {
        compiler.Evaluate();
    }
}
