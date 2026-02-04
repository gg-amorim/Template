using System;
using System.Collections.Generic;
using System.Text;
using SharedKernel;

namespace Domain.Entities.Users;

public sealed class User : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    // Para recuperação de senha e validação de e-mail
    public string? CodeConfirmationToken { get; set; }
    public DateTime? CodeConfirmationTokenExpires { get; set; }
}
