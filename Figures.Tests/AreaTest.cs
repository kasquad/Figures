using System.Collections.Generic;
using Xunit;

namespace Figures.Tests;

/// <summary>
/// Проверка метода площади треугольника и круга

/// </summary>
public class AreaTest
{
    [Fact]
    public void Test()
    {
        // Словарь для того, чтобы в тесте метод площади определялся типом фигуры
        Dictionary<Figure,double> figures = new Dictionary<Figure, double>()
        {
            {new Circle(5) ,78.539816339744830961566084581988},
            {new Circle(3.96),49.265199356533701648275788479236},
            {new Triangle(3,4,5),6},
            {new Triangle(4,3,5),6},
            {new Triangle(5,4,3),6},
            {new Triangle(3,10,8),9.9215674164922147143810590761472}
        };

        foreach (var kvp in figures)
        {
            Assert.Equal(kvp.Value,kvp.Key.GetArea());
        }
    }
}