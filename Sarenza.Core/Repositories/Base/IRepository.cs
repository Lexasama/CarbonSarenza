namespace Sarenza.Core.Repositories.Base;

public interface IRepository<T> where T : class
{
    public Task<T> AddAsync(T entity);
}