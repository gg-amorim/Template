using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Kitchen.Dishes;
using Domain.Entities.Kitchen.Ingredients;

namespace Domain.Entities.Kitchen.DishesIngredients;

public sealed class DishIngredient
{
    public Guid DishId { get; set; }
    public Dish Dish { get; set; } = null!;

    public Guid IngredientId { get; set; }
    public Ingredient Ingredient { get; set; } = null!;

    public decimal Quantity { get; set; } // Quantidade usada na receita

    public Guid UserId { get; set; } // Denormalizado para facilitar RLS
}
