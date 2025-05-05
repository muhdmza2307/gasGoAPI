using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasGo.Common.Enums
{
    public enum RoleEnum
    {
        [Description("Admin")] Admin = 1,
        [Description("Customer")] Customer = 2,
        [Description("Driver")] Driver = 3
    }
}
