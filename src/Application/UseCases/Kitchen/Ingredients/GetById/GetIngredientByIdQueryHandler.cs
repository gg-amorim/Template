using Application.Abstractions.Messaging;
using Application.DTOs.Kitchen.Ingredients;
using Domain.Abstractions;
using Domain.Abstractions.Repositories.Kitchen.Ingredients;
using Domain.Entities.Kitchen.Ingredients;
using SharedKernel;

namespace Application.UseCases.Kitchen.Ingredients.GetById;

internal sealed class GetIngredientByIdQueryHandler(IIngredientRepository ingredientRepository) : IQueryHandler<GetIngredientByIdQuery, IngredientDto>
{
    public async Task<Result<IngredientDto>> Handle(GetIngredientByIdQuery query, CancellationToken cancellationToken)
    {
        Ingredient? ingredient = await ingredientRepository.GetByIdWithDetailsAsync(query.IngredientId, query.IsInactive, cancellationToken);

        if (ingredient is null)
            return Result<IngredientDto>.ValidationFailure(IngredientErros.NotFound(query.IngredientId));

        return new IngredientDto
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            Unit = ingredient.Unit.ToString(),
            CostPrice = ingredient.CostPrice,
            IsInactive = ingredient.IsInactive
        };
    }
}
