namespace Figures.Core.Math.Interfaces;

public abstract class MeasureWrapper<TMeasure> :
    IEquatable<MeasureWrapper<TMeasure>>,
    IComparable
{
    protected MeasureWrapper(TMeasure value)
    {
        Value = value;
    }

    public TMeasure Value { get; }

    public static TMeasure ZeroValue => throw new NotImplementedException();

    public TMeasure ToValue() => Value;

    public abstract MeasureWrapper<TMeasure> Add(MeasureWrapper<TMeasure> value);

    public abstract MeasureWrapper<TMeasure> Sub(MeasureWrapper<TMeasure> value);

    public abstract MeasureWrapper<TMeasure> Multiply(MeasureWrapper<TMeasure> value);

    public abstract MeasureWrapper<TMeasure> Divide(MeasureWrapper<TMeasure> value);
    
    public abstract MeasureWrapper<TMeasure> Sqrt();

    public abstract bool Equals(MeasureWrapper<TMeasure>? other);

    public abstract int CompareTo(object? obj);
}