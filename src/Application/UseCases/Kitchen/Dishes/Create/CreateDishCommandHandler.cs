using System;
using System.Collections.Generic;
using System.Text;
using Application.Abstractions.Messaging;
using Application.DTOs.Kitchen.Dishes;
using Domain.Abstractions;
using Domain.Abstractions.Repositories.Kitchen.Dishes;
using Domain.Abstractions.Repositories.Kitchen.Ingredients;
using Domain.Entities.Kitchen.Dishes;
using Domain.Entities.Kitchen.DishesIngredients;
using SharedKernel;

namespace Application.UseCases.Kitchen.Dishes.Create;

internal sealed class CreateDishCommandHandler(IDishRepository dishRepository, IIngredientRepository ingredientRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateDishCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateDishCommand command, CancellationToken cancellationToken)
    {
        var sentIngredientIds = command.Ingredients.Select(x => x.IngredientId).ToList();
        int existingIngredientsCount = await ingredientRepository.CountByIdsAsync(sentIngredientIds, cancellationToken);
        if (existingIngredientsCount != sentIngredientIds.Distinct().Count())
        {
            return Result.Failure<Guid>(DishErrors.IngredientsDishNotFound());
        }

        var dish = new Dish
        {
            Name = command.Name,
            Description = command.Description,
            SalePrice = command.SalePrice,
        };

        foreach (DishIngredientDto item in command.Ingredients)
        {
            dish.Ingredients.Add(new DishIngredient
            {

                DishId = dish.Id,
                IngredientId = item.IngredientId,
                Quantity = item.Quantity
            });
        }

        await dishRepository.CreateAsync(dish, cancellationToken);

        await unitOfWork.Commit(cancellationToken);
        return Result.Success(dish.Id);
    }
}
