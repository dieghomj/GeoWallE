public enum UnaryOperatorKind
{
    LogicalNegation,
    Identity,
    Negation
}
public class UnaryOperator
{
    public static Dictionary<SyntaxKind,Func<object,object,object>> OperatorFunc = new Dictionary<SyntaxKind, Func<object, object, object>>
    {
        {SyntaxKind.PlusToken, Identity},
        {SyntaxKind.MinusToken, Negation},
        {SyntaxKind.BangToken, LogicalNegation},
    
    };

    public UnaryOperator(SyntaxKind kind, UnaryOperatorKind operatorKind, Type operandType)
    {
        SyntaxKind = kind;
        OperatorKind = operatorKind;
        OperandType = operandType;
    }
    public SyntaxKind SyntaxKind { get; }
    public UnaryOperatorKind OperatorKind { get; }
    public Type OperandType { get; }

    private static UnaryOperator[] _operators = 
    {
        new UnaryOperator(SyntaxKind.BangToken, UnaryOperatorKind.LogicalNegation, typeof(bool)),

        new UnaryOperator(SyntaxKind.PlusToken, UnaryOperatorKind.Identity, typeof(double)),
        new UnaryOperator(SyntaxKind.MinusToken, UnaryOperatorKind.Negation, typeof(double)),
    };

    public static UnaryOperator Bind(SyntaxKind syntaxKind, Type operandType)
    {
        foreach(var op in _operators)
        {
            if(op.SyntaxKind == syntaxKind && op.OperandType == operandType)
                return op;
        }

        return null;
    }

    #region casi cochina
    private static object Identity(object arg1, object arg2)
    {
        throw new NotImplementedException();
    }

    private static object Negation(object arg1, object arg2)
    {
        throw new NotImplementedException();
    }

    private static object LogicalNegation(object arg1, object arg2)
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
}