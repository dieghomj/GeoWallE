public class ColorStatement : Statement
{
    private SyntaxKind Color;

    public ColorStatement(SyntaxKind color)
    {
        Color = color;
    }

    public override void Bind()
    {
        throw new NotImplementedException();
    }
}
