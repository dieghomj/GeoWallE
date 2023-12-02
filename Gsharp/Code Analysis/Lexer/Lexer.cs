using System.Collections;

public sealed class Lexer : IEnumerable<SyntaxToken>
{
    private readonly string _text;
    private int _position;
    private int _start;
    private SyntaxKind _kind;
    private object? _value;

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
        _value = null;

        if (Current == '\0')
        {
            _kind = SyntaxKind.EndOfFileToken;
        }
        else if (char.IsWhiteSpace(Current))
        {
            Next();
            _kind = SyntaxKind.WhiteSpaceToken;
        }
        else if (char.IsDigit(Current))
        {
            ReadNumber();
        }
        else if (char.IsLetter(Current) || Current == '_')
        {
            ReadKeyword();
        }
        else if (Current == '\"')
        {
            ReadString();
        }
        else if (Operators.OperatorTokens.ContainsKey(Current.ToString()))
        {
            ReadOperator();
        }
        else
        {
            System.Console.WriteLine("LEXICAL ERROR");
            Next();
        }

        var length = _position - _start;
        //El metodo GetText() deberia retornar el texto =para todo token que tenga un texto fijo. Por ejemplos los operadores ( +, -, =, ...)
        var text = Operators.GetText(_kind);

        if (text == null)
            text = _text.Substring(_start, length);

        return new SyntaxToken(_kind, _start, text, _value);
    }

    private void ReadNumber()
    {
        while (char.IsDigit(Current) || Current == '.')
            Next();

        var length = _position - _start;
        var text = _text.Substring(_start, length);

        //Si no se puede parsear como un numero explota.
        if (!double.TryParse(text, out var value))
        {
            Console.WriteLine($"! LEXICAL ERROR: `{text}` is not a NUMBER");
        }

        _value = value;
        _kind = SyntaxKind.NumberToken;
    }

    private void ReadKeyword()
    {
        while (char.IsLetterOrDigit(Current) || Current == '_')
            Next();

        var length = _position - _start;
        var text = _text.Substring(_start, length);

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
            System.Console.WriteLine(("LEXICAL ERROR"));
        }
        else
        {
            Next();

            var length = _position - _start - 2;

            string value = _text.Substring(_start + 1, length);
            value = value.Replace("\\\"", "\"");
            value = value.Replace("\\t", "\t");
            value = value.Replace("\\n", "\n");
            value = value.Replace("\\\\", "\\");

            _value = value;
            _kind = SyntaxKind.StringToken;
        }
    }

    private void ReadOperator()
    {
        var operatorText = Current.ToString();
        while (Operators.OperatorTokens.ContainsKey(operatorText + LookAhead))
        {
            operatorText += LookAhead;
            Next();
        }
        Next();
        _kind = Operators.OperatorTokens[operatorText];
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
