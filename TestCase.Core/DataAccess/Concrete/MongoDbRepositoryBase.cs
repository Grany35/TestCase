using System.Linq.Expressions;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestCase.Core.DataAccess.Abstract;
using TestCase.Core.Settings;

namespace TestCase.Core.DataAccess.Concrete;

public class MongoDbRepositoryBase<T> : IRepository<T> where T : class, new()
{
    protected readonly IMongoCollection<T> _collection;

    protected MongoDbRepositoryBase(IMongoSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var db = client.GetDatabase(settings.Database);
        _collection = db.GetCollection<T>(typeof(T).Name.ToLowerInvariant());
    }

    public IQueryable<T> Get(Expression<Func<T, bool>> predicate = null)
    {
        return predicate == null
            ? _collection.AsQueryable()
            : _collection.AsQueryable().Where(predicate);
    }

    public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return _collection.Find(predicate).FirstOrDefaultAsync();
    }

    public async Task<T> AddAsync(T entity)
    {
        var options = new InsertOneOptions { BypassDocumentValidation = false };
        await _collection.InsertOneAsync(entity, options);
        return entity;
    }

    public async Task AddManyAsync(IEnumerable<T> entities)
    {
        var options = new InsertManyOptions{BypassDocumentValidation = false};
        await _collection.InsertManyAsync(entities, options);
    }

    public async Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate)
    {
        return await _collection.FindOneAndReplaceAsync(predicate, entity);
    }

    public async Task<T> DeleteAsync(Expression<Func<T, bool>> predicate)
    {
        return await _collection.FindOneAndDeleteAsync(predicate);
    }
}