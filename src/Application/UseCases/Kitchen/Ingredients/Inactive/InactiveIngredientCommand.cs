using System;
using System.Collections.Generic;
using System.Text;
using Application.Abstractions.Messaging;

namespace Application.UseCases.Kitchen.Ingredients.Inactive;

public sealed record InactiveIngredientCommand(Guid IngredientId) : ICommand;

