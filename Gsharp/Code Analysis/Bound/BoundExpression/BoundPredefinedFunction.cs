

public class BoundPredefinedFunction
{
    public delegate GObject PredefinedFunctionEvaluation (params object[]  args);
    private BoundPredefinedFunction(string function, int argumentsCount, GType[] argumentsType, GType resultType,  PredefinedFunctionEvaluation evaluate)
    {
        Function = function;
        ArgumentsCount = argumentsCount;
        ArgumentsType = argumentsType;
        ResultType = resultType;
        Evaluate = evaluate;
    }

    private static BoundPredefinedFunction[] _Functions =
    {
            new BoundPredefinedFunction( "randoms", 0, new GType[] {}, GType.Number, Randoms),
            new BoundPredefinedFunction( "samples", 0, new GType[] {}, GType.Sequence, Samples),

            new BoundPredefinedFunction( "points", 1, new GType[] {GType.Figure}, GType.Sequence, Points),

            new BoundPredefinedFunction( "line", 2, new GType[] {GType.Point,GType.Point}, GType.Line, CreateLine),
            new BoundPredefinedFunction( "segment", 2, new GType[] {GType.Point,GType.Point}, GType.Segment, CreateSegment),
            new BoundPredefinedFunction( "ray", 2, new GType[] {GType.Point,GType.Point}, GType.Ray, CreateRay),
            new BoundPredefinedFunction( "circle", 2, new GType[] {GType.Point,GType.Measure}, GType.Circle, CreateCircle),

            //TODO: FIX THIS measure y intersect van a dar error cuando no se le pasen expresiones que sean explicitamente figuras
            new BoundPredefinedFunction( "measure", 2, new GType[] {GType.Figure,GType.Figure}, GType.Measure, CreateMeasure),
            new BoundPredefinedFunction( "intersect", 2, new GType[] {GType.Figure,GType.Figure}, GType.Sequence, Intersect),

            new BoundPredefinedFunction( "count", 1, new GType[] {GType.Sequence}, GType.Number, Count),

            new BoundPredefinedFunction( "arc", 4, new GType[] {GType.Point,GType.Point,GType.Point,GType.Measure}, GType.Arc, CreateArc),
    };

    public static BoundPredefinedFunction Bind(string function, int argumentsCount, GType[] argumentsType)
    {
        foreach (var predefFunction in _Functions)
        {   
            bool equalArguments = false;
            
            if(predefFunction.Function != function)
                continue;
            if(predefFunction.ArgumentsCount != argumentsCount)
                continue;
            
            equalArguments = true;
            for (int i = 0; i < predefFunction.ArgumentsType.Length; i++)
            {
                if (predefFunction.ArgumentsType[i] == argumentsType[i])
                    continue;
                equalArguments = false;
                break;
            }

            if(equalArguments)
                return predefFunction;
        }
        return null;
    }
    public string Function { get; }
    public int ArgumentsCount { get; }
    public GType[] ArgumentsType { get; }
    public GType ResultType { get; }
    public PredefinedFunctionEvaluation Evaluate { get; }

    #region Predefined Functions Evaluation

    private static GObject Count(object[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject CreateArc(object[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject Intersect(object[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject CreateMeasure(object[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject CreateCircle(object[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject CreateRay(object[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject CreateSegment(object[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject CreateLine(object[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject Points(object[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject Samples(object[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject Randoms(object[] args)
    {
        throw new NotImplementedException();
    }

    #endregion

}