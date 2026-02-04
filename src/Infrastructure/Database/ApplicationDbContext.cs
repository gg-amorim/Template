using System.Linq.Expressions;
using Application.Abstractions.Authentication;
using Domain.Entities.Kitchen.Dishes;
using Domain.Entities.Kitchen.DishesIngredients;
using Domain.Entities.Kitchen.Ingredients;
using Domain.Entities.Kitchen.MenuDishes;
using Domain.Entities.Kitchen.Menus;
using Domain.Entities.Operations.ShoppingLists;
using Domain.Entities.SalesCrm.Clients;
using Domain.Entities.SalesCrm.Events;
using Domain.Entities.Users;
using Infrastructure.Services.DomainEvents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using SharedKernel;

namespace Infrastructure.Database;

public sealed class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options,
    IDomainEventsDispatcher domainEventsDispatcher,
    IUserContext userContext)
    : DbContext(options)
{
    private Guid? CurrentUserId => GetCurrentUserIdSafe();

    private Guid? GetCurrentUserIdSafe()
    {
        try
        {
            return userContext.UserId;
        }
        catch
        {
            return null;
        }
    }
    public DbSet<User> Users { get; set; }

    public DbSet<Dish> Dishes { get; set; }

    public DbSet<DishIngredient> DishIngredients { get; set; }

    public DbSet<Ingredient> Ingredients { get; set; }

    public DbSet<MenuDish> MenuDishes { get; set; }

    public DbSet<Menu> Menus { get; set; }

    public DbSet<ShoppingList> ShoppingLists { get; set; }

    public DbSet<ShoppingListItem> ShoppingListItens { get; set; }

    public DbSet<Client> Clients { get; set; }

    public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.HasDefaultSchema(Schemas.Default);

        ApplyGlobalFilters(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

    private void ApplyGlobalFilters(ModelBuilder modelBuilder)
    {
        foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
        {
            // 1. Verifica se a entidade herda de Entity (Soft Delete)
            bool isBaseEntity = typeof(Entity).IsAssignableFrom(entityType.ClrType);
            // 2. Verifica se a entidade implementa OwnedEntity (Multi-tenancy)
            bool isOwnedEntity = typeof(OwnedEntity).IsAssignableFrom(entityType.ClrType);

            if (!isBaseEntity && !isOwnedEntity)
                continue;

            ParameterExpression parameter = Expression.Parameter(entityType.ClrType, "e");
            Expression combinedExpression = null;

            // Filtro de Soft Delete (IsDeleted == false)
            if (isBaseEntity)
            {
                MemberExpression prop = Expression.Property(parameter, nameof(Entity.IsDeleted));
                combinedExpression = Expression.Equal(prop, Expression.Constant(false));
            }

            if (isOwnedEntity)
            {
                MemberExpression userProp = Expression.Property(parameter, nameof(OwnedEntity.UserId));

                // Acessa a propriedade do DbContext
                MemberExpression currentUserIdProp = Expression.Property(Expression.Constant(this), nameof(CurrentUserId));

                // CORREÇÃO: Converte o CurrentUserId para o tipo exato da propriedade da entidade (Guid)
                UnaryExpression convertedCurrentUserId = Expression.Convert(currentUserIdProp, userProp.Type);

                // Agora a comparação funciona
                BinaryExpression userIdFilter = Expression.Equal(userProp, convertedCurrentUserId);

                combinedExpression = combinedExpression == null
                    ? userIdFilter
                    : Expression.AndAlso(combinedExpression, userIdFilter);
            }

            if (combinedExpression != null)
            {
                LambdaExpression lambda = Expression.Lambda(combinedExpression, parameter);
                entityType.SetQueryFilter(lambda);
            }
        }
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // 1. Aplica o UserId antes de salvar
        ApplyOwnedEntityData();

        int result = await base.SaveChangesAsync(cancellationToken);

        await PublishDomainEventsAsync();

        return result;
    }

    private void ApplyOwnedEntityData()
    {
        // O ChangeTracker consegue filtrar diretamente pela classe abstrata
        IEnumerable<EntityEntry<OwnedEntity>> entries = ChangeTracker.Entries<OwnedEntity>()
            .Where(e => e.State == EntityState.Added);

        foreach (EntityEntry<OwnedEntity> entry in entries)
        {
            // Como agora é uma classe, o acesso ao método SetUserId é direto
            entry.Entity.SetUserId(CurrentUserId ?? Guid.Empty);
        }
    }

    private async Task PublishDomainEventsAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(entry => entry.Entity)
            .SelectMany(entity =>
            {
                List<IDomainEvent> domainEvents = entity.DomainEvents;

                entity.ClearDomainEvents();

                return domainEvents;
            })
            .ToList();

        await domainEventsDispatcher.DispatchAsync(domainEvents);
    }
}
