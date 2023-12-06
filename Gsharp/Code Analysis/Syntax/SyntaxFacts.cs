public static class SyntaxFacts
{
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
        { "sequence", SyntaxKind.SequenceKeyword },
        { "blue", SyntaxKind.BlueKeyword },
        { "red", SyntaxKind.RedKeyword },
        { "yellow", SyntaxKind.YellowKeyword },
        { "green", SyntaxKind.GreenKeyword },
        { "cyan", SyntaxKind.CyanKeyword },
        { "magenta", SyntaxKind.MagentaKeyword },
        { "white", SyntaxKind.WhiteKeyword },
        { "gray", SyntaxKind.GrayKeyword },
        { "black", SyntaxKind.BlackKeyword },
    };

    public static List<SyntaxKind> DeclarationKeywords =
        new()
        {
            SyntaxKind.PointKeyword,
            SyntaxKind.LineKeyword,
            SyntaxKind.SegmentKeyword,
            SyntaxKind.RayKeyword,
            SyntaxKind.CircleKeyword
        };

    public static List<SyntaxKind> PredefinedFunctionKeywords =
        new()
        {
            SyntaxKind.LineKeyword,
            SyntaxKind.SegmentKeyword,
            SyntaxKind.RayKeyword,
            SyntaxKind.ArcKeyword,
            SyntaxKind.CircleKeyword,
            SyntaxKind.MeasureKeyword,
            SyntaxKind.IntersectKeyword,
            SyntaxKind.CountKeyword,
            SyntaxKind.RandomsKeyword,
            SyntaxKind.PointsKeyword,
            SyntaxKind.SamplesKeyword,
        };

    public static Dictionary<SyntaxKind, Color> ColorList = new Dictionary<SyntaxKind, Color>
    {
        { SyntaxKind.BlueKeyword, Color.Blue },
        { SyntaxKind.RedKeyword, Color.Red },
        { SyntaxKind.YellowKeyword, Color.Yellow },
        { SyntaxKind.GreenKeyword, Color.Green },
        { SyntaxKind.CyanKeyword, Color.Cyan },
        { SyntaxKind.MagentaKeyword, Color.Magenta },
        { SyntaxKind.WhiteKeyword, Color.White },
        { SyntaxKind.GrayKeyword, Color.Gray },
        { SyntaxKind.BlackKeyword, Color.Black }
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
