public class SyntaxToken : SyntaxNode
{
    public SyntaxToken(SyntaxKind kind, int start, string text, object? value)
    {
        Kind = kind;
        Start = start;
        Text = text;
        Value = value;
    }

    public override SyntaxKind Kind { get; }
    public int Start { get; }
    public string Text { get; }
    public object? Value { get; }

    public override IEnumerable<SyntaxNode> GetChildren()
    {
        return Enumerable.Empty<SyntaxNode>();
    }
}
