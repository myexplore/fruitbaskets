using FruitBaskets.Domain;
using FruitBaskets.Products.Application;

namespace FruitBaskets.Products.Infrastructure
{
    public interface IDataPersistency
    {
        Task<T> GetByIdAsync<T>(Guid id) where T : Entity;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : Entity;
        Task<IEnumerable<T>> GetAsync<T>(Func<T, bool> predicate) where T : Entity;
        Task CreateAsync<T>(T entity) where T : Entity;
        Task UpdateAsync<T>(T entity) where T : Entity;
        Task CreateAsync<T>(IList<T> entities) where T : Entity;
        Task UpdateAsync<T>(IList<T> entities) where T : Entity;
        Task DeleteAsync<T>(Guid id) where T : Entity;
        Task DeleteAllAsync<T>() where T : Entity;

    }
}
