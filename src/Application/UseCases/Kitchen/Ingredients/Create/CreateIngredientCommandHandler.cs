using System;
using System.Collections.Generic;
using System.Text;
using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Abstractions.Repositories.Kitchen.Ingredients;
using Domain.Entities.Kitchen.Ingredients;
using SharedKernel;

namespace Application.UseCases.Kitchen.Ingredients.Create;

internal sealed class CreateIngredientCommandHandler(IIngredientRepository ingredientRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateIngredientCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateIngredientCommand command, CancellationToken cancellationToken)
    {
        Enum.TryParse<Unit>(command.Unit, ignoreCase: true, out Unit unit);
        var ingredient = new Ingredient { Name = command.Name, Unit = unit, CostPrice = command.CostPrice };

        await ingredientRepository.CreateAsync(ingredient);
        await unitOfWork.Commit(cancellationToken);

        return ingredient.Id;
    }
}
