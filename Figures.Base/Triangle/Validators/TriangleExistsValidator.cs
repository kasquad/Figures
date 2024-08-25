using Figures.Core.Base.Validation.Interfaces;
using Figures.Core.Math.Interfaces;

namespace Figures.Base.Triangle.Validators;

public class TriangleExistsValidator<TMeasure>
    : IFigureValidator<TMeasure>
{
    
    public void Validate(IReadOnlyCollection<MeasureWrapper<TMeasure>> value)
    {
        ValidateInternal(value);
    }

    private void ValidateInternal(in IReadOnlyCollection<MeasureWrapper<TMeasure>> sidesLength)
    {
        if (sidesLength.Count != 3)
        {
            throw new ArgumentException("У треугольника должно быть 3 стороны!");
        }

        var s1 = sidesLength.ElementAt(0);
        var s2 = sidesLength.ElementAt(1);
        var s3 = sidesLength.ElementAt(2);
        
        if (s1.CompareTo(s2.Add(s3)) >= 0 ||
            s2.CompareTo(s1.Add(s3)) >= 0 ||
            s3.CompareTo(s1.Add(s2)) >= 0)
        {
            throw new ArgumentException(
                "Треугольник с такими сторонами не может существовать!");
        }       
    }
}