using Figures.Core.Base.Validation.Interfaces;
using Figures.Core.Math.Interfaces;

namespace Figures.Core.Base.Validation;

/// <inheritdoc />
public class SidesNotLessOrEqualZeroFigureValidator<TMeasure>
    : IFigureValidator<TMeasure> where TMeasure : IComparable<TMeasure>
{
    public void Validate(IReadOnlyCollection<MeasureWrapper<TMeasure>> sides)
    {
        var isAnySideLengthLessOrEqualZeroExists = sides.Any(length =>
        {
            var compareResult = length.CompareTo(MeasureWrapper<TMeasure>.ZeroValue);

            return compareResult == 0 || compareResult < 0;
        });

        if (isAnySideLengthLessOrEqualZeroExists)
        {
            throw new ArgumentException("Ни одна из длин сторон не может быть отрицательной или равной нулю!");
        }
    }
}