public static class SyntaxFacts
{
    public static Dictionary<string,SyntaxKind> OperatorTokens = new Dictionary<string,SyntaxKind>
    {
        {";",SyntaxKind.EndOfFileToken},
        {"+",SyntaxKind.PlusToken},
        {"-",SyntaxKind.MinusToken},
        {"*",SyntaxKind.StarToken},
        {"/",SyntaxKind.DivToken},
        {"%",SyntaxKind.PercentToken},
        {"^",SyntaxKind.CircumflexToken},
        {"@",SyntaxKind.AtToken},
        {"=",SyntaxKind.EqualsToken},
        {"!",SyntaxKind.BangToken},
        {"&",SyntaxKind.AmpersandToken},
        {"|",SyntaxKind.PipeToken},
        {"==",SyntaxKind.EqualEqualToken},
        {"!=",SyntaxKind.BangEqualToken},
        {"(",SyntaxKind.OpenParenthesisToken},
        {")",SyntaxKind.CloseParenthesisToken},
        {">=",SyntaxKind.GreaterEqualToken},
        {"<=",SyntaxKind.LessEqualToken},
        {"<",SyntaxKind.LessToken},
        {">",SyntaxKind.GreaterToken},
    };
    public static Dictionary<string,SyntaxKind> Keywords = new Dictionary<string,SyntaxKind>
    {
        {"if",SyntaxKind.IfKeyword},
        {"else",SyntaxKind.ElseKeyword},
        {"then",SyntaxKind.ThenKeyword},
        {"let",SyntaxKind.LetKeyword},
        {"in",SyntaxKind.InKeyword},
        {"samples",SyntaxKind.PredefinedFunctionKeyword},
        {"points",SyntaxKind.PredefinedFunctionKeyword},
        {"randoms",SyntaxKind.PredefinedFunctionKeyword},
        {"count",SyntaxKind.PredefinedFunctionKeyword},
        {"measure",SyntaxKind.PredefinedFunctionKeyword},
        {"arc",SyntaxKind.PredefinedFunctionKeyword},
        {"intersect",SyntaxKind.PredefinedFunctionKeyword},

    };
    public static int GetUnaryOperatorPrecedence(this SyntaxKind kind)
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
    public static int GetBinaryOperatorPrecedence(this SyntaxKind kind)
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

    public static SyntaxKind GetKeyWordKind(string text)
    {
        if(Keywords.ContainsKey(text))
            return Keywords[text];
        else 
            return SyntaxKind.IdentifierToken;
    }
    public static IEnumerable<SyntaxKind> GetBinaryOperatorKinds()
    {
        var kinds = (SyntaxKind[])Enum.GetValues(typeof(SyntaxKind));
        foreach (var kind in kinds)
        {
            if (GetBinaryOperatorPrecedence(kind) > 0)
                yield return kind;
        }
    }
    public static IEnumerable<SyntaxKind> GetUnaryOperatorKinds()
    {
        var kinds = (SyntaxKind[])Enum.GetValues(typeof(SyntaxKind));
        foreach (var kind in kinds)
        {
            if (GetUnaryOperatorPrecedence(kind) > 0)
                yield return kind;
        }
    }
    public static string GetText(SyntaxKind kind)
    {
        if(OperatorTokens.ContainsValue(kind))
            return OperatorTokens.Keys.First(k => OperatorTokens[k] == kind);
        else 
            return null;
    }
}