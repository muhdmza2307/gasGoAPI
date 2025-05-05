using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasGo.Common.Enums
{
    public enum FuelOrderPackage
    {
        [Description("Small Package - 20 Liters")]
        Small = 20,

        [Description("Medium Package - 40 Liters")]
        Medium = 40,

        [Description("Large Package - 60 Liters")]
        Large = 60
    }
}
