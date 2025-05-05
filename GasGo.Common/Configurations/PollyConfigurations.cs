using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasGo.Common.Configurations
{
    public static class PollyConfigurations
    {
        public static TimeSpan[] ForOneSecondIncreasesUpToThree() =>
        [
            TimeSpan.FromSeconds(1),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(3)
        ];
    }
}
