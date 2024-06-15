using FruitBaskets.Domain;
using FruitBaskets.Products.Application;

namespace FruitBaskets.Products.Infrastructure
{
    public class DataService : IDataService
    {
        private readonly IDataPersistency persistency;

        public DataService(IDataPersistency _persistency)
        {
            persistency = _persistency;
        }
        public async Task CreateAsync<T>(T entity) where T : Entity
        {
           await persistency.CreateAsync(entity);
        }

        public async Task CreateAsync<T>(IList<T> entities) where T : Entity
        {
            await persistency.CreateAsync(entities);
        }

        public async Task DeleteAllAsync<T>() where T : Entity
        {
            await persistency.DeleteAllAsync<T>();
        }

        public async Task DeleteAsync<T>(Guid id) where T : Entity
        {
            await persistency.DeleteAsync<T>(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : Entity
        {
          return  await persistency.GetAllAsync<T>();
        }

        public async Task<IEnumerable<T>> GetAsync<T>(Func<T, bool> predicate) where T : Entity
        {           
            
            return await persistency.GetAsync<T>(predicate);
        }

        public async Task<T> GetByIdAsync<T>(Guid id) where T : Entity
        {
          return  await persistency.GetByIdAsync<T>(id);
        }

        public async Task UpdateAsync<T>(T entity) where T : Entity
        {
           await persistency.UpdateAsync(entity);
        }

        public async Task UpdateAsync<T>(IList<T> entities) where T : Entity
        {
            await persistency.UpdateAsync(entities);
        }
    }


}
