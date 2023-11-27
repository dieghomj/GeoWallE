public enum SyntaxKind
{
    EndOfFileToken,
    EndOfStatementToken,
    BadToken,
    WhiteSpaceToken,
    NumberToken,
    StringToken,
    IdentifierToken,
    OpenParenthesisToken,
    CloseParenthesisToken,

    //Operators
    PlusToken,
    MinusToken,
    StarToken,
    DivToken,
    PercentToken,
    CircumflexToken,
    AtToken,
    EqualEqualToken,
    BangEqualToken,
    GreaterEqualToken,
    LessEqualToken,
    LessToken,
    GreaterToken,
    AmpersandToken,
    PipeToken,
    EqualsToken,
    BangToken,

    //Keywords
    LetKeyword,
    InKeyword,
    IfKeyword,
    ThenKeyword,
    ElseKeyword,
    ConstantKeyword,
    PredefinedFunctionKeyword,

    //Expressions
    LiteralExpression,
    NameExpression,
    UnaryExpression,
    BinaryExpression,
    ParenthesizedExpression,
    AssignmentExpression,
    LetInExpression,
    IfElseExpression,
    FunctionCallExpression,
    FunctionDeclarationExpression,
    PredefinedFunctionExpression,

    // Binary Expression
    AdditionExpression,
    SubtractionExpression
}
