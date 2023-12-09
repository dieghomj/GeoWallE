public class FunctionSymbol
{
    public FunctionSymbol(string functionName, IEnumerable<string> parameters)
    {
        FunctionName = functionName;
        Parameters = parameters;
    }

    public string FunctionName { get; }
    public IEnumerable<string> Parameters { get; }
}
