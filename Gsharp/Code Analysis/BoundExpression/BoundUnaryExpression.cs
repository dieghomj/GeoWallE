public abstract class BoundUnaryExpression : BoundExpression
{
    public BoundUnaryExpression(BoundExpression operand)
    {
        Operand = operand;
    }

    //Aqui creo que OperatorKind se deberia cambiar por OperatorToken o cambiar SyntaxKind por algun otro enum algo que describa mejor a OperatorKind
    public abstract UnaryOperatorKind OperatorKind { get; }
    public override GType Type => throw new NotImplementedException();
    protected Func<object,object> Calculate => UnaryOperator.GetOperatorFunc(OperatorKind);
    public BoundExpression Operand { get; }
    public override object Evaluate()
    {
        var operand = Operand.Evaluate();
        return Calculate(operand);
    }
}