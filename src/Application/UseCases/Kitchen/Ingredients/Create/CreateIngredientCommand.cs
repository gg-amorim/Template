using System;
using System.Collections.Generic;
using System.Text;
using Application.Abstractions.Messaging;

namespace Application.UseCases.Kitchen.Ingredients.Create;

public sealed record CreateIngredientCommand(string Name, string Unit, decimal CostPrice) : ICommand<Guid>;
