using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Kitchen.Dishes;

public record DishIngredientDto(Guid IngredientId, decimal Quantity);
