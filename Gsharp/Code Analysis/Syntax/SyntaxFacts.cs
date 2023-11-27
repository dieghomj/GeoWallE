public static class SyntaxFacts
{
    /// TODO: faltan : () ;
    public static Dictionary<string, SyntaxKind> Keywords = new Dictionary<string, SyntaxKind>
    {
        { "if", SyntaxKind.IfKeyword },
        { "else", SyntaxKind.ElseKeyword },
        { "then", SyntaxKind.ThenKeyword },
        { "let", SyntaxKind.LetKeyword },
        { "in", SyntaxKind.InKeyword },
        { "color", SyntaxKind.ColorKeyword },
        { "restore", SyntaxKind.RestoreKeyword },
        { "import", SyntaxKind.ImportKeyword },
        { "draw", SyntaxKind.DrawKeyword },
        { "line", SyntaxKind.LineKeyword },
        { "segment", SyntaxKind.SegmentKeyword },
        { "ray", SyntaxKind.RayKeyword },
        { "arc", SyntaxKind.ArcKeyword },
        { "circle", SyntaxKind.CircleKeyword },
        { "measure", SyntaxKind.MeasureKeyword },
        { "intersect", SyntaxKind.IntersectKeyword },
        { "count", SyntaxKind.CountKeyword },
        { "randoms", SyntaxKind.RandomsKeyword },
        { "points", SyntaxKind.PointsKeyword },
        { "samples", SyntaxKind.SamplesKeyword },
        { "point", SyntaxKind.PointKeyword },
        { "sequence", SyntaxKind.SequenceKeyword }
    };

    public static Dictionary<string, SyntaxKind> PredefinedFunctionKeywords =
        new()
        {
            { "line", SyntaxKind.PredefinedFunctionKeyword },
            { "segment", SyntaxKind.PredefinedFunctionKeyword },
            { "ray", SyntaxKind.PredefinedFunctionKeyword },
            { "arc", SyntaxKind.PredefinedFunctionKeyword },
            { "circle", SyntaxKind.PredefinedFunctionKeyword },
            { "measure", SyntaxKind.PredefinedFunctionKeyword },
            { "intersect", SyntaxKind.PredefinedFunctionKeyword },
            { "count", SyntaxKind.PredefinedFunctionKeyword },
            { "randoms", SyntaxKind.PredefinedFunctionKeyword },
            { "points", SyntaxKind.PredefinedFunctionKeyword },
            { "samples", SyntaxKind.PredefinedFunctionKeyword }
        };

    public static SyntaxKind GetKeyWordKind(string text)
    {
        if (Keywords.ContainsKey(text))
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
