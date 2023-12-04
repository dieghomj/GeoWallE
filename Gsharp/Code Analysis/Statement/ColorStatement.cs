public class ColorStatement : Statement
{
    private SyntaxKind Color;

    public ColorStatement(SyntaxKind color)
    {
        Color = color;
    }
}
