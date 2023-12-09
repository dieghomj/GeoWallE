public class ImportStatement : Statement
{
    public ImportStatement(Expression path)
    {
        Path = path;
    }

    private Expression Path { get; }

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        BoundExpression boundPath = Path.GetBoundExpression(visibleVariables);

        if (boundPath.Type == GType.String)
            return new BoundImportStatement(boundPath);

        Console.WriteLine("SEMANTIC ERROR!: Expected string literal in import statement");
        return null!;
    }
}
