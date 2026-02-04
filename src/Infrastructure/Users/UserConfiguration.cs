using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Users;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Users;

internal sealed class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        // Aplica as regras globais (Id, Soft Delete, CreatedAt)
        base.Configure(builder);

        // Regras Específicas do Usuário
        builder.Property(u => u.FirstName).HasMaxLength(100).IsRequired();
        builder.Property(u => u.LastName).HasMaxLength(100).IsRequired();
        builder.Property(u => u.Email).HasMaxLength(254).IsRequired();

        builder.HasIndex(u => u.Email).IsUnique();
    }
}
