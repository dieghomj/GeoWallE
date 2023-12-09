public class RestoreStatement : Statement
{
    public RestoreStatement() { }

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        return new BoundRestoreStatement();
    }
}
