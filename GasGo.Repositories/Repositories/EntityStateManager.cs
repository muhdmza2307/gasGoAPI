using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasGo.Data.Entities;
using GasGo.Data;
using GasGo.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GasGo.Repositories.Repositories
{
    public class EntityStateManager : IEntityStateManager
    {
        private readonly IDataContext _dbContext;

        public EntityStateManager(IDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Detach<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            var existingEntity = _dbContext.Entry(entity);
            existingEntity.State = EntityState.Detached;
        }

        public void GenerateIdAndSetAsModified<TEntity>(TEntity entity) where TEntity : EntityBase
        {
            var newEntity = _dbContext.Add(entity);
            newEntity.State = EntityState.Modified;
        }

        public IEnumerable<TEntity> ChangeTrackerEntries<TEntity>() where TEntity : EntityBase
        {
            return _dbContext.ChangeTracker.Entries<TEntity>()
                .Select(entry => entry.Entity);
        }
    }
}
