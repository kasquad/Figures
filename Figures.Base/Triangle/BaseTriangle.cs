using Figures.Base.Triangle.Validators;
using Figures.Core.Base;
using Figures.Core.Base.Interfaces;
using Figures.Core.Base.Validation.Interfaces;
using Figures.Core.Math.Interfaces;

namespace Figures.Base.Triangle;

public abstract class BaseTriangle<TMeasure>
    : BaseFigure<TMeasure> where TMeasure : IComparable<TMeasure>
{
    protected readonly MeasureWrapper<TMeasure> ASide;
    protected readonly MeasureWrapper<TMeasure> BSide;
    protected readonly MeasureWrapper<TMeasure> CSide;

    /// <summary>
    /// При создании треугольника проводится проверка на то, что аргументы неотрицательные,
    /// треугольник с такими сторонами может существовать.
    /// </summary>
    /// <param name="sides">Стороны треугольника</param>
    /// <param name="existsValidator"></param>
    /// <exception cref="ArgumentException"></exception>
    protected BaseTriangle(
        IReadOnlyCollection<MeasureWrapper<TMeasure>> sides,
        TriangleExistsValidator<TMeasure> existsValidator)
        : base(
            sides,
            new[] { existsValidator })
    {
        var orderedSides = GetOrderedSides(sides);

        (ASide, BSide, CSide) = (orderedSides.aSide, orderedSides.bSide, orderedSides.cSide);

        IsRectangular = IsRectangularBySides(ASide, BSide, CSide);
    }

    /// <summary>
    /// Доля, при умножении на которую число уменьшится вдвое.
    /// </summary>
    protected abstract MeasureWrapper<TMeasure> HalfFraction { get; }

    public override TMeasure GetArea()
    {
        if (IsRectangular)
            return BSide.Multiply(CSide).Multiply(HalfFraction).ToValue();
        
        // Полупериметр
        var p = ASide.Add(BSide).Add(CSide).Multiply(HalfFraction);

        return p.Multiply(p.Sub(ASide)).Multiply(p.Sub(BSide)).Multiply(p.Sub(CSide)).Sqrt().ToValue();
    }

    /// <summary>
    /// Свойство показывает, является ли треугольник прямоугольным.
    /// </summary>
    public bool IsRectangular { get; }

    private static (MeasureWrapper<TMeasure> aSide, MeasureWrapper<TMeasure> bSide, MeasureWrapper<TMeasure> cSide)
        GetOrderedSides(IReadOnlyCollection<MeasureWrapper<TMeasure>> sides)
    {
        var s1 = sides.ElementAt(0);
        var s2 = sides.ElementAt(1);
        var s3 = sides.ElementAt(2);

        MeasureWrapper<TMeasure> aSide = s1.CompareTo(s2) > 0 ? s1 : s2;
        MeasureWrapper<TMeasure> bSide;
        MeasureWrapper<TMeasure> cSide;

        if (s3.CompareTo(aSide) < 0)
        {
            bSide = s1.CompareTo(aSide) == 0 ? s2 : s1;
            cSide = s3;
        }
        else
        {
            aSide = s3;
            bSide = s1;
            cSide = s2;
        }

        return (aSide, bSide, cSide);
    }

    private static bool IsRectangularBySides(
        MeasureWrapper<TMeasure> aSide,
        MeasureWrapper<TMeasure> bSide,
        MeasureWrapper<TMeasure> cSide)
    {
        return aSide.Multiply(aSide).Equals(bSide.Multiply(bSide).Add(cSide.Multiply(cSide)));
    }
}