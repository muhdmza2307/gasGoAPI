using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasGo.Common.Configurations;
using Polly;

namespace GasGo.Repositories
{
    public static class PollyExecutor
    {
        public static async Task<T> ExecuteWithRetryAsync<T>(Func<Task<T>> action)
        {
            var policy = Policy<T>
                .Handle<Exception>()
                .WaitAndRetryAsync(PollyConfigurations.ForOneSecondIncreasesUpToThree());

            return await policy.ExecuteAsync(action);
        }
    }

}
