using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel;

namespace Infrastructure.Database;

internal abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        // Garante que o ID não seja gerado pelo Banco (já que você usa UUID v7 no código)
        builder.Property(e => e.Id)
               .ValueGeneratedNever();

        // Automaticamente filtra registros onde IsDeleted == false em todas as queries
        builder.HasQueryFilter(e => !e.IsDeleted);

        builder.Ignore(e => e.DomainEvents);
    }
}
