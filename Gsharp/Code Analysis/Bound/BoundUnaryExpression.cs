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
    protected BoundExpression Operand { get; }
    protected GType OperatorType { get; }
    public override GType Type => OperatorType;
}
