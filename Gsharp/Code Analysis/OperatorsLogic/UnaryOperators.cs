public enum UnaryOperatorKind
{
    LogicalNegation,
    Identity,
    Negation
}
public static class UnaryOperator
{
    public static Dictionary<SyntaxKind,Func<object,object>> OperatorFunc = new Dictionary<SyntaxKind, Func<object, object>>
    {
        {SyntaxKind.PlusToken, Identity},
        {SyntaxKind.MinusToken, Negation},
        {SyntaxKind.BangToken, LogicalNegation},
    
    };
    #region casi cochina
    private static object Identity(object operand)
    {
        throw new NotImplementedException();
    }

    private static object Negation(object operand)
    {
        throw new NotImplementedException();
    }

    private static object LogicalNegation(object operand)
    {
        throw new NotImplementedException();
    }
    #endregion

    public static int GetPrecedence(SyntaxKind kind)
    {
        switch (kind)
        {
            case SyntaxKind.PlusToken:
            case SyntaxKind.MinusToken:
            case SyntaxKind.BangToken:
                return 8;

            default:
                return 0;
        }
    }

    internal static Func<object, object> GetOperatorFunc(SyntaxKind operatorKind) => OperatorFunc[operatorKind];
}
