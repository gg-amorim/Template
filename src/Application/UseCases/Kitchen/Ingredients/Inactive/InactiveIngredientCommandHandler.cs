using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Abstractions.Repositories.Kitchen.Ingredients;
using Domain.Entities.Kitchen.Ingredients;
using SharedKernel;

namespace Application.UseCases.Kitchen.Ingredients.Inactive;

internal sealed class InactiveIngredientCommandHandler(IIngredientRepository ingredientRepository, IUnitOfWork unitOfWork) : ICommandHandler<InactiveIngredientCommand>
{
    public async Task<Result> Handle(InactiveIngredientCommand command, CancellationToken cancellationToken)
    {
        Ingredient? ingredient = await ingredientRepository.GetById(command.IngredientId, cancellationToken);
        if (ingredient is null)
        {
            return Result.Failure(IngredientErros.NotFound(command.IngredientId));
        }
        ingredient.MarkAsInactive();
        await ingredientRepository.UpdateAsync(ingredient);
        await unitOfWork.Commit(cancellationToken);
        return Result.Success();
    }
}
