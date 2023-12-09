internal class BoundDeclarationStatement : BoundStatement
{
    public BoundDeclarationStatement(VariableSymbol variableSymbol)
    {
        VariableSymbol = variableSymbol;
    }

    public VariableSymbol VariableSymbol { get; }

    public override void EvaluateStatement(Dictionary<string, GObject> visibleVariables)
    {
        var name = VariableSymbol.Name;
        var type = VariableSymbol.Type;  

        switch ( type )
        {
            case GType.Point:
                visibleVariables[name] = new Point();
                break;
            case GType.Circle:
                visibleVariables[name] = new Circle();
                break;
            case GType.Line:
                visibleVariables[name] = new Line();
                break;
            case GType.Ray:
                visibleVariables[name] = new Ray();
                break;
            case GType.Segment:
                visibleVariables[name] = new Segment();
                break;
            default:
                visibleVariables[name] = null;
                break;
        }


    }
}