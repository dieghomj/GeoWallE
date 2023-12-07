public class Number : GObject
{
    public Number(double value)
    {
        Value = value;
    }

    private GType Type = GType.Number;
    private double Value;

    public override GType GetGType() => Type;

    public override object GetValue() => Value;

    #region Binary Operators

    public static Number operator +(Number a, Number b) => new Number(a.Value + b.Value);

    public static Number operator -(Number a, Number b) => new Number(a.Value - b.Value);

    public static Number operator /(Number a, Number b) => new Number(a.Value / b.Value);

    public static Number operator *(Number a, Number b) => new Number(a.Value * b.Value);

    public static Number operator %(Number a, Number b) => new Number(a.Value % b.Value);

    public static Number operator ^(Number a, Number b) => new Number(double.Pow(a.Value, b.Value));

    public static Number operator &(Number a, Number b)
    {
        if (a.Value != 0 && b.Value != 0)
            return new Number(1);
        else
            return new Number(0);
    }

    public static Number operator |(Number a, Number b)
    {
        if (a.Value != 0 || b.Value != 0)
            return new Number(1);
        else
            return new Number(0);
    }

    public static Number operator <(Number a, Number b)
    {
        if (a.Value < b.Value)
            return new Number(1);
        else
            return new Number(0);
    }

    public static Number operator >(Number a, Number b)
    {
        if (a.Value > b.Value)
            return new Number(1);
        else
            return new Number(0);
    }

    public static Number operator <=(Number a, Number b)
    {
        if (a.Value <= b.Value)
            return new Number(1);
        else
            return new Number(0);
    }

    public static Number operator >=(Number a, Number b)
    {
        if (a.Value >= b.Value)
            return new Number(1);
        else
            return new Number(0);
    }

    public static Number operator ==(Number a, Number b)
    {
        if (a.Value == b.Value)
            return new Number(1);
        else
            return new Number(0);
    }

    public static Number operator !=(Number a, Number b)
    {
        if (a.Value != b.Value)
            return new Number(1);
        else
            return new Number(0);
    }

    #endregion

    #region Unary Operators

    public static Number operator +(Number a) => new Number(a.Value);

    public static Number operator -(Number a) => new Number(-a.Value);

    public static Number operator !(Number a)
    {
        if (a.Value == 0)
            return new Number(1);
        else
            return new Number(0);
    }

    #endregion

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (ReferenceEquals(obj, null))
        {
            return false;
        }

        throw new NotImplementedException();
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}
