public class BinaryOperator
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

    private BinaryOperator(SyntaxKind syntaxKind, BinaryOperatorKind kind, Type type)
        : this(syntaxKind, kind, type, type, type) { }

    private BinaryOperator(
        SyntaxKind syntaxKind,
        BinaryOperatorKind kind,
        Type type,
        Type resultType
    )
        : this(syntaxKind, kind, type, type, resultType) { }

    public BinaryOperator(
        SyntaxKind kind,
        BinaryOperatorKind operatorKind,
        Type leftType,
        Type rightType,
        Type resultType
    )
    {
        SyntaxKind = kind;
        OperatorKind = operatorKind;
        LeftType = leftType;
        RightType = rightType;
        ResultType = resultType;
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

    private static BinaryOperator[] _operators =
    {
        //Number Operators
        new BinaryOperator(SyntaxKind.PlusToken, BinaryOperatorKind.Addition, typeof(double)),
        new BinaryOperator(SyntaxKind.MinusToken, BinaryOperatorKind.Subtraction, typeof(double)),
        new BinaryOperator(SyntaxKind.StarToken, BinaryOperatorKind.Multiplication, typeof(double)),
        new BinaryOperator(SyntaxKind.DivToken, BinaryOperatorKind.Division, typeof(double)),
        new BinaryOperator(SyntaxKind.PercentToken, BinaryOperatorKind.Remainder, typeof(double)),
        new BinaryOperator(
            SyntaxKind.CircumflexToken,
            BinaryOperatorKind.Exponentiation,
            typeof(double)
        ),
        new BinaryOperator(
            SyntaxKind.EqualEqualToken,
            BinaryOperatorKind.Equals,
            typeof(double),
            typeof(bool)
        ),
        new BinaryOperator(
            SyntaxKind.BangEqualToken,
            BinaryOperatorKind.NotEquals,
            typeof(double),
            typeof(bool)
        ),
        new BinaryOperator(
            SyntaxKind.GreaterToken,
            BinaryOperatorKind.Greater,
            typeof(double),
            typeof(bool)
        ),
        new BinaryOperator(
            SyntaxKind.LessToken,
            BinaryOperatorKind.Less,
            typeof(double),
            typeof(bool)
        ),
        new BinaryOperator(
            SyntaxKind.GreaterEqualToken,
            BinaryOperatorKind.GreaterEqual,
            typeof(double),
            typeof(bool)
        ),
        new BinaryOperator(
            SyntaxKind.LessEqualToken,
            BinaryOperatorKind.LessEqual,
            typeof(double),
            typeof(bool)
        ),
        //String Operators
        new BinaryOperator(
            SyntaxKind.EqualEqualToken,
            BinaryOperatorKind.Equals,
            typeof(string),
            typeof(bool)
        ),
        new BinaryOperator(
            SyntaxKind.BangEqualToken,
            BinaryOperatorKind.NotEquals,
            typeof(string),
            typeof(bool)
        ),
        //Bool Operators
        new BinaryOperator(SyntaxKind.AmpersandToken, BinaryOperatorKind.LogicalAnd, typeof(bool)),
        new BinaryOperator(SyntaxKind.PipeToken, BinaryOperatorKind.LogicalOr, typeof(bool)),
        new BinaryOperator(SyntaxKind.EqualEqualToken, BinaryOperatorKind.Equals, typeof(bool)),
        new BinaryOperator(SyntaxKind.BangEqualToken, BinaryOperatorKind.NotEquals, typeof(bool)),
    };

    public SyntaxKind SyntaxKind { get; }
    public object OperatorKind { get; }
    public object LeftType { get; }
    public object RightType { get; }
    public object ResultType { get; }

    public static BinaryOperator Bind(SyntaxKind syntaxKind, Type leftType, Type rightType)
    {
        foreach (var op in _operators)
        {
            if (op.SyntaxKind == syntaxKind && op.LeftType == leftType && op.RightType == rightType)
                return op;
        }
        return null!;
    }

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
}
