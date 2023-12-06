public class ImportStatement : Statement
{
    private Expression Path;

    public ImportStatement(Expression path)
    {
        Path = path;
    }

    public override void Bind()
    {
        throw new NotImplementedException();
    }
}
