using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasGo.Data.Entities;

namespace GasGo.Repositories.Repositories.Interfaces
{
    public interface IGetRepository<TEntity> where TEntity : EntityBase
    {
        public Task<TEntity?> GetAsync(Guid id);
    }
}
