using System;
using System.Collections.Generic;
using System.Text;
using Application.Abstractions.Messaging;
using Application.DTOs.Kitchen.Ingredients;

namespace Application.UseCases.Kitchen.Ingredients.Get;

public sealed record GetIngredientsQuery : IQuery<List<IngredientDto>>;

