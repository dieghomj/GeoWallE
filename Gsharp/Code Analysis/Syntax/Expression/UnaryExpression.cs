public abstract class UnaryExpression : Expression
{
    protected GType ResultType;

    protected UnaryExpression(Expression operand)
    {
        Operand = operand;
    }

    public abstract SyntaxKind OperatorKind { get; }
    public Expression Operand { get; }
    protected override GType BindExpression(Dictionary<string, GType> visibleVariables)
    {
        var operandType = Operand.Bind(visibleVariables);
        var op = BoundUnaryOperator.Bind(OperatorKind,operandType);
        if(op == null)
        {
            throw new Exception($"! SEMANTIC ERROR : Unary operator {Operators.GetText(OperatorKind)} is not defined for {operandType}");

        }
        else
            return op.OperandType;
    }
}
