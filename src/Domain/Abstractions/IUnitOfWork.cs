namespace Domain.Abstractions;

public interface IUnitOfWork : IDisposable
{
    Task<bool> Commit(CancellationToken cancellationToken);
}

