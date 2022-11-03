namespace CarbonSarenza.Web.Domain.Entities;

public abstract class BaseEntity<T>
{
    public virtual T Id { get; protected set; }
}