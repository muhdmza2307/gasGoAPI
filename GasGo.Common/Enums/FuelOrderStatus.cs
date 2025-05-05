using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasGo.Common.Enums
{
    public enum FuelOrderStatus
    {
        [Description("Order has been created")]
        Created = 1,

        [Description("Order has been confirmed by the system or user")]
        Confirmed = 2,

        [Description("Order is currently in progress")]
        InProgress = 3,

        [Description("Order has been successfully delivered")]
        Delivered = 4,

        [Description("Order has been cancelled")]
        Cancelled = 5
    }
}
