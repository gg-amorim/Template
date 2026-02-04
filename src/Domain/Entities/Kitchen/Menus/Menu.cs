using Domain.Entities.Kitchen.MenuDishes;
using SharedKernel;

namespace Domain.Entities.Kitchen.Menus;

public sealed class Menu : Entity
{
    public required string Name { get; set; } // Ex: "Jantar Romântico", "Churrasco Premium"
    public string? Description { get; set; }
    public Guid UserId { get; set; }

    // Relacionamento N:N com Pratos
    public ICollection<MenuDish> Dishes { get; set; } = new List<MenuDish>();
}
