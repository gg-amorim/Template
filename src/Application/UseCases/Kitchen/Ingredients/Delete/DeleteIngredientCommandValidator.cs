using FluentValidation;

namespace Application.UseCases.Kitchen.Ingredients.Delete;

internal sealed class DeleteIngredientCommandValidator : AbstractValidator<DeleteIngredientCommand>
{
    public DeleteIngredientCommandValidator()
    {
        RuleFor(command => command.IngredientId)
            .NotEmpty().WithMessage("Ingredient ID must not be empty.");
    }
}
