public static class BinaryOperator
{
    private static Dictionary<SyntaxKind, Func<object, object, object>> OperatorFunc =
        new Dictionary<SyntaxKind, Func<object, object, object>>
        {
            { SyntaxKind.PlusToken, Addition },
            { SyntaxKind.MinusToken, Subtraction },
            { SyntaxKind.StarToken, Multiplication },
            { SyntaxKind.DivToken, Division },
            { SyntaxKind.PercentToken, Remainder },
            { SyntaxKind.CircumflexToken, Power },
            { SyntaxKind.AmpersandToken, LogicalAnd },
            { SyntaxKind.PipeToken, LogicalOr },
            { SyntaxKind.EqualEqualToken, (a, b) => Equals(a, b) },
            { SyntaxKind.BangEqualToken, (a, b) => !Equals(a, b) },
            { SyntaxKind.GreaterEqualToken, GreaterEqual },
            { SyntaxKind.LessEqualToken, LessEqual },
            { SyntaxKind.GreaterToken, Greater },
            { SyntaxKind.LessToken, Less },
    };

    public static Func<object,object,object> GetOperatorFunc(SyntaxKind operatorKind) => OperatorFunc[operatorKind];
    public static int GetPrecedence(SyntaxKind kind)
    {
        switch (kind)
        {
            case SyntaxKind.CircumflexToken:
                return 7;

            case SyntaxKind.StarToken:
            case SyntaxKind.DivToken:
            case SyntaxKind.PercentToken:
                return 6;

            case SyntaxKind.PlusToken:
            case SyntaxKind.MinusToken:
                return 5;

            case SyntaxKind.AtToken:
                return 4;

            case SyntaxKind.EqualEqualToken:
            case SyntaxKind.BangEqualToken:
            case SyntaxKind.GreaterEqualToken:
            case SyntaxKind.LessEqualToken:
            case SyntaxKind.LessToken:
            case SyntaxKind.GreaterToken:
                return 3;

            case SyntaxKind.AmpersandToken:
                return 2;

            case SyntaxKind.PipeToken:
                return 1;

            default:
                return 0;
        }
    }

    #region COChinas de pepe
    private static object Addition(object left, object right)
    {
        throw new NotImplementedException();
    }

    private static object Subtraction(object left, object right)
    {
        throw new NotImplementedException();
    }

    private static object Multiplication(object left, object right)
    {
        throw new NotImplementedException();
    }

    private static object Division(object left, object right)
    {
        throw new NotImplementedException();
    }

    private static object Remainder(object left, object right)
    {
        throw new NotImplementedException();
    }

    private static object Power(object left, object right)
    {
        throw new NotImplementedException();
    }

    private static object LogicalAnd(object left, object right)
    {
        throw new NotImplementedException();
    }

    private static object LogicalOr(object left, object right)
    {
        throw new NotImplementedException();
    }

    private static object GreaterEqual(object left, object right)
    {
        throw new NotImplementedException();
    }

    private static object LessEqual(object left, object right)
    {
        throw new NotImplementedException();
    }

    private static object Greater(object left, object right)
    {
        throw new NotImplementedException();
    }

    private static object Less(object left, object right)
    {
        throw new NotImplementedException();
    }
    #endregion

}
