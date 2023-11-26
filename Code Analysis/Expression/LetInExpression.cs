public class LetInExpression : Expression
{
    public LetInExpression(List<Expression> assignments, Expression expression)
    {
        Assignments = assignments;
        Expression = expression;
    }

    public override SyntaxKind Kind => SyntaxKind.LetInExpression;
    public IEnumerable<Expression> Assignments { get; }
    public Expression Expression { get; }

    public override Func<object> Evaluate => throw new NotImplementedException();

    public override Func<Type> Bind => throw new NotImplementedException();

    public override Type Type => throw new NotImplementedException();
}
