using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasGo.Data.Entities;

namespace GasGo.Repositories.Repositories.Interfaces
{
    public interface IUserRepository :
    IGetRepository<User>
    {
        public Task<User?> GetWithFullDetailsAsync(string externalUserId);
    }
}
