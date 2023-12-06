public class ColorStatement : Statement
{
    private SyntaxKind Color;

    public ColorStatement(SyntaxKind color)
    {
        Color = color;
    }

    public override void BindStatement(Dictionary<string, GType> visibleVariables)
    {
        throw new NotImplementedException();
    }
}
