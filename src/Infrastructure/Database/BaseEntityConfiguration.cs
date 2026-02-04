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
        // Configuração de Identidade
        builder.Property(e => e.Id)
               .ValueGeneratedNever();

        // Ignora eventos de domínio para não mapear para o banco
        builder.Ignore(e => e.DomainEvents);
    }
}

internal abstract class OwnedEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity>
    where TEntity : OwnedEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        // Executa a configuração da base (Id e DomainEvents)
        base.Configure(builder);

        builder.Property(e => e.UserId)
               .IsRequired();

        // PERFORMANCE: Criamos um índice que ajuda o filtro global.
        // Como o filtro usa UserId e IsDeleted, um índice composto é o ideal.
        builder.HasIndex(e => new { e.UserId, e.IsDeleted });
    }
}
