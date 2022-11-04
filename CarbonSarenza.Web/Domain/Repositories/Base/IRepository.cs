namespace CarbonSarenza.Web.Domain.Repositories.Base;

public interface IRepository<T> where T : class
{
    public Task<IReadOnlyList<T>> GetAllAsync();
    
    public Task<T> AddAsync(T entity);
}