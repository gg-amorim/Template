using System;
using System.Collections.Generic;
using System.Text;
using Application.Abstractions.Messaging;

namespace Application.UseCases.Kitchen.Ingredients.Update;

public sealed record UpdateIngredientCommand(Guid IngredientId, string Name, string Unit, decimal CostPrice) : ICommand;

