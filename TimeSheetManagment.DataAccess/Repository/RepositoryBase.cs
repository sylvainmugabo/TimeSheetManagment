using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheetManagment.Data;
using TimeSheetManagment.DataAccess.Abstract;
using TimeSheetManagment.DataAccess.Abstracts;

namespace TimeSheetManagment.DataAccess.Repository
{
    public class RepositoryBase<TObject>
           : IRepositoryBase<TObject> where TObject : class, IEntity<int>
    {
        private readonly TimeSheetManagmentDBContext _context;
        private readonly DbSet<TObject> _entities;
        private readonly ILogger<TObject> _logger;
        private readonly IDataAccessLayerBase<TObject> _dataAccessLayer;

        public RepositoryBase(TimeSheetManagmentDBContext context,
            ILogger<TObject> logger,
            IDataAccessLayerBase<TObject> dataAccessLayer)
        {
            _context = context;
            _entities = context.Set<TObject>();
            _logger = logger;
            _dataAccessLayer = dataAccessLayer;
        }
        public async Task<bool> DeleteAsync(TObject entity)
        {
           return await _dataAccessLayer.DeleteAsync(entity);
        }

        public async Task<IEnumerable<TObject>> GetAllAsync()
        {
            _logger.LogError("Inside GetAllAsync");
            var result = await _dataAccessLayer.GetAllAsync();
            return result;
        }

        public async Task<TObject> GetAsync(int id)
        {
            var result = await _dataAccessLayer.GetAsync(id);
            return result;
        }

        public async Task<bool> SaveAsync(TObject entity)
        {
            return await _dataAccessLayer.SaveAsync(entity);
        }
    }
}
