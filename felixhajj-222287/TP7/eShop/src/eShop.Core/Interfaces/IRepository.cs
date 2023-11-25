using eShop.Core.Entities;

namespace eShop.Core.Interfaces
{
    public interface IRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        Task<T> CreateAsync(T entity);
        Task DeleteAsync(string id);
        Task<T> UpdateAsync(T entity);
    }

    public interface IReadRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<long> GetCountAsync();
    }
}
