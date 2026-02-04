using Domain.Entities.Users;

namespace Domain.Abstractions.Repositories.Users;

public interface IUserRepository : IBaseRepository<User>
{
    Task<bool> IsEmailUniqueAsync(string email, CancellationToken cancellationToken);
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);
}
