public abstract class UnaryExpression : Expression
{
    protected UnaryExpression(Expression operand)
    {
        Operand = operand;
    }

    public SyntaxKind OperatorKind { get; }
    public Expression Operand { get; }
    public override GType Bind(Dictionary<string, GType> visibleVariables)
    {
        var operandType = Operand.Bind(visibleVariables);
        var op = BoundUnaryOperator.Bind(OperatorKind,operandType);
        if(op == null)
        {
            System.Console.WriteLine($"! SEMANTIC ERROR : Unary operator {Operators.GetText(OperatorKind)} is not defined for {operandType}");
            return GType.Undefined;
        }
        else
            return op.OperandType;
    }
}
