class BoundBinaryOperator
{
    public SyntaxKind SyntaxKind { get; }
    private BoundBinaryOperator(SyntaxKind syntaxKind, BinaryOperatorKind kind, GType type)
        : this(syntaxKind, kind, type, type, type) { }

    private BoundBinaryOperator(
        SyntaxKind syntaxKind,
        BinaryOperatorKind kind,
        GType type,
        GType resultType
    )
        : this(syntaxKind, kind, type, type, resultType) { }

    public BoundBinaryOperator(
        SyntaxKind kind,
        BinaryOperatorKind operatorKind,
        GType leftType,
        GType rightType,
        GType resultType
    )
    {
        SyntaxKind = kind;
        OperatorKind = operatorKind;
        LeftType = leftType;
        RightType = rightType;
        ResultType = resultType;
    }
    public BinaryOperatorKind OperatorKind { get; }
    public GType LeftType { get; }
    public GType RightType { get; }
    public GType ResultType { get; }

    public static BoundBinaryOperator Bind(SyntaxKind syntaxKind, GType leftType, GType rightType)
    {
        foreach (var op in _operators)
        {
            if (op.SyntaxKind == syntaxKind && op.LeftType == leftType && op.RightType == rightType)
                return op;
        }
        return null!;
    }
    private static BoundBinaryOperator[] _operators =
    {
        //Number Operators
        new BoundBinaryOperator(SyntaxKind.PlusToken, BinaryOperatorKind.Addition, GType.Number),
        new BoundBinaryOperator(SyntaxKind.MinusToken, BinaryOperatorKind.Subtraction, GType.Number),
        new BoundBinaryOperator(SyntaxKind.StarToken, BinaryOperatorKind.Multiplication, GType.Number),
        new BoundBinaryOperator(SyntaxKind.DivToken, BinaryOperatorKind.Division, GType.Number),
        new BoundBinaryOperator(SyntaxKind.PercentToken, BinaryOperatorKind.Remainder, GType.Number),
        new BoundBinaryOperator(
            SyntaxKind.CircumflexToken,
            BinaryOperatorKind.Exponentiation,
            GType.Number
        ),
        new BoundBinaryOperator(
            SyntaxKind.EqualEqualToken,
            BinaryOperatorKind.Equals,
            GType.Number,
            GType.Number
        ),
        new BoundBinaryOperator(
            SyntaxKind.BangEqualToken,
            BinaryOperatorKind.NotEquals,
            GType.Number,
            GType.Number
        ),
        new BoundBinaryOperator(
            SyntaxKind.GreaterToken,
            BinaryOperatorKind.Greater,
            GType.Number,
            GType.Number
        ),
        new BoundBinaryOperator(
            SyntaxKind.LessToken,
            BinaryOperatorKind.Less,
            GType.Number,
            GType.Number
        ),
        new BoundBinaryOperator(
            SyntaxKind.GreaterEqualToken,
            BinaryOperatorKind.GreaterEqual,
            GType.Number,
            GType.Number
        ),
        new BoundBinaryOperator(
            SyntaxKind.LessEqualToken,
            BinaryOperatorKind.LessEqual,
            GType.Number,
            GType.Number
        ),
        //String Operators
        new BoundBinaryOperator(
            SyntaxKind.EqualEqualToken,
            BinaryOperatorKind.Equals,
            GType.String,
            GType.Number
        ),
        new BoundBinaryOperator(
            SyntaxKind.BangEqualToken,
            BinaryOperatorKind.NotEquals,
            GType.String,
            GType.Number
        ),
        //Bool Operators
        new BoundBinaryOperator(SyntaxKind.AmpersandToken, BinaryOperatorKind.LogicalAnd, GType.Number),
        new BoundBinaryOperator(SyntaxKind.PipeToken, BinaryOperatorKind.LogicalOr, GType.Number),
        new BoundBinaryOperator(SyntaxKind.EqualEqualToken, BinaryOperatorKind.Equals, GType.Number),
        new BoundBinaryOperator(SyntaxKind.BangEqualToken, BinaryOperatorKind.NotEquals, GType.Number),
    };

}
