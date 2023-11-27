public static class Operators
{
    public static Dictionary<string,SyntaxKind> OperatorTokens = new Dictionary<string,SyntaxKind>
    {
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
        {">=",SyntaxKind.GreaterEqualToken},
        {"<=",SyntaxKind.LessEqualToken},
        {"<",SyntaxKind.LessToken},
        {">",SyntaxKind.GreaterToken},
    };
    
    public static string GetText(SyntaxKind kind)
    {
        if(OperatorTokens.ContainsValue(kind))
            return OperatorTokens.Keys.First(k => OperatorTokens[k] == kind);
        else 
            return null;
    }

}
