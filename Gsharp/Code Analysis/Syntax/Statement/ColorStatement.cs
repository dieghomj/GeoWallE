public class ColorStatement : Statement
{

    public ColorStatement(Color color)
    {
        Color = color;
    }
    public Color Color { get; }

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        return;
    }

    public override BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables)
    {
        return new BoundColorStatement(Color);
    }
}
