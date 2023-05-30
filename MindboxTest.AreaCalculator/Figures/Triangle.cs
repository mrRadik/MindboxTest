using System.Text;
using MindboxTest.AreaCalculator.Interfaces;
using MindboxTest.AreaCalculator.Validators;

namespace MindboxTest.AreaCalculator.Figures;

public class Triangle : BaseFigureValidator<Triangle>, IFigure
{
    private static TriangleValidator validator;
    private readonly double[] _sides;
    private Lazy<bool> _isRightTriangle => new(GetIsRightTriangle);
    internal double SideA { get; }
    internal double SideB { get; }
    internal double SideC { get; }
    
    public bool IsRightTriangle => _isRightTriangle.Value;

    public Triangle(double sideA, double sideB, double sideC) 
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;

        ValidateParameters(new TriangleValidator(),this);

        _sides = new[] { SideA, SideB, SideC };
    }
    double IFigure.CalculateArea()
    {
        var semiPerimeter = GetSemiPerimeter(SideA, SideB, SideC);
        
        return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) 
                         * (semiPerimeter - SideC));
    }

    private bool GetIsRightTriangle()
    {
        Array.Sort(_sides);

        return Math.Pow(_sides[2], 2).Equals(Math.Pow(_sides[0], 2) + Math.Pow(_sides[1], 2));
    }
    
    private static double GetSemiPerimeter(double a, double b, double c)
    {
        return (a + b + c) / 2;
    }
}