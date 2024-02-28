using FruitBaskets.Products.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FruitBaskets.Products.Infrastructure.Pesistency
{
    internal interface IDataPersistency
    {
        Task<T> GetByIdAsync<T>(Guid id) where T : Entity;
        Task<IEnumerable<T>> GetAllAsync<T>() where T : Entity;
        Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : Entity;
        Task CreateAsync<T>(T entity) where T : Entity;
        Task UpdateAsync<T>(T entity) where T : Entity;
        Task CreateAsync<T>(IList<T> entities) where T : Entity;
        Task UpdateAsync<T>(IList<T> entities) where T : Entity;
        Task DeleteAsync<T>(Guid id) where T : Entity;
        Task DeleteAllAsync<T>() where T : Entity;

    }
}
