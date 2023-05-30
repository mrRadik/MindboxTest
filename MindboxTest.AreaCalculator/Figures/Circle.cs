using System.Text;
using MindboxTest.AreaCalculator.Interfaces;
using MindboxTest.AreaCalculator.Validators;

namespace MindboxTest.AreaCalculator.Figures;

public class Circle : BaseFigureValidator<Circle>, IFigure
{
    internal double Radius { get; }
    
    public Circle(double radius)
    {
        Radius = radius;
        
        ValidateParameters(new CircleValidator(), this);
    }

    double IFigure.CalculateArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}