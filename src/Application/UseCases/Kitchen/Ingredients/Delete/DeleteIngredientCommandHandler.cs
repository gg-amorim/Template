using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Abstractions.Repositories.Kitchen.Ingredients;
using Domain.Entities.Kitchen.Ingredients;
using SharedKernel;

namespace Application.UseCases.Kitchen.Ingredients.Delete;

internal sealed class DeleteIngredientCommandHandler(IIngredientRepository ingredientRepository, IUnitOfWork unitOfWork) : ICommandHandler<DeleteIngredientCommand>
{
    public async Task<Result> Handle(DeleteIngredientCommand command, CancellationToken cancellationToken)
    {
        Ingredient? ingredient = await ingredientRepository.GetById(command.IngredientId, cancellationToken);
        if (ingredient is null)
        {
            return Result.Failure(IngredientErros.NotFound(command.IngredientId));
        }

        await ingredientRepository.DeleteAsync(ingredient);
        await unitOfWork.Commit(cancellationToken);
        return Result.Success();
    }
}
