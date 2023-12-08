public class BoundUnaryOperator
{
    public BoundUnaryOperator(SyntaxKind kind, UnaryOperatorKind operatorKind, GType operandType)
    {
        SyntaxKind = kind;
        OperatorKind = operatorKind;
        OperandType = operandType;
    }
    public SyntaxKind SyntaxKind { get; }
    public UnaryOperatorKind OperatorKind { get; }
    public GType OperandType { get; }

    private static BoundUnaryOperator[] _operators = 
    {
        new BoundUnaryOperator(SyntaxKind.BangToken, UnaryOperatorKind.LogicalNegation, GType.Number),
        new BoundUnaryOperator(SyntaxKind.PlusToken, UnaryOperatorKind.Identity, GType.Number),
        new BoundUnaryOperator(SyntaxKind.MinusToken, UnaryOperatorKind.Negation, GType.Number),
    };

    public static BoundUnaryOperator Bind(SyntaxKind syntaxKind, GType operandType)
    {
        foreach(var op in _operators)
        {
            if((op.SyntaxKind == syntaxKind && op.OperandType == operandType) || operandType == GType.Undefined)
                return op;
        }

        return null;
    }
}