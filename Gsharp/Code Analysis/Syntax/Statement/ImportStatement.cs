public class ImportStatement : Statement
{

    public ImportStatement(Expression path)
    {
        Path = path;
    }

    private Expression Path { get; }
    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
