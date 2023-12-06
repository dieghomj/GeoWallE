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
}
