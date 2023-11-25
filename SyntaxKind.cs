public enum SyntaxKind
{
    EndOfFileToken,
    BadToken,
    WhiteSpaceToken,
    NumberToken,
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
    GreaterToken,S
    AmpersandToken,
    PipeToken,
    EqualsToken,
    BangToken,

    //Keywords
    TrueKeyword,
    FalseKeyword,
    LetKeyword,
    InKeyword,
    IfKeyword,
    ElseKeyword,
    PredefinedFunctionKeyword,
}