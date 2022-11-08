using Microsoft.EntityFrameworkCore;
using Sarenza.Core.Repositories.Base;
using Sarenza.DAL.Data;

namespace Sarenza.DAL.Repositories.Base;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DatabaseContext _dbContext;

    public Repository(DatabaseContext context)
    {
        _dbContext = context;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _dbContext.Set<T>().Update(entity);
        await _dbContext.SaveChangesAsync();
    }
}