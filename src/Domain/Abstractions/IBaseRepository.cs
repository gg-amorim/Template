using SharedKernel;

namespace Domain.Abstractions;

public interface IBaseRepository<T> where T : Entity
{
    Task CreateAsync(T entity, CancellationToken cancellationToken);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetById(Guid id, CancellationToken cancellationToken);
    Task<List<T>> GetAll(CancellationToken cancellationToken, bool onlyRead = true);
}
