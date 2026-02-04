using Domain.Entities.Kitchen.Dishes;
using Domain.Entities.Kitchen.Menus;

namespace Domain.Entities.Kitchen.MenuDishes;

public sealed class MenuDish
{
    public Guid MenuId { get; set; }
    public Menu Menu { get; set; } = null!;

    public Guid DishId { get; set; }
    public Dish Dish { get; set; } = null!;

    public Category Category { get; set; } = Category.Principal;

    public Guid UserId { get; set; }
}
