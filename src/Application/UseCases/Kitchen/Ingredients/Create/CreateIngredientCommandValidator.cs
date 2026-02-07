using Domain.Entities.Kitchen.Ingredients;
using FluentValidation;

namespace Application.UseCases.Kitchen.Ingredients.Create;

internal sealed class CreateIngredientCommandValidator : AbstractValidator<CreateIngredientCommand>
{
    public CreateIngredientCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.CostPrice)
            .GreaterThan(0)
            .WithMessage("CostPrice must be greater than zero.");
        RuleFor(c => c.Unit)
            .NotEmpty()
            .Must(u => Enum.TryParse<Unit>(u, ignoreCase: true, out _))
            .WithMessage("Unit must be one of: Un, Kg, Gr, Lt, Ml");
    }
}
