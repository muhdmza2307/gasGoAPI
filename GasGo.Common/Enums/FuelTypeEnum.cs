using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasGo.Common.Enums
{
    public enum FuelTypeEnum
    {
        [Description("Petrol RON 95")] Ron95 = 1,
        [Description("Petrol RON 97")] Ron97 = 2,
        [Description("Diesel")] Diesel = 3
    }
}
