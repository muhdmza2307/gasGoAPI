using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasGo.Data.Entities;

namespace GasGo.Repositories.Repositories.Interfaces
{
    public interface IEntityStateManager
    {
        void Detach<TEntity>(TEntity entity) where TEntity : EntityBase;
        void GenerateIdAndSetAsModified<TEntity>(TEntity entity) where TEntity : EntityBase;
        IEnumerable<TEntity> ChangeTrackerEntries<TEntity>() where TEntity : EntityBase;
    }
}
