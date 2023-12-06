public enum ExpressionKind
{
    // Expressions
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
    SubtractionExpression,
    DivisionExpression,
    EqualsExpression,
    ExponentiationExpression,
    GreaterEqualExpression,
    LessEqualExpression,
    LessExpression,
    LogicalAndExpression,
    LogicalOrExpression,
    MultiplicationExpression,
    NotEqualExpression,
    RemainderExpression,

    // Unary Expressions
    IdentityExpression,
    LogicalNegationExpression,
    NegationExpression,
    SequenceLiteralExpression,
}