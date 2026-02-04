using SharedKernel;

namespace Domain.Entities.Kitchen.Ingredients;

public sealed class Ingredient : Entity
{
    public string Name { get; set; }
    public Unit Unit { get; set; } = Unit.Un;
    public decimal CostPrice { get; set; } // Preço de custo por unidade
    public Guid UserId { get; set; }
}
