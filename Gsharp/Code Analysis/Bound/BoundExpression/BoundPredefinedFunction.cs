

public class BoundPredefinedFunction
{
    public delegate GObject PredefinedFunctionEvaluation (params GObject[]  args);
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
        new BoundPredefinedFunction( "randoms", 0, new GType[] {}, GType.Sequence, Randoms),
        new BoundPredefinedFunction( "samples", 0, new GType[] {}, GType.Sequence, Samples),

        new BoundPredefinedFunction( "points", 1, new GType[] {GType.Figure}, GType.Sequence, Points),
        new BoundPredefinedFunction( "count", 1, new GType[] {GType.Sequence}, GType.Number, Count),

        new BoundPredefinedFunction( "line", 2, new GType[] {GType.Point,GType.Point}, GType.Line, CreateLine),
        new BoundPredefinedFunction( "segment", 2, new GType[] {GType.Point,GType.Point}, GType.Segment, CreateSegment),
        new BoundPredefinedFunction( "ray", 2, new GType[] {GType.Point,GType.Point}, GType.Ray, CreateRay),
        new BoundPredefinedFunction( "circle", 2, new GType[] {GType.Point,GType.Measure}, GType.Circle, CreateCircle),

        //TODO: FIX THIS measure y intersect van a dar error cuando no se le pasen expresiones que sean explicitamente figuras
        new BoundPredefinedFunction( "measure", 2, new GType[] {GType.Figure,GType.Figure}, GType.Measure, CreateMeasure),
        new BoundPredefinedFunction( "intersect", 2, new GType[] {GType.Figure,GType.Figure}, GType.Sequence, Intersect),


        new BoundPredefinedFunction( "arc", 4, new GType[] {GType.Point,GType.Point,GType.Point,GType.Measure}, GType.Arc, CreateArc),
    };

    public static BoundPredefinedFunction Bind(string function, int argumentsCount, GType[] argumentsType)
    {
        foreach (var predefFunction in _Functions)
        {
            if (predefFunction.Function != function)
                continue;
            if(predefFunction.ArgumentsCount != argumentsCount)
                continue;

            bool equalArguments = true;
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
    private static GObject CreateArc(GObject[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject Intersect(GObject[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject CreateMeasure(GObject[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject CreateCircle(GObject[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject CreateRay(GObject[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject CreateSegment(GObject[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject CreateLine(GObject[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject Points(GObject[] args)
    {
        throw new NotImplementedException();
    }

    private static GObject Samples(GObject[] args)
    {
        Random random = new Random();
        List<Point> sequence = new List<Point>();
        var count = random.Next(2,10);
        for(int i = 0; i < count; i++)
        {
            var point = new Point();
            sequence.Add(point);
        }
        return new Sequence<Point>(sequence,count);
    }
    private static GObject Count(GObject[] args) 
    {
        dynamic s = args[0];
        return new Number(s.Count);
    }

    private static GObject Randoms(GObject[] args)
    {
        Random random = new Random();
        List<Number> sequence = new List<Number>();
        var count = random.Next(2,10);
        for(int i = 0; i < count; i++)
        {
            var number = new Number(random.NextDouble());
            sequence.Add(number);
        }
        return new Sequence<Number>(sequence,count);
    }

    #endregion

}