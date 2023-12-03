public class Symbols
{
    public static Dictionary<string, SyntaxKind> SymbolTokens = new Dictionary<string, SyntaxKind>
    {
        { "(", SyntaxKind.OpenParenthesisToken },
        { ")", SyntaxKind.CloseParenthesisToken },
        { "{", SyntaxKind.OpenBracketToken },
        { "}", SyntaxKind.CloseBracketToken },
        { ";", SyntaxKind.SemicolonToken },
        { ",", SyntaxKind.CommaToken },
        { "...", SyntaxKind.EllipsisToken },
        { "_", SyntaxKind.UnderscoreToken }, 
    };

    public static string? GetText(SyntaxKind kind)
    {
        if (SymbolTokens.ContainsValue(kind))
            return SymbolTokens.Keys.First(k => SymbolTokens[k] == kind);
        else
            return null;
    }

    /// <summary>
    /// Verifica si una candena es prefijo de algun simbolo
    /// </summary>
    /// <param name="prefix"></param>
    /// <returns> Verdadero si y solo si prefix es un prefijo de algun simbolo</returns>
    public static bool IsSymbolPrefix(string prefix)
    {
        foreach (var symbolString in SymbolTokens.Keys)
        {
            string symbolPrefix = "";
            for (int i = 0; i < symbolString.Length; ++i)
            {
                symbolPrefix += symbolString[i];
                if (symbolPrefix == prefix)
                    return true;
            }
        }

        return false;
    }
}
