using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Kitchen.Menus;
using Domain.Entities.Operations.ShoppingLists;
using Domain.Entities.SalesCrm.Clients;
using SharedKernel;

namespace Domain.Entities.SalesCrm.Events;

public sealed class Event : Entity
{
    public string Name { get; set; } // Ex: "Aniversário da Ana"
    public DateTime EventDate { get; set; }
    public int NumberOfGuests { get; set; }
    public string? Address { get; set; }

    public Status Status { get; set; } = Status.Draft;

    // Valores Financeiros
    public decimal AgreedPrice { get; set; } // Valor total fechado com o cliente
    public decimal CostEstimate { get; set; } // Soma do custo dos ingredientes (Snapshot)

    // Relacionamentos
    public Guid ClientId { get; set; }
    public Client Client { get; set; } = null!;

    public Guid MenuId { get; set; }
    public Menu Menu { get; set; } = null!; // O menu escolhido para este evento

    // Navegação para a lista de compras gerada
    public ShoppingList? ShoppingList { get; set; }

    public Guid UserId { get; set; } // Dono do evento (usuário do sistema)
}
