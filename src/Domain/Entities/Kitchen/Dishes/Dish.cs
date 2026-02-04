using Domain.Entities.Kitchen.DishesIngredients;
using Domain.Entities.Kitchen.MenuDishes;
using SharedKernel;

namespace Domain.Entities.Kitchen.Dishes;

public sealed class Dish : Entity
{
    public string Name { get; set; }
    public string? Description { get; set; } // Descrição para por na proposta
    public string? PhotoUrl { get; set; } // Futuro: Foto do prato
    public decimal SalePrice { get; set; } // Preço base de venda sugerido
    public Guid UserId { get; set; }

    // Relacionamento N:N com Ingredientes
    public ICollection<DishIngredient> Ingredients { get; set; } = [];

    // Relacionamento N:N com Menus (Navegação)
    public ICollection<MenuDish> Menus { get; set; } = [];
}
