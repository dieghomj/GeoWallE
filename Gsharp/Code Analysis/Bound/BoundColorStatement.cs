public class BoundColorStatement : BoundStatement
{

    public BoundColorStatement(Color color)
    {
        Color = color;
    }

    public Color Color { get; }

    public override void EvaluateStatement()
    {
        throw new NotImplementedException();
    }
}