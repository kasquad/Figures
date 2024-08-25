using Figures.Core.Base.Interfaces;
using Figures.Core.Base.Validation;
using Figures.Core.Base.Validation.Interfaces;
using Figures.Core.Math.Interfaces;

namespace Figures.Core.Base;

public abstract class BaseFigure<TMeasure> : IFigure<TMeasure> where TMeasure : IComparable<TMeasure>
{
    protected readonly IReadOnlyCollection<MeasureWrapper<TMeasure>> SidesSide;

    /// <summary>
    /// В конструкторе базового класса проводится проверка на то, что параметры фигуры являются больше нуля
    /// </summary>
    /// <param name="sides">Параметры фигуры</param>
    /// <param name="validators"></param>
    /// <exception cref="ArgumentException"></exception>
    protected BaseFigure(
        IReadOnlyCollection<MeasureWrapper<TMeasure>> sides,
        IFigureValidator<TMeasure>[]? validators = null)
    {
        var sidesValidator = new SidesNotLessOrEqualZeroFigureValidator<TMeasure>();
        
        sidesValidator.Validate(sides);

        if (validators != null)
        {
            foreach (var figureValidator in validators)
            {
                figureValidator.Validate(sides);
            }
        }

        SidesSide = sides;
    }

    public abstract TMeasure GetArea();
}