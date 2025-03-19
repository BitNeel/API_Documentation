using library.core;

namespace library.Infrastructure
{
    internal interface IRepository<T> where T: Entity
    {
        Task<T> GetEntityById(long id);
        Task<List<T>> ListAsync();
        Task<List<T>> ListAsync(Func<T, bool> predicate);
    }
}
