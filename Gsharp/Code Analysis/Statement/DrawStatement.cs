public class DrawStatement : Statement
{
    Expression Figure;

    public DrawStatement(Expression figure)
    {
        Figure = figure;
    }

    public override void Bind()
    {
        throw new NotImplementedException();
    }
}
