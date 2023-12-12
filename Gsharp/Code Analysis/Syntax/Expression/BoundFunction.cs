using Gsharp;

/// <summary>
/// Representa la clase de las funciones que han sido chequeadas semánticamente.
/// </summary> <summary>
/// 
/// </summary>
public class BoundFunction
{
    public BoundFunction(string functionName, List<GType> types, GType resultType)
    {
        FunctionName = functionName;
        Types = types;
        ResultType = resultType;
    }

    public string FunctionName { get; }
    public List<GType> Types { get; }
    public GType ResultType { get; }

    private static List<BoundFunction> syntaxBindFunctions = new List<BoundFunction>();
    /// <summary>
    /// Dada el nombre de una función, una lista con los GType de sus argumentos, la expresion de llamada y la definicion de las variables retorna el GType de retorno de la función
    /// </summary>
    /// <param name="functionName"></param>
    /// <param name="types"></param>
    /// <param name="functionCallExpression"></param>
    /// <param name="visibleVariables"></param>
    /// <returns></returns> <summary>
    /// 
    /// </summary>
    /// <param name="functionName"></param>
    /// <param name="types"></param>
    /// <param name="functionCallExpression"></param>
    /// <param name="visibleVariables"></param>
    /// <returns></returns>
    public static GType BindFunction(string functionName, List<GType> types, FunctionCallExpression functionCallExpression, Dictionary<string, GType> visibleVariables)
    {
        foreach (var function in syntaxBindFunctions)
        {
            if (function.FunctionName == functionName && function.Types.SequenceEqual(types))
                return function.ResultType;
        }
        AddFunction(functionName,types,GType.Undefined);
        return functionCallExpression.Bind(visibleVariables);
    }

    public static void Reset()
    {
        syntaxBindFunctions.Clear();
    }

    public static void AddFunction(string functionToken, List<GType> typesList, GType resultType)
    {
        syntaxBindFunctions.Add(new BoundFunction(functionToken, typesList, resultType));
    }
}