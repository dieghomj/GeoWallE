public class DrawStatement : Statement
{
    Expression Figure;

    public DrawStatement(Expression figure)
    {
        Figure = figure;
    }

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
