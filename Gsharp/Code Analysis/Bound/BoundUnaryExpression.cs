public abstract class BoundUnaryExpression : BoundExpression
{
    public BoundUnaryExpression(BoundExpression operand, GType operatorType)
    {
        Operand = operand;
        OperatorType = operatorType;
    }

    protected BoundUnaryExpression(BoundExpression operand)
    {
        Operand = operand;
    }

    public abstract UnaryOperatorKind OperatorKind { get; }
    public override GType Type => OperatorType ;
    protected Func<object,object> Calculate => UnaryOperator.GetOperatorFunc(OperatorKind);
    public BoundExpression Operand { get; }
    protected GType OperatorType { get; }

    public override object Evaluate()
    {
        var operand = Operand.Evaluate();
        return Calculate(operand);
    }
}