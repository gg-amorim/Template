using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstractions.Repositories.Kitchen.Dishes;
using Domain.Entities.Kitchen.Dishes;
using Infrastructure.Database;
using SharedKernel;

namespace Infrastructure.Repositories.Kitchen.Dishes;

internal sealed class DishRepository(ApplicationDbContext context, IDateTimeProvider timeProvider) : BaseRepository<Dish>(context, timeProvider), IDishRepository
{
}
