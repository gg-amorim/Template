using SharedKernel;

namespace Domain.Entities.Kitchen.Ingredients;

public sealed class Ingredient : OwnedEntity
{
    public string Name { get; set; }
    public Unit Unit { get; set; } = Unit.Un;
    public decimal CostPrice { get; set; } // Preço de custo por unidade

    public void Update(string name, string unit, decimal costPrice)
    {
        Name = name;
        Unit = Enum.Parse<Unit>(unit);
        CostPrice = costPrice;
    }
}
