using System.Collections.Generic;
using System.Threading.Tasks;

namespace _2bAdvice.Students.Repositories
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<T?> GetAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
