internal class BoundSequenceDeclarationStatement : BoundStatement
{
    public BoundSequenceDeclarationStatement(VariableSymbol variableSymbol)
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
                
                visibleVariables[name] = new Sequence<Point>(new List<Point>{new Point(),new Point(), new Point()},3);
                break;
            case GType.Circle:
                visibleVariables[name] = new Sequence<Circle>(new List<Circle>{new Circle(),new Circle(), new Circle()},3);
                break;
            case GType.Line:
                visibleVariables[name] = new Sequence<Line>(new List<Line>{new Line(),new Line(), new Line()},3);
                break;
            case GType.Ray:
                visibleVariables[name] = new Sequence<Ray>(new List<Ray>{new Ray(),new Ray(), new Ray()},3);
                break;
            case GType.Segment:
                visibleVariables[name] = new Sequence<Segment>(new List<Segment>{new Segment(),new Segment(), new Segment()},3);
                break;
            default:
                visibleVariables[name] = null;
                break;
        }
    }
}