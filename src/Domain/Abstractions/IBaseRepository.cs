using SharedKernel;

namespace Domain.Abstractions;

public interface IBaseRepository<T> where T : Entity
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T> GetById(Guid id, CancellationToken cancellationToken);
    Task<IQueryable<T>> GetAll();
}
