public class SyntaxTree
{
    public SyntaxTree(Expression root)
    {
        Root = root;
    }

    public Expression Root { get; }

    public object Evaluate()
    {
        throw new NotImplementedException();
    }
}
