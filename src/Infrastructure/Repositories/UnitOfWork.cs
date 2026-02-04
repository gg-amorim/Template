using System;
using System.Collections.Generic;
using System.Text;
using Domain.Abstractions;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public  async Task<bool> Commit(CancellationToken cancellationToken)
    {
        try
        {
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }

    public void Dispose()
    {
        System.GC.SuppressFinalize(this);
    }
}
