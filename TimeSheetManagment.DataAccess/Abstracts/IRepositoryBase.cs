using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheetManagment.Data;

namespace TimeSheetManagment.DataAccess.Abstracts
{
    public interface IRepositoryBase<T> where T
        : IEntity<int>
    {
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> SaveAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
