using FruitBaskets.Domain;
using LiteDB;
using System.Linq.Expressions;
using System.Reflection;


namespace FruitBaskets.Products.Infrastructure
{
    public class DataPersistency:IDataPersistency
    {
        private readonly string dbPath;
        public DataPersistency()
        {
            dbPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "database.db");
         
           
        }
        private string ConnectionString => $"Filename={dbPath};connection=shared";


        public async Task CreateAsync<T>(T entity) where T : Entity
        {
          
            await Task.Run(() =>
             {
                 using (var db = new LiteDatabase(ConnectionString))
                 {
                     var collectionName = typeof(T).Name;
                    
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
           return await Task.Run(() =>
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
        }

        public async Task<IEnumerable<T>> GetAsync<T>(Func<T, bool> predicate) where T : Entity
        {
           return await Task.Run(() =>
            {
                using (var db = new LiteDatabase(ConnectionString))
                {
                    var collectionName = typeof(T).Name;
                    if (!db.CollectionExists(collectionName))
                    {
                        throw new Exception($"Collection '{collectionName}' not found");
                    }
                    Expression<Func<T,bool>> expression = p=>predicate(p);
                    var collections = db.GetCollection<T>(collectionName);
                    return collections.Find(expression);

                }
            });
           
        }

        public async Task<T> GetByIdAsync<T>(Guid id) where T : Entity
        {
           return await Task.Run(() =>
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
