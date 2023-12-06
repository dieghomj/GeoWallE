public class ImportStatement : Statement
{
    private Expression Path;

    public ImportStatement(Expression path)
    {
        Path = path;
    }

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
