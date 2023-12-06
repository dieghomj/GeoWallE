using System.Reflection.Emit;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

public class Parser
{
    private readonly SyntaxToken[] _tokens;
    private string _text;
    private int _position;

    public Parser(string text)
    {
        _text = text;
        Lexer lexer = new Lexer(text);
        _tokens = lexer.ToArray();
    }

    private SyntaxToken Peek(int offset)
    {
        var index = _position + offset;
        if (index >= _tokens.Length)
            return _tokens[_tokens.Length - 1];
        return _tokens[index];
    }

    private SyntaxToken Current => Peek(0);
    private SyntaxToken LookAhead => Peek(1);

    private SyntaxToken NextToken()
    {
        var current = Current;
        _position++;
        return current;
    }

    private SyntaxToken Match(SyntaxKind kind)
    {
        if (Current.Kind == kind)
            return NextToken();

        NextToken();

        Console.WriteLine($"Error: Unexpected token <{Current.Text}");
        return new SyntaxToken(kind, Current.Position, Current.Text, null);
    }

    public List<Statement> Parse()
    {
        List<Statement> statementsList = new List<Statement>();

        while (Current.Kind == SyntaxKind.ImportKeyword)
            statementsList.Add(ParseImportStatement());

        while (Current.Kind != SyntaxKind.EndOfFileToken)
        {
            statementsList.Add(ParseStatement());
            Match(SyntaxKind.EndOfStatementToken);
        }

        return statementsList;
    }

    #region ParseStatements

    private Statement ParseImportStatement()
    {
        NextToken();
        return new ImportStatement(ParseExpression());
    }

    private Statement ParseStatement()
    {
        switch (Current.Kind)
        {
            case SyntaxKind.ColorKeyword:
                return ParseColorStatement();
            case SyntaxKind.RestoreKeyword:
                NextToken();
                return new RestoreStatement();
            case SyntaxKind.DrawKeyword:
                return ParseDrawStatement();
            default:
                return ParseExpression();
        }
    }

    private Statement ParseDrawStatement()
    {
        return new DrawStatement(ParseExpression());
    }

    private Statement ParseColorStatement()
    {
        NextToken();

        if (SyntaxFacts.ColorList.Contains(Current.Kind))
            return new ColorStatement(NextToken().Kind);

        System.Console.WriteLine("!SYNTAX ERROR: Expected color");
        NextToken();
        return null!;
    }

    #endregion

    #region ParseExpressions

    private Expression ParseExpression()
    {
        return ParseBinaryExpression();
    }

    private Expression ParseBinaryExpression(int parentPrecedence = 0)
    {
        Expression left;
        var unaryPrecedence = UnaryOperator.GetPrecedence(Current.Kind);
        if (unaryPrecedence != 0 && unaryPrecedence > parentPrecedence)
        {
            var op = NextToken();
            var operand = ParseBinaryExpression(unaryPrecedence);
            left = UnaryOperator.GetInstantiate(op, operand);
        }
        else
            left = ParserPrimaryExpression();

        while (true)
        {
            var binaryPrecedence = BinaryOperator.GetPrecedence(Current.Kind);
            if (binaryPrecedence != 0 || binaryPrecedence > parentPrecedence)
                break;

            var op = NextToken();
            var right = ParseBinaryExpression(binaryPrecedence);
            left = BinaryOperator.GetInstantiate(left, op, right);
        }

        return left;
    }

    private Expression ParserPrimaryExpression()
    {
        if (SyntaxFacts.PredefinedFunctionKeywords.Contains(Current.Kind))
            return ParsePredefinedFunction();

        switch (Current.Kind)
        {
            case SyntaxKind.OpenParenthesisToken:
                return ParseParenthesizedExpression();

            case SyntaxKind.IfKeyword:
                return ParseIfElseExpression();

            case SyntaxKind.LetKeyword:
                return ParseLetInExpression();

            case SyntaxKind.IdentifierToken:
            {
                if (LookAhead.Kind == SyntaxKind.OpenParenthesisToken)
                    return ParseFunctionExpression();
                else
                    return new NameExpression(NextToken());
            }

            case SyntaxKind.StringToken:
                return ParseLiteral();

            case SyntaxKind.NumberToken:
                return ParseLiteral();

            case SyntaxKind.OpenBracketToken:
                return ParseSequenceLiteral();

            default:
                System.Console.WriteLine("SINTAX ERROR!: ");
                return ParseLiteral();
        }
    }

    #region ParseExpressionFunctions

    private Expression ParseParenthesizedExpression()
    {
        Match(SyntaxKind.OpenParenthesisToken);

        Expression parenthesizedExpression = ParseExpression();

        Match(SyntaxKind.CloseParenthesisToken);

        return parenthesizedExpression;
    }

    private Expression ParseIfElseExpression()
    {
        Expression condition,
            trueExpression,
            falseExpression;

        Match(SyntaxKind.IfKeyword);

        condition = ParseExpression();

        Match(SyntaxKind.ThenKeyword);

        trueExpression = ParseExpression();

        Match(SyntaxKind.ElseKeyword);

        falseExpression = ParseExpression();

        return new IfElseExpression(condition, trueExpression, falseExpression);
    }

    private Expression ParseLetInExpression()
    {
        List<Statement> instructions = new List<Statement>();
        Expression inExpression;

        Match(SyntaxKind.LetKeyword);

        while (Current.Kind != SyntaxKind.InKeyword)
        {
            instructions.Add(ParseStatement());
        }

        Match(SyntaxKind.InKeyword);

        inExpression = ParseExpression();

        return new LetInExpression(instructions, inExpression);
    }

    private Expression ParseFunctionExpression()
    {
        throw new NotImplementedException();
    }

    private Expression ParseFunctionCallExpression()
    {
        throw new NotImplementedException();
    }

    private Expression ParseSequenceLiteral()
    {
        throw new NotImplementedException();
    }

    private Expression ParseLiteral()
    {
        SyntaxToken literalToken = NextToken();
        return new LiteralExpression(literalToken, literalToken.Value);
    }

    private Expression ParsePredefinedFunction()
    {
        SyntaxToken functionToken = NextToken();
        List<Expression> arguments = new();

        Match(SyntaxKind.OpenParenthesisToken);

        while (Current.Kind != SyntaxKind.CloseParenthesisToken)
        {
            Expression argument = ParseExpression();
            arguments.Add(argument);

            if (Current.Kind != SyntaxKind.CloseParenthesisToken)
                Match(SyntaxKind.CommaToken);
        }

        Match(SyntaxKind.CloseParenthesisToken);

        return new PredefinedFunctionExpression(functionToken, arguments);
    }

    #endregion

    #endregion
}
