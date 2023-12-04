public class DrawStatement : Statement
{
    Expression Figure;

    public DrawStatement(Expression figure)
    {
        Figure = figure;
    }
}
