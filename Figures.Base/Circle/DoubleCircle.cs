using Figures.Base.MeasureWrappers;
using Figures.Core.Base;
using Figures.Core.Math.Interfaces;

namespace Figures.Base.Circle;

public class DoubleCircle : BaseFigure<double>
{
    private readonly MeasureWrapper<double> _radius;

    public DoubleCircle(double radius) : base(new DoubleMeasureWrapper[] { new(radius) })
    {
        _radius = SidesSide.First();
    }

    public override double GetArea() => Math.PI * _radius.ToValue() * _radius.ToValue();
}