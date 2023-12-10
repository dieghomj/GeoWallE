using System.Collections;

public class LexerEnumerator : IEnumerator<SyntaxToken>
{
    private bool isNotMoved = true;
    private SyntaxToken _current = null!;
    private readonly Lexer _lex;
    private bool isAtEnd = false;

    public LexerEnumerator(Lexer lex)
    {
        _lex = lex;
    }

    public SyntaxToken Current
    {
        get
        {
            if (isAtEnd || isNotMoved)
                throw new Exception("is not possible to get the current enumerator");

            if (_current.Kind == SyntaxKind.EndOfFileToken)
                isAtEnd = true;

            return _current;
        }
    }

    object IEnumerator.Current => Current;

    public void Dispose() { }

    public bool MoveNext()
    {
        if (isAtEnd)
            return false;

        isNotMoved = false;
        _current = _lex.Lex();

        if (_current.Kind is SyntaxKind.WhiteSpaceToken or SyntaxKind.EndOfLineToken)
            return MoveNext();

        return true;
    }

    public void Reset() { }
}
