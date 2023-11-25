namespace SintaxFacts
{

    public static class SyntaxFacts
        {
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
                switch (text)
                {
                    case "let": 
                        return SyntaxKind.LetKeyword;
                    case "in":
                        return SyntaxKind.InKeyword;
                    case "if":
                        return SyntaxKind.IfKeyword;
                    case "else":
                        return SyntaxKind.ElseKeyword;
                    case "sqrt":
                    case "print":
                    case "rand":
                    case "exp":
                    case "sen":
                    case "cos":
                    case "tan":
                    case "cot":
                    case "log":
                        return SyntaxKind.PredefinedFunctionKeyword;
                    default:
                        return SyntaxKind.IdentifierToken;
                }
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
                switch (kind)
                {
                    case SyntaxKind.PlusToken:
                        return "+";
                    case SyntaxKind.MinusToken:
                        return "-";
                    case SyntaxKind.StarToken:
                        return "*";
                    case SyntaxKind.DivToken:
                        return "/";
                    case SyntaxKind.PercentToken:
                        return "%";
                    case SyntaxKind.CircumflexToken:
                        return "^";
                    case SyntaxKind.AtToken:
                        return "@";
                    case SyntaxKind.EqualsToken:
                        return "=";
                    case SyntaxKind.BangToken:
                        return "!";
                    case SyntaxKind.AmpersandToken:
                        return "&";
                    case SyntaxKind.PipeToken:
                        return "|";
                    case SyntaxKind.EqualEqualToken:
                        return "==";
                    case SyntaxKind.BangEqualToken:
                        return "!=";
                    case SyntaxKind.OpenParenthesisToken:
                        return "(";
                    case SyntaxKind.CloseParenthesisToken:
                        return ")";
                    case SyntaxKind.FalseKeyword:
                        return "false";
                    case SyntaxKind.TrueKeyword:
                        return "true";
                    case SyntaxKind.GreaterEqualToken:
                        return ">=";
                    case SyntaxKind.LessEqualToken:
                        return "<=";
                    case SyntaxKind.LessToken:
                        return "<";
                    case SyntaxKind.GreaterToken:
                        return ">";
                    default:
                        return null;
                }
           }
        }
}