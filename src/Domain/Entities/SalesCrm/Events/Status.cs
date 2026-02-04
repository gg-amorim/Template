using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.SalesCrm.Events;

public enum Status
{
    Draft = 0,      // Rascunho (só o chef vê)
    Sent = 1,       // Proposta enviada
    Confirmed = 2,  // Cliente aceitou
    Completed = 3,  // Evento realizado
    Cancelled = 4   // Cancelado
}
