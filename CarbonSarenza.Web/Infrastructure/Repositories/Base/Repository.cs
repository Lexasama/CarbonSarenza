using CarbonSarenza.Web.Domain.Data;
using CarbonSarenza.Web.Domain.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CarbonSarenza.Web.Infrastructure.Repositories.Base;

public class Repository<T>: IRepository<T> where T: class
{
    protected readonly DatabaseContext _dbContext;

    public Repository(DatabaseContext context)
    {
        _dbContext = context;
    }
    
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return (await _dbContext.Set<T>().ToListAsync()).AsReadOnly();
    }
    
    public async Task<T> AddAsync(T entity)
    {
          await _dbContext.Set<T>().AddAsync(entity);
          await _dbContext.SaveChangesAsync();
          return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }
}