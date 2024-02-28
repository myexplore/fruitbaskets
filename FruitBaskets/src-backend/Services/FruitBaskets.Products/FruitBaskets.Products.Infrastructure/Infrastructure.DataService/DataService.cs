using FruitBaskets.Products.Application.DataService;
using FruitBaskets.Products.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruitBaskets.Products.Infrastructure.DataService
{
    public class DataService : IDataService
    {
        public Task CreateAsync<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync<T>(IList<T> entities) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllAsync<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync<T>(Guid id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAsync<T>(Func<T, bool> predicate) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync<T>(Guid id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync<T>(T entity) where T : Entity
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync<T>(IList<T> entities) where T : Entity
        {
            throw new NotImplementedException();
        }
    }


}
