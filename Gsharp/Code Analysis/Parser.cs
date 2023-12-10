public class Parser
{
    private readonly SyntaxToken[] _tokens;
    private string _text;
    private int _position;

    /// <summary>
    /// Inicializa un analizador sintactico para un codigo en el lenguaje Gsharp
    /// </summary>
    /// <param name="text"></param>
    public Parser(string text)
    {
        _text = text;
        Lexer lexer = new Lexer(text);
        _tokens = lexer.ToArray();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="offset"></param>
    /// <returns>Retorna _tokens[position + offset] </returns>
    private SyntaxToken Peek(int offset)
    {
        var index = _position + offset;
        if (index >= _tokens.Length)
            return _tokens[_tokens.Length - 1];
        return _tokens[index];
    }

    /// <summary>
    /// Contiene el token actual
    /// </summary>
    private SyntaxToken Current => Peek(0);

    /// <summary>
    /// Contiene el token siguiente
    /// </summary>
    private SyntaxToken LookAhead => Peek(1);

    /// <summary>
    /// Mueve al siguiente token
    /// </summary>
    /// <returns>Devuelve el token actual antes de moverse</returns>
    private SyntaxToken NextToken()
    {
        var current = Current;
        _position++;
        return current;
    }

    /// <summary>
    /// Verifica si el token actual es del tipo kind
    /// </summary>
    /// <param name="kind"></param>
    /// <returns>Devuelve el token requerido</returns>
    private SyntaxToken Match(SyntaxKind kind)
    {
        if (Current.Kind == kind)
            return NextToken();

        NextToken();

        Console.WriteLine($"Error: Unexpected token <{Current.Text}>");
        return new SyntaxToken(kind, Current.Position, Current.Text);
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns>Devuelve una lista de ImportStatement</returns>
    public List<ImportStatement> GetImportStatements()
    {
        List<ImportStatement> importStatements = new List<ImportStatement>();
        while (Current.Kind == SyntaxKind.ImportKeyword)
        {
            Match(SyntaxKind.ImportKeyword);
            importStatements.Add(new ImportStatement(ParseStringLiteral()));
            Match(SyntaxKind.EndOfStatementToken);
        }
        return importStatements;
    }

    /// <summary>
    /// Analiza sintacticamente un codigo en el lenguaje Gsharp
    /// </summary>
    /// <returns>Una lista de Statement</returns>
    public List<Statement> Parse()
    {
        List<Statement> statementsList = new List<Statement>();

        while (Current.Kind != SyntaxKind.EndOfFileToken)
        {
            statementsList.Add(ParseStatement());

            Match(SyntaxKind.EndOfStatementToken);
        }

        return statementsList;
    }

    #region ParseStatements

    private Statement ParseStatement()
    {
        if (
            SyntaxFacts.DeclarationKeywords.Contains(Current.Kind)
            && LookAhead.Kind != SyntaxKind.OpenParenthesisToken
        )
        {
            if (LookAhead.Kind == SyntaxKind.SequenceKeyword)
                return ParseDeclarationSequenceStatement();
            else
                return ParseDeclarationStatement();
        }

        switch (Current.Kind)
        {
            case SyntaxKind.ColorKeyword:
                return ParseColorStatement();
            case SyntaxKind.RestoreKeyword:
                return ParseRestoreStatement();
            case SyntaxKind.DrawKeyword:
                return ParseDrawStatement();
            case SyntaxKind.IdentifierToken:
                switch (LookAhead.Kind)
                {
                    case SyntaxKind.OpenParenthesisToken:
                        return ParseFunctionDeclarationStatement();
                    case SyntaxKind.EqualsToken:
                        return ParseAssignmentStatement();
                    case SyntaxKind.CommaToken:
                        return ParseMatchStatement();
                    default:
                        return ParseExpression();
                }
            case SyntaxKind.UnderscoreToken:
                return ParseMatchStatement();
            case SyntaxKind.PrintKeyword:
                return ParsePrintStatement();
            default:
                return ParseExpression();
        }
    }

    private Statement ParsePrintStatement()
    {
        Match(SyntaxKind.PrintKeyword);

        return new PrintStatement(ParseExpression());
    }

    private Statement ParseDeclarationStatement()
    {
        SyntaxToken keywordToken = NextToken();

        SyntaxToken nameToken = Match(SyntaxKind.IdentifierToken);

        return new DeclarationStatement(keywordToken, nameToken);
    }

    private Statement ParseDeclarationSequenceStatement()
    {
        SyntaxToken keywordToken = NextToken();

        Match(SyntaxKind.SequenceKeyword);

        SyntaxToken nameToken = Match(SyntaxKind.IdentifierToken);

        return new DeclarationSequenceStatement(keywordToken, nameToken);
    }

    private Statement ParseMatchStatement()
    {
        List<SyntaxToken> nameTokens = new();
        while (Current.Kind != SyntaxKind.EqualsToken)
        {
            if (Current.Kind == SyntaxKind.UnderscoreToken)
                nameTokens.Add(Match(SyntaxKind.UnderscoreToken));
            else
                nameTokens.Add(Match(SyntaxKind.IdentifierToken));

            if (Current.Kind != SyntaxKind.EqualsToken)
                nameTokens.Add(Match(SyntaxKind.CommaToken));
        }

        Match(SyntaxKind.EqualsToken);

        Expression rightExpression = ParseExpression();

        return new MatchStatement(nameTokens, rightExpression);
    }

    private Statement ParseAssignmentStatement()
    {
        SyntaxToken nameToken = Match(SyntaxKind.IdentifierToken);

        Match(SyntaxKind.EqualsToken);

        Expression rightExpression = ParseExpression();

        return new AssignmentStatement(nameToken, rightExpression);
    }

    private Statement ParseFunctionDeclarationStatement()
    {
        SyntaxToken functionToken = Match(SyntaxKind.IdentifierToken);

        Match(SyntaxKind.OpenParenthesisToken);

        List<SyntaxToken> parameters = new();

        while (Current.Kind != SyntaxKind.CloseParenthesisToken)
        {
            SyntaxToken parameter = Match(SyntaxKind.IdentifierToken);
            parameters.Add(parameter);

            if (Current.Kind != SyntaxKind.CloseParenthesisToken)
                Match(SyntaxKind.CommaToken);
        }

        Match(SyntaxKind.CloseParenthesisToken);

        Match(SyntaxKind.EqualsToken);

        Expression functionExpression = ParseExpression();

        return new FunctionDeclarationStatement(functionToken, parameters, functionExpression);
    }

    private Statement ParseRestoreStatement()
    {
        Match(SyntaxKind.RestoreKeyword);
        return new RestoreStatement();
    }

    private Statement ParseDrawStatement()
    {
        Match(SyntaxKind.DrawKeyword);

        Expression figure = ParseExpression();

        if (Current.Kind == SyntaxKind.StringToken)
            return new DrawStatement(figure, ParseExpression());
        else
            return new DrawStatement(figure);
    }

    private Statement ParseColorStatement()
    {
        Match(SyntaxKind.ColorKeyword);

        if (SyntaxFacts.ColorList.ContainsKey(Current.Kind))
            return new ColorStatement(SyntaxFacts.ColorList[NextToken().Kind]);

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
        if (unaryPrecedence != 0 && unaryPrecedence >= parentPrecedence)
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
            if (binaryPrecedence == 0 || binaryPrecedence <= parentPrecedence)
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
                    return ParseFunctionCallExpression();
                else
                    return ParseNameExpression();
            }

            case SyntaxKind.StringToken:
                return ParseStringLiteral();

            case SyntaxKind.NumberToken:
                return ParseNumberLiteral();

            case SyntaxKind.OpenBracketToken:
                return ParseSequenceLiteral();

            default:
                System.Console.WriteLine("! SYNTAX ERROR : ");
                return ParseNumberLiteral();
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

            Match(SyntaxKind.EndOfStatementToken);
        }

        Match(SyntaxKind.InKeyword);

        inExpression = ParseExpression();

        return new LetInExpression(instructions, inExpression);
    }

    private Expression ParseSequenceLiteral()
    {
        Match(SyntaxKind.OpenBracketToken);

        if (LookAhead.Kind == SyntaxKind.EllipsisToken)
        {
            Expression start = ParseNumberLiteral();

            Match(SyntaxKind.EllipsisToken);

            if (Current.Kind == SyntaxKind.CloseBracketToken)
            {
                Match(SyntaxKind.CloseBracketToken);
                return new SequenceLiteralExpression(start);
            }
            else
            {
                Expression end = ParseNumberLiteral();
                Match(SyntaxKind.CloseBracketToken);
                return new SequenceLiteralExpression(start, end);
            }
        }
        else
        {
            List<Expression> elements = new List<Expression>();
            while (Current.Kind != SyntaxKind.CloseBracketToken)
            {
                Expression element = ParseExpression();

                elements.Add(element);

                if (Current.Kind != SyntaxKind.CloseBracketToken)
                    Match(SyntaxKind.CommaToken);
            }

            Match(SyntaxKind.CloseBracketToken);

            return new SequenceLiteralExpression(elements);
        }
    }

    private Expression ParseNumberLiteral()
    {
        SyntaxToken literalToken = Match(SyntaxKind.NumberToken);
        return new LiteralExpression(literalToken, double.Parse(literalToken.Text));
    }

    private Expression ParseStringLiteral()
    {
        SyntaxToken literalToken = Match(SyntaxKind.StringToken);

        string value = literalToken.Text[1..^1];
        value = value.Replace("\\\"", "\"");
        value = value.Replace("\\t", "\t");
        value = value.Replace("\\n", "\n");
        value = value.Replace("\\\\", "\\");

        return new LiteralExpression(literalToken, value);
    }

    private Expression ParseNameExpression()
    {
        return new NameExpression(Match(SyntaxKind.IdentifierToken));
    }

    private Expression ParseFunctionCallExpression()
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

        return new FunctionCallExpression(functionToken, arguments);
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
