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
using SharedKernel;

namespace Infrastructure.Database;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDomainEventsDispatcher domainEventsDispatcher)
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    //public DbSet<Dish> Dishes { get; set; }

    //public DbSet<DishIngredient> DishIngredients { get; set; }

    //public DbSet<Ingredient> Ingredients { get; set; }

    //public DbSet<MenuDish> MenuDishes { get; set; }

    //public DbSet<Menu> Menus { get; set; }

    //public DbSet<ShoppingList> ShoppingLists { get; set; }

    //public DbSet<ShoppingListItem> ShoppingListItens { get; set; }

    //public DbSet<Client> Clients { get; set; }

    //public DbSet<Event> Events { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.HasDefaultSchema(Schemas.Default);
        base.OnModelCreating(modelBuilder);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // When should you publish domain events?
        //
        // 1. BEFORE calling SaveChangesAsync
        //     - domain events are part of the same transaction
        //     - immediate consistency
        // 2. AFTER calling SaveChangesAsync
        //     - domain events are a separate transaction
        //     - eventual consistency
        //     - handlers can fail

        int result = await base.SaveChangesAsync(cancellationToken);

        await PublishDomainEventsAsync();

        return result;
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
