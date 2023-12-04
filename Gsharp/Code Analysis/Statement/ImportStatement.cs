public class ImportStatement : Statement
{
    private Expression Path;

    public ImportStatement(Expression path)
    {
        Path = path;
    }
}
