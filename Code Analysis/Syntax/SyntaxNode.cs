public abstract class SyntaxNode
{
    public abstract SyntaxKind Kind { get; }

    public abstract IEnumerable<SyntaxNode> GetChildren();

    public override string ToString()
    {
        return Kind.ToString();
    }
}
