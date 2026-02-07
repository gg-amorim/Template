using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Domain.Abstractions.Repositories.Kitchen.Ingredients;
using Domain.Abstractions.Repositories.Users;
using Domain.Entities.Kitchen.Ingredients;
using Domain.Entities.Users;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Infrastructure.Repositories.Kitchen.Ingredients;

internal sealed class IngredientRepository(ApplicationDbContext context, IDateTimeProvider timeProvider) : BaseRepository<Ingredient>(context, timeProvider), IIngredientRepository
{
    public async Task<List<Ingredient>> GetAllWithDetailsAsync(bool? isInactive, CancellationToken cancellationToken)
    {
        return await Context.Ingredients.Where(x => isInactive == null || x.IsInactive == isInactive).ToListAsync(cancellationToken);
    }

    public async Task<Ingredient?> GetByIdWithDetailsAsync(Guid id, bool? isInactive, CancellationToken cancellationToken)
    {
      return await Context.Ingredients.Where(x => isInactive == null || x.IsInactive == isInactive).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
