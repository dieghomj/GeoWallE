public class Measure : GObject
{
    public Measure(float value)
    {
        this.value = value;
    }

    public Measure(Point a, Point b)
    {
        float x = a.Position.x - b.Position.x;
        float y = a.Position.y - b.Position.y;
        value = MathF.Sqrt(x * x + y * y);
    }

    private GType Type = GType.Measure;
    private float value;
    public float Value => float.Round(value);
    public override GType GetGType() => Type;

    public override object GetValue() => value;

    public override bool IsTrue()
    {
        if (Value == 0)
            return true;
        return false;
    }

    public override string ToString() => Value.ToString();

    #region Arithmetic Operators

    public static Measure operator +(Measure a, Measure b) => new Measure(a.Value + b.Value);

    public static Measure operator -(Measure a, Measure b) =>
        new Measure(float.Abs(a.Value - b.Value));

    public static Measure operator *(Measure a, Number b)
    {
        float value = (float)b.GetValue();
        value = float.Abs(value);
        int number = (int)value;

        return new Measure(a.Value * number);
    }

    public static Measure operator *(Number b, Measure a)
    {
        float value = (float)b.GetValue();
        value = float.Abs(value);
        int number = (int)value;

        return new Measure(a.Value * number);
    }

    public static Number operator /(Measure a, Measure b) => new Number((int)(a.Value / b.Value));

    #endregion

    #region Comparison Operators

    public static Number operator <(Measure a, Measure b)
    {
        if (a.Value < b.Value)
            return new Number(1);
        else
            return new Number(0);
    }

    public static Number operator >(Measure a, Measure b)
    {
        if (a.Value > b.Value)
            return new Number(1);
        else
            return new Number(0);
    }

    public static Number operator <=(Measure a, Measure b)
    {
        if (a.Value <= b.Value)
            return new Number(1);
        else
            return new Number(0);
    }

    public static Number operator >=(Measure a, Measure b)
    {
        if (a.Value >= b.Value)
            return new Number(1);
        else
            return new Number(0);
    }

    public static Number operator ==(Measure a, Measure b)
    {
        if (a.Value == b.Value)
            return new Number(1);
        else
            return new Number(0);
    }

    public static Number operator !=(Measure a, Measure b)
    {
        if (a.Value != b.Value)
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
