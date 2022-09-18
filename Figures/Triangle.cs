namespace Figures;

public class Triangle : Figure
{
    private double _aSide,
        _bSide,
        _cSide;

    
    /// <summary>
    /// Переменная показывает, является ли треугольник прямоугольным
    /// </summary>
    private readonly bool _isRight;
    
    public bool IsRight => _isRight;

    /// <summary>
    /// При создании треугольника проводится проверка на то, что аргументы неотрицательные,
    /// треугольник с такими сторонами может существовать
    /// </summary>
    /// <param name="s1">Сторона треугольника</param>
    /// <param name="s2">Сторона треугольника</param>
    /// <param name="s3">Сторона треугольника</param>
    /// <exception cref="ArgumentException"></exception>
    public Triangle(double s1, double s2, double s3) : base(s1, s2, s3)
    {
        // Проверка на возможность существования треугольника
        if (s1 >= s2 + s3 ||
            s2 >= s1 + s3 ||
            s3 >= s1 + s2)
        {
            throw new ArgumentException("Invalid arguments for triangle");
        }

        // Следующий код позволяет установить в _aSide наибольшую сторону
         _aSide = s1 > s2 ?  s1 : s2;

         if (s3 < _aSide)
         {
             _bSide = _aSide.Equals(s1) ? s2 : s1;
             _cSide = s3;
         }
         else
         {
             _aSide = s3;
             _bSide = s1;
             _cSide = s2;
         }
         
         // Проверка на прямоугольность треугольника
         if((_aSide*_aSide).Equals(_bSide * _bSide + _cSide *_cSide))
         {
             _isRight = true;
         }

    }
 
    public override double GetArea()
    {
        if (_isRight)
            return 1d/ 2 * _bSide * _cSide;
        
        // Полупериметр
        var p = (_aSide + _bSide + _cSide)/2;

        return Math.Sqrt(p * (p - _aSide) * (p - _bSide) * (p - _cSide));
    }
}