public class Binder
{
    private Dictionary<string, GType> visibleVariables = new Dictionary<string, GType>();
    public Binder(Expression root)
    {
        Root = root;
    }

    public Expression Root { get; }

    public BoundExpression Bind() => Root.GetBoundExpression(visibleVariables);
}