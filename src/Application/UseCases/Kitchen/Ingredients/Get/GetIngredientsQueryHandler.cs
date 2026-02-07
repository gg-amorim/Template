using System;
using System.Collections.Generic;
using System.Text;
using Application.Abstractions.Messaging;
using Application.DTOs.Kitchen.Ingredients;
using Domain.Abstractions.Repositories.Kitchen.Ingredients;
using Domain.Entities.Kitchen.Ingredients;
using SharedKernel;

namespace Application.UseCases.Kitchen.Ingredients.Get;

internal sealed class GetIngredientsQueryHandler(IIngredientRepository ingredientRepository) : IQueryHandler<GetIngredientsQuery, List<IngredientDto>>
{
    public async Task<Result<List<IngredientDto>>> Handle(GetIngredientsQuery query, CancellationToken cancellationToken)
    {

        List<Ingredient> ingredients = await ingredientRepository.GetAll(cancellationToken);
        return ingredients.ConvertAll(ingredient => new IngredientDto
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            Unit = ingredient.Unit.ToString(),
            CostPrice = ingredient.CostPrice,
            IsInactive = ingredient.IsInactive
        });
    }
}
