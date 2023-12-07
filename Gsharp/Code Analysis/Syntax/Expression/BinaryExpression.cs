using System.Xml.XPath;

public abstract class BinaryExpression : Expression
{
    protected GType ResultType;
    public BinaryExpression(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }

    public abstract SyntaxKind OperatorKind { get; }
    public Expression Left { get; }
    public Expression Right { get; }

    public override GType Bind(Dictionary<string, GType> visibleVariables)
    {
        IsBinded = true;
        
        var leftType = Left.Bind(visibleVariables);
        var rightType = Right.Bind(visibleVariables);
        //  op => Operator
        var op = BoundBinaryOperator.Bind(OperatorKind, leftType, rightType);
        ResultType = op.ResultType;
        if (op == null)
        {
            System.Console.WriteLine("! SEMANTIC ERROR: Binary operator not defined");
            return GType.Undefined;
        }
        else
            return op.ResultType;
    }
}
