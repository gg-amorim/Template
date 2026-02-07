using FluentValidation;

namespace Application.UseCases.Kitchen.Ingredients.Inactive;

internal sealed class InactiveIngredientCommandValidator : AbstractValidator<InactiveIngredientCommand>
{
    public InactiveIngredientCommandValidator()
    {
        RuleFor(command => command.IngredientId)
           .NotEmpty().WithMessage("Ingredient ID must not be empty.");
    }
}
