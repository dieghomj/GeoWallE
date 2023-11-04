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
    /// retorna el caracter en la siguiente posicion.
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
    private char Peek(int offset)
    {
        int index = _position + offset;
        if (index >= _text.Length)
            return '\0';
        return _text[index];
    }


    /// <summary>
    /// Analiza sintactimenta la linea de codigo y retorna el siguiente token.
    /// </summary>
    /// <returns></returns>
    public SyntaxToken Lex()
    {
        
        _start = _position;
        _kind = SyntaxKind.BadToken;
        _value = null;


        if(char.IsWhiteSpace(Current))
        {
            Next();
            _kind = SyntaxKind.WhiteSpaceToken;
            return new SyntaxToken(_kind,_start," "," ");
        }
        else if(char.IsDigit(Current))
        {
            ReadNumber();
        }else if(Current == '\0')
        {
            _kind = SyntaxKind.EndOfFileToken;
            return new SyntaxToken(_kind,_start,null,null);
        }

        //El metodo GetText() deberia retornar el texto para todo token que tenga un texto fijo. Por ejemplos los operadores ( +, -, =, ...) 
        // var text = SyntaxFacts.GetText();
        
        var length = _position - _start;
        
        //Esto asignacion solo deberia ocurrir si text es null
        var text = _text.Substring(_start,length);

        return new SyntaxToken(_kind, _start, text, _value);
    }

    private void ReadNumber()
    {
        while (char.IsDigit(Current) || (Current == '.' && LookAhead != '.'))
            Next();
        var length = _position - _start;
        var text = _text.Substring(_start, length);

        //Si no se puede parser como un numero explota.
        if (!double.TryParse(text, out var value))
        {
            Console.WriteLine($"! SYNTAX ERROR: `{text}` is not a NUMBER");
        }

        _value = value;
        _kind = SyntaxKind.NumberToken;
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
