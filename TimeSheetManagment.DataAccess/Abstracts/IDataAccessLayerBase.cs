using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheetManagment.DataAccess.Abstract
{
    public interface IDataAccessLayerBase<T>
    {
        Task<T> GetAsync(int id, bool includeChild=false);
        Task<IEnumerable<T>> GetAllAsync(bool includeChild=false);
        Task<bool> SaveAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}