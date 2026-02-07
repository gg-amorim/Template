using System;
using System.Collections.Generic;
using System.Text;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Abstractions.Repositories.Kitchen.Ingredients;
using Domain.Entities.Kitchen.Ingredients;
using SharedKernel;

namespace Application.UseCases.Kitchen.Ingredients.Update;

internal sealed class UpdateIngredientCommandHandler(IIngredientRepository ingredientRepository, IUnitOfWork unitOfWork): ICommandHandler<UpdateIngredientCommand>
{
    public async Task<Result> Handle(UpdateIngredientCommand command, CancellationToken cancellationToken)
    {
        Ingredient? ingredient = await ingredientRepository.GetById(command.IngredientId, cancellationToken);

        if(ingredient == null)
            return Result.Failure(IngredientErros.NotFound(command.IngredientId));

        ingredient.Update(command.Name, command.Unit, command.CostPrice);
        await ingredientRepository.UpdateAsync(ingredient);
        await unitOfWork.Commit(cancellationToken);

        return Result.Success();
    }
}
