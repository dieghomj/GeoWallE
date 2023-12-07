public class BoundImportStatement : BoundStatement
{
    public BoundImportStatement(BoundExpression path)
    {
        Path = path;
    }

    public BoundExpression Path { get; }

    public override void EvaluateStatement(Dictionary<string, GObject> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
