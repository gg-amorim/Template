using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.SalesCrm.Events;
using SharedKernel;

namespace Domain.Entities.Operations.ShoppingLists;

public sealed class ShoppingList : Entity
{
    public Guid EventId { get; set; }
    public Event Event { get; set; } = null!;

    public bool IsCompleted { get; set; } // Se já comprou tudo

    public ICollection<ShoppingListItem> Items { get; set; } = new List<ShoppingListItem>();

    public Guid UserId { get; set; }
}
