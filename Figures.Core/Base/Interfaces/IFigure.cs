namespace Figures.Core.Base.Interfaces;

public interface IFigure<TMeasure>
{
    public abstract TMeasure GetArea();
}