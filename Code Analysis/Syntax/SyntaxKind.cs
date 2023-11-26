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
    ElseKeyword,
    PredefinedFunctionKeyword,
    ThenKeyword,

    //Expressions
}