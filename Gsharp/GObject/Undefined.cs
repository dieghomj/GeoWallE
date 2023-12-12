public class Undefined : GObject
{
    public Undefined() { }

    private GType Type = GType.Undefined;

    public override GType GetGType() => Type;

    public override object GetValue()
    {
        throw new NotImplementedException();
    }

    public override bool IsTrue() => false;

    public override string ToString() => "Undefined";

    #region Binary Operators
    
    public static Sequence<GObject> operator +(Sequence<GObject> a, Undefined b) => a;

    public static Undefined operator +(Undefined a, GObject b) => new Undefined();

    public static Undefined operator -(Undefined a, GObject b) => new Undefined();

    public static Undefined operator /(Undefined a, GObject b) => new Undefined();

    public static Undefined operator *(Undefined a, GObject b) => new Undefined();

    public static Undefined operator %(Undefined a, GObject b) => new Undefined();

    public static Undefined operator ^(Undefined a, GObject b) => new Undefined();

    public static Undefined operator &(Undefined a, GObject b) => new Undefined();

    public static Undefined operator |(Undefined a, GObject b) => new Undefined();

    public static Undefined operator <(Undefined a, GObject b) => new Undefined();

    public static Undefined operator >(Undefined a, GObject b) => new Undefined();

    public static Undefined operator <=(Undefined a, GObject b) => new Undefined();

    public static Undefined operator >=(Undefined a, GObject b) => new Undefined();

    public static Undefined operator ==(Undefined a, GObject b) => new Undefined();

    public static Undefined operator !=(Undefined a, GObject b) => new Undefined();

    public static Undefined operator +(GObject a, Undefined b) => new Undefined();

    public static Undefined operator -(GObject a, Undefined b) => new Undefined();

    public static Undefined operator /(GObject a, Undefined b) => new Undefined();

    public static Undefined operator *(GObject a, Undefined b) => new Undefined();

    public static Undefined operator %(GObject a, Undefined b) => new Undefined();

    public static Undefined operator ^(GObject a, Undefined b) => new Undefined();

    public static Undefined operator &(GObject a, Undefined b) => new Undefined();

    public static Undefined operator |(GObject a, Undefined b) => new Undefined();

    public static Undefined operator <(GObject a, Undefined b) => new Undefined();

    public static Undefined operator >(GObject a, Undefined b) => new Undefined();

    public static Undefined operator <=(GObject a, Undefined b) => new Undefined();

    public static Undefined operator >=(GObject a, Undefined b) => new Undefined();

    public static Undefined operator ==(GObject a, Undefined b) => new Undefined();

    public static Undefined operator !=(GObject a, Undefined b) => new Undefined();

    #endregion

    #region Unary Operators

    public static Undefined operator +(Undefined a) => new Undefined();

    public static Undefined operator -(Undefined a) => new Undefined();

    public static Undefined operator !(Undefined a) => new Undefined();

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
