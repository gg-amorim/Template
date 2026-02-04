using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel;

namespace Domain.Entities.Kitchen.Ingredients;

public static class IngredientErros
{
    public static Error NotFound(Guid ingredientId) => Error.NotFound(
      "Ingredient.NotFound",
      $"The ingredient item with the Id = '{ingredientId}' was not found");
}
