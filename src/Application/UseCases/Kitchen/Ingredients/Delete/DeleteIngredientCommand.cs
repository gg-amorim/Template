using Application.Abstractions.Messaging;

namespace Application.UseCases.Kitchen.Ingredients.Delete;

public sealed record DeleteIngredientCommand(Guid IngredientId) : ICommand;
