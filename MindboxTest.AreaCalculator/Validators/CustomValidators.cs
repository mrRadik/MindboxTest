using FluentValidation;

namespace MindboxTest.AreaCalculator.Validators;

public static class CustomValidators
{
    public static void ShouldBeGreaterThan<T>(this IRuleBuilder<T, double> ruleBuilder, double num)
    {
        ruleBuilder.Must((rootObject, value, context) =>
        {
            context.MessageFormatter.AppendArgument("MinValue", num);
            return value > num;
        }).WithMessage("{PropertyName} must be greater than {MinValue}");
    }
}