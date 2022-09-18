namespace Figures;

public class Circle : Figure
{
    private double _radius;
    
    public Circle(double radius) : base(radius)
    {
        _radius = radius;
    }

    public override double GetArea() => Math.PI * _radius * _radius;
}