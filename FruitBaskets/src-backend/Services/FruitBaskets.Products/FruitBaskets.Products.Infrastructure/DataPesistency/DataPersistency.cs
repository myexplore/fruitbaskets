using FruitBaskets.Products.Domain;
using FruitBaskets.Products.Infrastructure.Pesistency;
using LiteDB;
using System.Linq.Expressions;

namespace FruitBaskets.Products.Infrastructure.DataPesistency
{
    internal class DataPersistency:IDataPersistency
    {
        private readonly string dbPath;
        public DataPersistency()
        {
            dbPath = "C:\\database.db";
         
           
        }
        private string ConnectionString => $"Filename={dbPath};connection=shared";


        public async Task CreateAsync<T>(T entity) where T : Entity
        {
          
            await Task.Run(() =>
             {
                 using (var db = new LiteDatabase(ConnectionString))
                 {
                     var collectionName = typeof(T).Name;
                     if (!db.CollectionExists(collectionName))
                     {
                         throw new Exception($"Collection '{collectionName}' not found");
                     }
                     var collections = db.GetCollection<T>(collectionName);
                     collections.Insert(entity);

                 }
             });
        }

        public async Task CreateAsync<T>(IList<T> entities) where T : Entity
        {
            await Task.Run(() =>
            {
                using (var db = new LiteDatabase(ConnectionString))
                {
                    var collectionName = typeof(T).Name;
                    if (!db.CollectionExists(collectionName))
                    {
                        throw new Exception($"Collection '{collectionName}' not found");
                    }
                    var collections = db.GetCollection<T>(collectionName);
                    collections.InsertBulk(entities);

                }
            });
        }

        public async Task DeleteAllAsync<T>() where T : Entity
        {
            await Task.Run(() =>
            {
                using (var db = new LiteDatabase(ConnectionString))
                {
                    var collectionName = typeof(T).Name;
                    if (!db.CollectionExists(collectionName))
                    {
                        throw new Exception($"Collection '{collectionName}' not found");
                    }
                    var collections = db.GetCollection<T>(collectionName);
                    collections.DeleteAll();

                }
            });
        }

        public async Task DeleteAsync<T>(Guid id) where T : Entity
        {
            await Task.Run(() =>
            {
                using (var db = new LiteDatabase(ConnectionString))
                {
                    var collectionName = typeof(T).Name;
                    if (!db.CollectionExists(collectionName))
                    {
                        throw new Exception($"Collection '{collectionName}' not found");
                    }
                    var collections = db.GetCollection<T>(collectionName);
                    collections.Delete(id);

                }
            });
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : Entity
        {
            await Task.Run(() =>
            {
                using (var db = new LiteDatabase(ConnectionString))
                {
                    var collectionName = typeof(T).Name;
                    if (!db.CollectionExists(collectionName))
                    {
                        throw new Exception($"Collection '{collectionName}' not found");
                    }
                    var collections = db.GetCollection<T>(collectionName);
                    return collections.FindAll();

                }
            });
            return Enumerable.Empty<T>();
        }

        public async Task<IEnumerable<T>> GetAsync<T>(Expression<Func<T, bool>> predicate) where T : Entity
        {
            await Task.Run(() =>
            {
                using (var db = new LiteDatabase(ConnectionString))
                {
                    var collectionName = typeof(T).Name;
                    if (!db.CollectionExists(collectionName))
                    {
                        throw new Exception($"Collection '{collectionName}' not found");
                    }
                    var collections = db.GetCollection<T>(collectionName);
                    return collections.Find(predicate);

                }
            });
            return Enumerable.Empty<T>();
        }

        public async Task<T> GetByIdAsync<T>(Guid id) where T : Entity
        {
            await Task.Run(() =>
            {
                using (var db = new LiteDatabase(ConnectionString))
                {
                    var collectionName = typeof(T).Name;
                    if (!db.CollectionExists(collectionName))
                    {
                        throw new Exception($"Collection '{collectionName}' not found");
                    }
                    var collections = db.GetCollection<T>(collectionName);
                    return collections.FindById(id);

                }
            });
            return default(T);
        }

        public async Task UpdateAsync<T>(T entity) where T : Entity
        {
            await Task.Run(() =>
            {
                using (var db = new LiteDatabase(ConnectionString))
                {
                    var collectionName = typeof(T).Name;
                    if (!db.CollectionExists(collectionName))
                    {
                        throw new Exception($"Collection '{collectionName}' not found");
                    }
                    var collections = db.GetCollection<T>(collectionName);
                    return collections.Update(entity);

                }
            });
        }

        public async Task UpdateAsync<T>(IList<T> entities) where T : Entity
        {
            await Task.Run(() =>
            {
                using (var db = new LiteDatabase(ConnectionString))
                {
                    var collectionName = typeof(T).Name;
                    if (!db.CollectionExists(collectionName))
                    {
                        throw new Exception($"Collection '{collectionName}' not found");
                    }
                    var collections = db.GetCollection<T>(collectionName);
                    try
                    {
                        db.BeginTrans();
                        foreach (var entity in entities)
                        {
                            collections.Update(entity);
                        }
                        db.Commit();
                    }
                    catch (Exception ex)
                    {
                        db.Rollback();
                    }
                }
            });
        }
    }
}
