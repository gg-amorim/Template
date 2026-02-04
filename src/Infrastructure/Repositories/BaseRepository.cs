using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstractions;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using SharedKernel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repositories;

public  class BaseRepository<T>(ApplicationDbContext context, IDateTimeProvider timeProvider) : IBaseRepository<T> where T : Entity
{
    public async Task CreateAsync(T entity)
    {
        entity.Init(timeProvider.UtcNow);
        await context.AddAsync(entity);
    }
    public async Task UpdateAsync(T entity)
    {
        entity.Touch(timeProvider.UtcNow);
        context.Update(entity);
        await Task.CompletedTask;
    }
    public async Task DeleteAsync(T entity)
    {
        entity.MarkAsDeleted(timeProvider.UtcNow);
        context.Update(entity);
        await Task.CompletedTask;
    }

    public async Task<IQueryable<T>> GetAll()
    {
        return context.Set<T>().AsQueryable();
    }

    public async Task<T> GetById(Guid id, CancellationToken cancellationToken)
    {
        return await context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    
}
