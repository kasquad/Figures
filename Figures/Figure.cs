namespace Figures;

public abstract class Figure
{
    /// <summary>
    /// В конструкторе базового класса проводится проверка на то, что параметры фигуры являются больше нуля
    /// </summary>
    /// <param name="lengths">Параметры фигуры</param>
    /// <exception cref="ArgumentException"></exception>
    public Figure(params double[] lengths)
    {
        foreach (var length in lengths)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Arguments or argument must be greater than 0");
            }
        }
    }
    public abstract double GetArea();
}