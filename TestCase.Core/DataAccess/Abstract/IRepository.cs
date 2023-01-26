using System.Linq.Expressions;

namespace TestCase.Core.DataAccess.Abstract;

public interface IRepository<T> where T : class, new()
{
    IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate = null);
    Task<T> AddAsync(T entity);
    Task AddManyAsync(IEnumerable<T> entities);
    Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> predicate);
    Task<T> DeleteAsync(Expression<Func<T, bool>> predicate);
}