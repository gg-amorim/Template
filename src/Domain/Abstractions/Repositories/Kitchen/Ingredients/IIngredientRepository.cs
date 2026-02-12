using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities.Kitchen.Ingredients;

namespace Domain.Abstractions.Repositories.Kitchen.Ingredients;

public interface IIngredientRepository : IBaseRepository<Ingredient>
{
    Task<Ingredient?> GetByIdWithDetailsAsync(Guid id, bool? isInactive, CancellationToken cancellationToken);
    Task<List<Ingredient>> GetAllWithDetailsAsync(bool? isInactive, CancellationToken cancellationToken);
    Task<int> CountByIdsAsync(List<Guid> ids, CancellationToken cancellationToken);
}
