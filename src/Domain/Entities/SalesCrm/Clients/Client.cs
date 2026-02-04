using Domain.Entities.SalesCrm.Events;
using SharedKernel;

namespace Domain.Entities.SalesCrm.Clients;

public sealed class Client : OwnedEntity
{
    public string Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }

    // O campo mais importante de segurança alimentar
    public string? DietaryRestrictions { get; set; } // Ex: "Alergia a camarão, Intolerante a lactose"

    public ICollection<Event> Events { get; set; } = new List<Event>();
}
