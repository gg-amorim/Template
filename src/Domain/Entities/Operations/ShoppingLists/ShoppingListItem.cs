using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel;

namespace Domain.Entities.Operations.ShoppingLists;

public sealed class ShoppingListItem : Entity
{
    public Guid ShoppingListId { get; set; }
    public ShoppingList ShoppingList { get; set; } = null!;

    // Snapshot dos dados do ingrediente (para não quebrar se o ingrediente mudar depois)
    public required string Name { get; set; }
    public string Unit { get; set; } = "un";

    // Cálculo: (Qtd do Prato * Nº Convidados)
    public decimal QuantityNeeded { get; set; }

    public bool IsChecked { get; set; } // O "Check" do app no mercado

    // Opcional: Referência ao ingrediente original (se ainda existir)
    public Guid? OriginalIngredientId { get; set; }

    public Guid UserId { get; set; }
}
