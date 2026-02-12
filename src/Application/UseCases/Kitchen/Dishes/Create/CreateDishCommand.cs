using System;
using System.Collections.Generic;
using System.Text;
using Application.Abstractions.Messaging;
using Application.DTOs.Kitchen.Dishes;

namespace Application.UseCases.Kitchen.Dishes.Create;


public sealed record CreateDishCommand(
    string Name,
    string? Description,
    decimal SalePrice,
    List<DishIngredientDto> Ingredients) : ICommand<Guid>;
