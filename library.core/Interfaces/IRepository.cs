using library.core;
using System.Linq.Expressions;
namespace library.core
{
    public interface IRepository<T> where T: Entity
    {
        Task<T?> GetEntityById(long id);
        IQueryable<T> ListAsync();
        IQueryable<T> ListAsync(Expression<Func<T, bool>> predicate);
    }
}
