using System.Runtime.CompilerServices;

public static class BinaryOperator
{
    private static Dictionary<BinaryOperatorKind, Func<GObject, GObject, GObject>> OperatorFunc =
        new Dictionary<BinaryOperatorKind, Func<GObject, GObject, GObject>>
        {
            { BinaryOperatorKind.Addition, Addition },
            { BinaryOperatorKind.Subtraction, Subtraction },
            { BinaryOperatorKind.Multiplication, Multiplication },
            { BinaryOperatorKind.Division, Division },
            { BinaryOperatorKind.Remainder, Remainder },
            { BinaryOperatorKind.Exponentiation, Exponentiation },
            { BinaryOperatorKind.LogicalAnd, LogicalAnd },
            { BinaryOperatorKind.LogicalOr, LogicalOr },
            { BinaryOperatorKind.Equals, Equals },
            { BinaryOperatorKind.NotEquals, NotEquals },
            { BinaryOperatorKind.GreaterEqual, GreaterEqual },
            { BinaryOperatorKind.LessEqual, LessEqual },
            { BinaryOperatorKind.Greater, Greater },
            { BinaryOperatorKind.Less, Less },
        };

    private static Dictionary<
        SyntaxKind,
        Func<Expression, Expression, Expression>
    > InstantiateFunc = new Dictionary<SyntaxKind, Func<Expression, Expression, Expression>>()
    {
        {
            SyntaxKind.PlusToken,
            (Expression left, Expression right) => new AdditionExpression(left, right)
        },
        {
            SyntaxKind.MinusToken,
            (Expression left, Expression right) => new SubtractionExpression(left, right)
        },
        {
            SyntaxKind.StarToken,
            (Expression left, Expression right) => new MultiplicationExpression(left, right)
        },
        {
            SyntaxKind.DivToken,
            (Expression left, Expression right) => new DivisionExpression(left, right)
        },
        {
            SyntaxKind.PercentToken,
            (Expression left, Expression right) => new RemainderExpression(left, right)
        },
        {
            SyntaxKind.CircumflexToken,
            (Expression left, Expression right) => new ExponentiationExpression(left, right)
        },
        {
            SyntaxKind.AmpersandToken,
            (Expression left, Expression right) => new LogicalAndExpression(left, right)
        },
        {
            SyntaxKind.PipeToken,
            (Expression left, Expression right) => new LogicalOrExpression(left, right)
        },
        {
            SyntaxKind.EqualEqualToken,
            (Expression left, Expression right) => new EqualsExpression(left, right)
        },
        {
            SyntaxKind.BangEqualToken,
            (Expression left, Expression right) => new NotEqualsExpression(left, right)
        },
        {
            SyntaxKind.GreaterEqualToken,
            (Expression left, Expression right) => new GreaterEqualExpression(left, right)
        },
        {
            SyntaxKind.LessEqualToken,
            (Expression left, Expression right) => new LessEqualExpression(left, right)
        },
        {
            SyntaxKind.GreaterToken,
            (Expression left, Expression right) => new GreaterExpression(left, right)
        },
        {
            SyntaxKind.LessToken,
            (Expression left, Expression right) => new LessExpression(left, right)
        },
    };

    public static Func<GObject, GObject, GObject> GetOperatorFunc(
        BinaryOperatorKind operatorKind
    ) => OperatorFunc[operatorKind];

    /// <summary>
    ///
    /// </summary>
    /// <param name="left"></param>
    /// <param name="op"></param>
    /// <param name="right"></param>
    /// <returns>Una nueva instancia de BinaryExpression</returns>
    public static Expression GetInstantiate(Expression left, SyntaxToken op, Expression right) =>
        InstantiateFunc[op.Kind](left, right);

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

    #region Binary Evaluations
    private static GObject Equals(GObject left, GObject right)
    {
        throw new NotImplementedException();
    }
    private static GObject NotEquals(GObject left, GObject right)
    {
        throw new NotImplementedException();
    }
    private static GObject Addition(GObject left, GObject right)
    {
        throw new NotImplementedException();
    }

    private static GObject Subtraction(GObject left, GObject right)
    {
        throw new NotImplementedException();
    }

    private static GObject Multiplication(GObject left, GObject right)
    {
        throw new NotImplementedException();
    }

    private static GObject Division(GObject left, GObject right)
    {
        throw new NotImplementedException();
    }

    private static GObject Remainder(GObject left, GObject right)
    {
        throw new NotImplementedException();
    }

    private static GObject Exponentiation(GObject left, GObject right)
    {
        throw new NotImplementedException();
    }

    private static GObject LogicalAnd(GObject left, GObject right)
    {
        throw new NotImplementedException();
    }

    private static GObject LogicalOr(GObject left, GObject right)
    {
        throw new NotImplementedException();
    }

    private static GObject GreaterEqual(GObject left, GObject right)
    {
        throw new NotImplementedException();
    }

    private static GObject LessEqual(GObject left, GObject right)
    {
        throw new NotImplementedException();
    }

    private static GObject Greater(GObject left, GObject right)
    {
        throw new NotImplementedException();
    }

    private static GObject Less(GObject left, GObject right)
    {
        throw new NotImplementedException();
    }
    #endregion
}
