using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.Kitchen.Ingredients;

public sealed class IngredientDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
    public decimal CostPrice { get; set; }
    public bool IsInactive { get; set; }
}
