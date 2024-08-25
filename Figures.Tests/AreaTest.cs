using System.Collections.Generic;
using Figures.Base.Circle;
using Figures.Base.Triangle;
using Figures.Core.Base;
using Xunit;

namespace Figures.Tests;

/// <summary>
/// Проверка метода площади треугольника и круга.
/// </summary>
public class AreaTest
{
    [Fact]
    public void Test()
    {
        // Словарь для того, чтобы в тесте метод площади определялся типом фигуры.
        var figures = new Dictionary<BaseFigure<double>, double>
        {
            {new DoubleCircle(5) ,78.539816339744830961566084581988},
            {new DoubleCircle(3.96),49.265199356533701648275788479236},
            {new DoubleTriangle(3,4,5),6},
            {new DoubleTriangle(4,3,5),6},
            {new DoubleTriangle(5,4,3),6},
            {new DoubleTriangle(3,10,8),9.9215674164922147143810590761472}
        };

        foreach (var kvp in figures)
        {
            Assert.Equal(kvp.Value,kvp.Key.GetArea());
        }
    }
}