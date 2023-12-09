using Gsharp;

public class BoundRestoreStatement : BoundStatement
{
    public override void EvaluateStatement(Dictionary<string, GObject> visibleVariables)
    {
        Compiler.CurrentColor = Color.Black;
    }
}
