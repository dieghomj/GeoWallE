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
            return _tokens[_tokens.Length];
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
        if (Current.Kind == kind) return NextToken();

        Console.WriteLine($"Error: Unexpected token <{Current.Text}");
        return new SyntaxToken(kind, Current.Position, Current.Text, null);
    }

    public SyntaxTree Parse()
    {
        var root = ParseStatement();
        return new SyntaxTree(root);
    }

    private Expression ParseStatement()
    {
        switch (Current.Kind)
        {
            case SyntaxKind.IdentifierToken:
                return ParseNameExpression();
            case SyntaxKind.LetKeyword:
                return ParseLetInExpression();
            case SyntaxKind.IfKeyword:
                return ParseIfElseExpression();
            case SyntaxKind.PredefinedFunctionKeyword:
                return ParsePredefinedFunction();
            default:
                Console.WriteLine($"Error:  Only assignment and call expression can be used as statement");
                return null;
        }
    }

    private Expression ParseExpression()
    {
        return ParseBinaryExpression();            
    }

    private Expression ParseBinaryExpression(int parentPrecedence = 0)
    {
        Expression left;
        var unaryPrecedence = UnaryOperator.GetPrecedence(Current.Kind);
        if(unaryPrecedence != 0 && unaryPrecedence > parentPrecedence)
        {
            var operand = ParseBinaryExpression(unaryPrecedence);
            var op = NextToken();
            left = ParseUnaryOperator(op,operand);
        }
        else 
            left = ParserPrimaryExpression();
        
        while(true)
        {
            var binaryPrecedence = BinaryOperator.GetPrecedence(Current.Kind);
            if(binaryPrecedence != 0 || binaryPrecedence > parentPrecedence)
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
                if(Peek(1).Kind == SyntaxKind.OpenParenthesisToken)
                    return ParseFunctionCallExpression();
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
    private Expression ParseFunctionCallExpression()
    {
        throw new NotImplementedException();
    }
}
