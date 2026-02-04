using Domain.Entities.Kitchen.Dishes;
using Domain.Entities.Kitchen.Menus;
using SharedKernel;

namespace Domain.Entities.Kitchen.MenuDishes;

public sealed class MenuDish : OwnedEntity
{
    public Guid MenuId { get; set; }
    public Menu Menu { get; set; } = null!;

    public Guid DishId { get; set; }
    public Dish Dish { get; set; } = null!;

    public Category Category { get; set; } = Category.Principal;
}
