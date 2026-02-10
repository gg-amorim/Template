using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstractions.Repositories.Users;
using Domain.Entities.Users;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Infrastructure.Repositories.Users;

internal sealed class UserRepository(ApplicationDbContext context, IDateTimeProvider dateTimeProvider) : BaseRepository<User>(context, dateTimeProvider), IUserRepository
{
   
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await Context.Users.SingleOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken)
    {
        return !await Context.Users.AnyAsync(u => u.Email == email, cancellationToken);
    }
}
