public static class Operators
{
    public static Dictionary<string, SyntaxKind> OperatorTokens = new Dictionary<string, SyntaxKind>
    {
        { "+", SyntaxKind.PlusToken },
        { "-", SyntaxKind.MinusToken },
        { "*", SyntaxKind.StarToken },
        { "/", SyntaxKind.DivToken },
        { "%", SyntaxKind.PercentToken },
        { "^", SyntaxKind.CircumflexToken },
        { "@", SyntaxKind.AtToken },
        { "=", SyntaxKind.EqualsToken },
        { "!", SyntaxKind.BangToken },
        { "&", SyntaxKind.AmpersandToken },
        { "|", SyntaxKind.PipeToken },
        { "==", SyntaxKind.EqualEqualToken },
        { "!=", SyntaxKind.BangEqualToken },
        { ">=", SyntaxKind.GreaterEqualToken },
        { "<=", SyntaxKind.LessEqualToken },
        { "<", SyntaxKind.LessToken },
        { ">", SyntaxKind.GreaterToken },
    };

    public static string? GetText(SyntaxKind kind)
    {
        if (OperatorTokens.ContainsValue(kind))
            return OperatorTokens.Keys.First(k => OperatorTokens[k] == kind);
        else
            return null;
    }

    /// <summary>
    /// Verifica si una candena es prefijo de algun operador
    /// </summary>
    /// <param name="prefix"></param>
    /// <returns> Verdadero si y solo si prefix es un prefijo de algun operador</returns>
    public static bool IsOperatorPrefix(string prefix)
    {
        foreach (var operatorString in OperatorTokens.Keys)
        {
            string operatorPrefix = "";
            for (int i = 0; i < operatorString.Length; ++i)
            {
                operatorPrefix += operatorString[i];
                if (operatorPrefix == prefix)
                    return true;
            }
        }

        return false;
    }
}
