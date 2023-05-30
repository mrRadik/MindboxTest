using FluentValidation;
using MindboxTest.AreaCalculator.Figures;

namespace MindboxTest.AreaCalculator.Validators;

internal class TriangleValidator : AbstractValidator<Triangle>
{
    internal TriangleValidator()
    {
        RuleFor(x => x.SideA).ShouldBeGreaterThan(0);
        RuleFor(x => x.SideB).ShouldBeGreaterThan(0);
        RuleFor(x => x.SideC).ShouldBeGreaterThan(0);
        RuleFor(x => x).Must(x => CheckSides(x.SideA, x.SideB, x.SideC))
            .WithMessage("Sum of two sides must be greater than third side");
    }
    
    private static bool CheckSides(double sideA, double sideB, double sideC)
    {
        if (sideA + sideB > sideC)
        {
            if (sideC + sideB > sideA)
            {
                if (sideC + sideA > sideB)
                {
                    return true;
                }
            }
        }
        
        return false;
    }
}