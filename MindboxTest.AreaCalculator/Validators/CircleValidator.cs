using FluentValidation;
using MindboxTest.AreaCalculator.Figures;

namespace MindboxTest.AreaCalculator.Validators;

public class CircleValidator : AbstractValidator<Circle>
{
    public CircleValidator()
    {
        RuleFor(x => x.Radius).ShouldBeGreaterThan(0);
    }    
}