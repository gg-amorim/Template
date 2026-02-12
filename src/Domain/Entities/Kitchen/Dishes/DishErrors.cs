using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel;

namespace Domain.Entities.Kitchen.Dishes;

public static class DishErrors
{
    public static Error NotFound(Guid dishId) => Error.NotFound(
          "Dish.NotFound",
          $"The dish item with the Id = '{dishId}' was not found");

    public static Error IngredientsDishNotFound() => Error.Problem(
          "Dish.IngredientsDishNotFound",
          $"One or more ingredients could not be found or do not belong to you.");
}
