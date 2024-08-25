using Figures.Core.Base.Interfaces;
using Figures.Core.Math.Interfaces;

namespace Figures.Core.Base.Validation.Interfaces;

public interface IFigureValidator<TMeasure>
{
    void Validate(IReadOnlyCollection<MeasureWrapper<TMeasure>> sides);
}