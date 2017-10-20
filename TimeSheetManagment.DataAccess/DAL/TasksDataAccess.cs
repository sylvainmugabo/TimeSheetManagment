using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheetManagment.Data;
using TimeSheetManagment.DataAccess.Abstract;

namespace TimeSheetManagment.DataAccess.DAL
{
    public class TasksDataAccess : IDataAccessLayerBase<Tasks>
    {
        private readonly TimeSheetManagmentDBContext _context;

        public TasksDataAccess(TimeSheetManagmentDBContext context)
        {
            _context = context;
        }
        public async Task<bool> DeleteAsync(Tasks entity)
        {
            _context.Remove(entity);
            return (await _context.SaveChangesAsync()) > 0;

        }

        public async Task<IEnumerable<Tasks>> GetAllAsync(bool includeChild = false)
        {
            if (includeChild)
                return await _context.Tasks.Include(x => x.Project).ToListAsync();
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Tasks> GetAsync(int id, bool includeChild = false)
        {
            if (includeChild)
                return await _context.Tasks.Include(x => x.Project).SingleOrDefaultAsync(t => t.Id == id);
            return await _context.Tasks.SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task<bool> SaveAsync(Tasks entity)
        {
            await _context.AddAsync(entity);
            return await (_context.SaveChangesAsync()) > 0;
        }
    }
}
