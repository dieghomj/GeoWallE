public class BoundImportStatement : BoundStatement
{
    public BoundImportStatement(BoundExpression path)
    {
        Path = path;
    }

    public BoundExpression Path { get; }

    public override void EvaluateStatement()
    {
        throw new NotImplementedException();
    }
}
