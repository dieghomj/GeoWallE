public static class UnaryOperator
{
    public static Dictionary<SyntaxKind, Func<object, object>> OperatorFunc = new Dictionary<
        SyntaxKind,
        Func<object, object>
    >
    {
        { SyntaxKind.PlusToken, Identity },
        { SyntaxKind.MinusToken, Negation },
        { SyntaxKind.BangToken, LogicalNegation },
    };

    private static Dictionary<SyntaxKind, Func<Expression, Expression>> InstantiateFunc =
        new()
        {
            { SyntaxKind.PlusToken, (Expression operand) => new IdentityExpression(operand) },
            { SyntaxKind.MinusToken, (Expression operand) => new NegationExpression(operand) },
            {
                SyntaxKind.BangToken,
                (Expression operand) => new LogicalNegationExpression(operand)
            },
        };

    internal static Func<object, object> GetOperatorFunc(SyntaxKind operatorKind) =>
        OperatorFunc[operatorKind];

    /// <summary>
    ///
    /// </summary>
    /// <param name="op"></param>
    /// <param name="operand"></param>
    /// <returns> Una nueva instancia de UnaryExpression </returns>
    public static Expression GetInstantiate(SyntaxToken op, Expression operand) =>
        InstantiateFunc[op.Kind](operand);

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
}
