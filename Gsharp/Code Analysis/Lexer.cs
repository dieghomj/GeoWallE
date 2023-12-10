using System.Collections;

public sealed class Lexer : IEnumerable<SyntaxToken>
{
    private readonly string _text;
    private int _start;
    private int _position;
    private SyntaxKind _kind;

    public Lexer(string line)
    {
        _text = line;
    }

    /// <summary>
    /// Pasa el puntero a la siguiente posicion.
    /// </summary>
    private void Next() => _position++;

    /// <summary>
    /// Da el caracter en la posicion actual.
    /// </summary>
    /// <returns></returns>
    private char Current => Peek(0);

    /// <summary>
    /// Retorna el caracter en la siguiente posicion.
    /// </summary> <summary>
    ///
    /// </summary>
    /// <returns></returns>
    private char LookAhead => Peek(1);

    /// <summary>
    /// Retorna el caracter en _position + offset. No mueve el puntero.
    /// </summary>
    /// <param name="offset"></param>
    /// <returns>
    /// Retorna _text[_position+offset] y en caso de no ser posible retorna '\0'.
    /// </returns>
    ///
    /// completing
    private char Peek(int offset)
    {
        int index = _position + offset;
        if (index >= _text.Length)
            return '\0';
        return _text[index];
    }

    /// <summary>
    /// Analiza lexicamente la linea de codigo y retorna el siguiente token.
    /// </summary>
    /// <returns></returns>
    public SyntaxToken Lex()
    {
        _start = _position;
        _kind = SyntaxKind.BadToken;

        if (Current == '\0')
        {
            _kind = SyntaxKind.EndOfFileToken;
        }
        else if (Current == '\n')
        {
            Next();
            _kind = SyntaxKind.EndOfLineToken;
        }
        else if (char.IsWhiteSpace(Current))
        {
            Next();
            _kind = SyntaxKind.WhiteSpaceToken;
        }
        else if (Current == '\\' && LookAhead == '\\')
        {
            ReadComment();
        }
        else if (char.IsDigit(Current))
        {
            ReadNumber();
        }
        else if (
            char.IsLetter(Current)
            || (Current == '_' && (char.IsLetter(LookAhead) || LookAhead == '_'))
        )
        {
            ReadKeywordOrIdentifier();
        }
        else if (Current == '\"')
        {
            ReadString();
        }
        else if (Operators.IsOperatorPrefix(Current.ToString()))
        {
            ReadOperator();
        }
        else if (Symbols.IsSymbolPrefix(Current.ToString()))
        {
            ReadSymbol();
        }
        else
        {
            System.Console.WriteLine("LEXICAL ERROR");
            Next();
        }

        int length = _position - _start;
        string text = _text.Substring(_start, length);

        return new SyntaxToken(_kind, _start, text);
    }

    private void ReadComment()
    {
        while (Current != '\n' || Current != '\0')
            Next();

        if (Current == '\n')
            Next();

        _kind = SyntaxKind.CommentaryToken;
    }

    private void ReadNumber()
    {
        while (char.IsDigit(Current) || Current == '.')
            Next();

        int length = _position - _start;
        string text = _text.Substring(_start, length).Replace('.', ',');

        //Si no se puede parsear como un numero explota.
        if (!double.TryParse(text, out var value))
        {
            Console.WriteLine($"! LEXICAL ERROR: `{text}` is not a NUMBER");
        }

        _kind = SyntaxKind.NumberToken;
    }

    private void ReadKeywordOrIdentifier()
    {
        while (char.IsLetterOrDigit(Current) || Current == '_')
            Next();

        int length = _position - _start;
        string text = _text.Substring(_start, length);

        _kind = SyntaxFacts.GetKeyWordKind(text);
    }

    private void ReadString()
    {
        Next();
        while (Current != '\"' && Current != '\0')
        {
            if (Current == '\\')
                Next();
            Next();
        }

        if (Current == '\0')
        {
            System.Console.WriteLine("!LEXICAL ERROR: Expected character <\">");
        }
        else
        {
            Next();
            _kind = SyntaxKind.StringToken;
        }
    }

    private void ReadOperator()
    {
        string operatorText = Current.ToString();
        while ((operatorText + LookAhead).IsOperatorPrefix())
        {
            operatorText += LookAhead;
            Next();
        }
        Next();

        if (Operators.OperatorTokens.ContainsKey(operatorText))
            _kind = Operators.OperatorTokens[operatorText];
    }

    private void ReadSymbol()
    {
        string symbolText = Current.ToString();
        while (Symbols.IsSymbolPrefix(symbolText + LookAhead))
        {
            symbolText += LookAhead;
            Next();
        }
        Next();

        if (Symbols.SymbolTokens.ContainsKey(symbolText))
            _kind = Symbols.SymbolTokens[symbolText];
    }

    public IEnumerator<SyntaxToken> GetEnumerator()
    {
        return new LexerEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
