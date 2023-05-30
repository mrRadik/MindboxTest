using System.Text;
using FluentValidation;
using MindboxTest.AreaCalculator.Interfaces;

namespace MindboxTest.AreaCalculator.Figures;

public abstract class BaseFigureValidator<T> where T : IFigure
{
    protected void ValidateParameters(AbstractValidator<T> validator,T instance)
    {
        var validationResult = validator.Validate(instance);
        if (validationResult.IsValid)
        {
            return;
        }

        var errorString = new StringBuilder();
        foreach (var error in validationResult.Errors)
        {
            errorString.Append($"{error.ErrorMessage}; ");
        }

        throw new ArgumentException(errorString.ToString());
    }
}