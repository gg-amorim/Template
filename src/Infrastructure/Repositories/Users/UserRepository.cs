using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstractions.Repositories.Users;
using Domain.Entities.Users;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using SharedKernel;

namespace Infrastructure.Repositories.Users;

internal sealed class UserRepository : BaseRepository<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context, IDateTimeProvider dateTimeProvider)
        : base(context, dateTimeProvider)
    {
        _context = context;
    }
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

    public async Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken)
    {
        return !await _context.Users.AnyAsync(u => u.Email == email, cancellationToken);
    }
}
