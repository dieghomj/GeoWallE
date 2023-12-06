using System.Data;
using System.Drawing;

public abstract class Statement
{
    public abstract void BindStatement(Dictionary<string, GType> visibleVariables);
    public abstract BoundStatement GetBoundStatement(Dictionary<string, GType> visibleVariables);
}
