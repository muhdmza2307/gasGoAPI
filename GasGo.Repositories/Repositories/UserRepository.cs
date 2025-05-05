using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasGo.Common.Configurations;
using GasGo.Data;
using GasGo.Data.Entities;
using GasGo.Repositories.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Polly;

namespace GasGo.Repositories.Repositories
{
    public class UserRepository : RepositoryBase<User>,
    IUserRepository
    {
        public UserRepository(IEntityStateManager entityStateManager, 
            IDataContext dbContext) 
            : base(entityStateManager, dbContext)
        {
        }

        public async Task<User?> GetWithFullDetailsAsync(string externalUserId)
        {
            var user = await Policy<User?>
                .Handle<Exception>()
                .WaitAndRetryAsync(PollyConfigurations.ForOneSecondIncreasesUpToThree())
                .ExecuteAsync(async () => await DbContextField
                    .Where(u => u.ExternalUserId == externalUserId)
                    .Include(u => u.UserRoles!)
                    .ThenInclude(r => r.UserVehicles!)
                    .FirstOrDefaultAsync()
                    .ConfigureAwait(false));

            return user;
        }
    }
}
