using System.Reflection.Emit;
using System.Runtime.CompilerServices;

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
        return null;
    }

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
            var operand = ParseBinaryExpression(unaryPrecedence);
            var op = NextToken();
            left = ParseUnaryOperator(op, operand);
        }
        else
            left = ParserPrimaryExpression();

        while (true)
        {
            var binaryPrecedence = BinaryOperator.GetPrecedence(Current.Kind);
            if (binaryPrecedence != 0 || binaryPrecedence > parentPrecedence)
                break;

            var right = ParseBinaryExpression(binaryPrecedence);
            var op = NextToken();
            left = ParseBinaryOperator(left, op, right);
        }

        return left;
    }

    private Expression ParserPrimaryExpression()
    {
        switch (Current.Kind)
        {
            case SyntaxKind.OpenParenthesisToken:
                return ParseParenthesizedExpression();

            case SyntaxKind.StringToken:
                return ParseStringLiteral();

            case SyntaxKind.IdentifierToken:
            {
                if (Peek(1).Kind == SyntaxKind.OpenParenthesisToken)
                    return ParseFunctionExpression();
                else
                    return ParseNameExpression();
            }
            case SyntaxKind.LetKeyword:
                return ParseLetInExpression();
            case SyntaxKind.IfKeyword:
                return ParseIfElseExpression();

            case SyntaxKind.PredefinedFunctionKeyword:
                return ParsePredefinedFunction();

            default:
                return ParseNumberLiteral();
        }
    }

    private Expression ParseNameExpression()
    {
        throw new NotImplementedException();
    }

    private Expression ParseNumberLiteral()
    {
        throw new NotImplementedException();
    }

    private Expression ParseStringLiteral()
    {
        throw new NotImplementedException();
    }

    private Expression ParseParenthesizedExpression()
    {
        throw new NotImplementedException();
    }

    private Expression ParseAssignmentExpression()
    {
        throw new NotImplementedException();
    }

    private Expression ParseUnaryOperator(SyntaxToken op, Expression operand)
    {
        throw new NotImplementedException();
    }

    private Expression ParseBinaryOperator(Expression left, SyntaxToken op, Expression right)
    {
        throw new NotImplementedException();
    }

    private Expression ParseIfElseExpression()
    {
        throw new NotImplementedException();
    }

    private Expression ParseLetInExpression()
    {
        throw new NotImplementedException();
    }

    private Expression ParsePredefinedFunction()
    {
        throw new NotImplementedException();
    }

    private Expression ParseFunctionExpression()
    {
        throw new NotImplementedException();
    }

    private Expression ParseFunctionCallExpression()
    {
        throw new NotImplementedException();
    }
}
