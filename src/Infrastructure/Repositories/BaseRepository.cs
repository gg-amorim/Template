using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstractions;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using SharedKernel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repositories;

public class BaseRepository<T>(ApplicationDbContext context, IDateTimeProvider timeProvider) : IBaseRepository<T> where T : Entity
{
    protected readonly ApplicationDbContext Context = context;
    protected readonly IDateTimeProvider TimeProvider = timeProvider;
    public async Task CreateAsync(T entity)
    {
        entity.Init(TimeProvider.UtcNow);
        await Context.AddAsync(entity);
    }
    public async Task UpdateAsync(T entity)
    {
        entity.Touch(TimeProvider.UtcNow);
        Context.Update(entity);
        await Task.CompletedTask;
    }
    public async Task DeleteAsync(T entity)
    {
        entity.MarkAsDeleted(TimeProvider.UtcNow);
        Context.Update(entity);
        await Task.CompletedTask;
    }

    public async Task<List<T>> GetAll(CancellationToken cancellationToken, bool onlyRead = true)
    {
        IQueryable<T> query = onlyRead ? Context.Set<T>().AsNoTracking() : Context.Set<T>();
        return await query.ToListAsync(cancellationToken);
    }

    public async Task<T> GetById(Guid id, CancellationToken cancellationToken)
    {

        return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }


}
