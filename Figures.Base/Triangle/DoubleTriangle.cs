using Figures.Base.MeasureWrappers;
using Figures.Base.Triangle.Validators;
using Figures.Core.Base;
using Figures.Core.Base.Interfaces;
using Figures.Core.Base.Validation.Interfaces;
using Figures.Core.Math.Interfaces;

namespace Figures.Base.Triangle;

public class DoubleTriangle : BaseTriangle<double>
{
    public DoubleTriangle(
        double s1, double s2, double s3)
        : base(
            new DoubleMeasureWrapper[]{ new(s1), new (s2), new (s3)},
            new TriangleExistsValidator<double>())
    {
    }

    protected override MeasureWrapper<double> HalfFraction => new DoubleMeasureWrapper(1/2d);
}