public static class SyntaxFacts
{
    /// TODO: faltan : () ;
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
            if (BinaryOperator.GetPrecedence(kind) > 0)
                yield return kind;
        }
    }
    public static IEnumerable<SyntaxKind> GetUnaryOperatorKinds()
    {
        var kinds = (SyntaxKind[])Enum.GetValues(typeof(SyntaxKind));
        foreach (var kind in kinds)
        {
            if (UnaryOperator.GetPrecedence(kind) > 0)
                yield return kind;
        }
    }
}
