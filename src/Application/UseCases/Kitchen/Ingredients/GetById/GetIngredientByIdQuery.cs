using Application.Abstractions.Messaging;
using Application.DTOs.Kitchen.Ingredients;

namespace Application.UseCases.Kitchen.Ingredients.GetById;

public sealed record GetIngredientByIdQuery(Guid IngredientId, bool? IsInactive) : IQuery<IngredientDto>;
