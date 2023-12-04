public abstract class BinaryExpression : Expression
{
    public BinaryExpression(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }

    public abstract SyntaxKind OperatorKind {get; }
    public Expression Left { get; }
    public Expression Right { get; }

    public override GType Bind(Dictionary<string, GType> visibleVariables)
    {
        var leftType = Left.Bind(visibleVariables);
        var rightType = Right.Bind(visibleVariables);
        //  op => Operator
        var op = BoundBinaryOperator.Bind(OperatorKind,  leftType, rightType);
        if( op == null)
        {
            System.Console.WriteLine("! SEMANTIC ERROR: Binary operator not defined");
            return GType.Undefined;
        }
        else return op.ResultType;
    }
}
