using Figures.Core.Math.Interfaces;
using System;

namespace Figures.Base.MeasureWrappers;

public class DoubleMeasureWrapper : MeasureWrapper<double>
{
    public DoubleMeasureWrapper(double value) : base(value)
    {
    }

    public override MeasureWrapper<double> Add(MeasureWrapper<double> value)
    {
        return new DoubleMeasureWrapper(Value + value.ToValue());
    }

    public override MeasureWrapper<double> Sub(MeasureWrapper<double> value)
    {
        return new DoubleMeasureWrapper(Value - value.ToValue());
    }

    public override MeasureWrapper<double> Multiply(MeasureWrapper<double> value)
    {
        return new DoubleMeasureWrapper(Value * value.ToValue());
    }

    public override MeasureWrapper<double> Divide(MeasureWrapper<double> value)
    {
        if (value.Value == 0)
        {
            throw new DivideByZeroException();
        }

        return new DoubleMeasureWrapper(Value / value.ToValue());
    }

    public override MeasureWrapper<double> Sqrt()
    {
        return new DoubleMeasureWrapper(Math.Sqrt(Value));
    }

    public override bool Equals(MeasureWrapper<double>? other)
    {
        return Value.Equals(other?.Value);
    }

    public override int CompareTo(object? obj)
    {
        return Value.CompareTo((obj as MeasureWrapper<double>)?.Value);
    }
}