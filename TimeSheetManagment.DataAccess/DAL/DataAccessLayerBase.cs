using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheetManagment.Data;
using TimeSheetManagment.DataAccess.Abstract;

namespace TimeSheetManagment.DataAccess.DAL
{
    public class DataAccessLayerBase<TObject> : 
        IDataAccessLayerBase<TObject> where TObject: 
        class,IEntity<int>
    {
        private readonly TimeSheetManagmentDBContext _context;
        private readonly DbSet<TObject> _entities;

        public DataAccessLayerBase(TimeSheetManagmentDBContext context)
        {
            
            _context = context;
            _entities=context.Set<TObject>();
        }

        public async Task<bool> DeleteAsync(TObject entity)
        {
            _entities.Remove(entity);
           return  await (_context.SaveChangesAsync())>0;
        }

        public async Task<IEnumerable<TObject>> GetAllAsync(bool includeChild = false)
        {
           
           var result= await _entities.ToListAsync();            
           return result;
        
        }

        public Task<TObject> GetAsync(int id, bool includeChild = false)
        {
            var result =_entities.FirstOrDefaultAsync(o => o.Id == id);
            return result;
        }

       

        public async Task<bool> SaveAsync(TObject entity)
        {
            await _entities.AddAsync(entity);
            return (await _context.SaveChangesAsync())>0;
        }

    }
}
