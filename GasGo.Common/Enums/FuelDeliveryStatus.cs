using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasGo.Common.Enums
{
    public enum FuelDeliveryStatus
    {
        [Description("Scheduled for Pickup")] 
        Scheduled = 1,

        [Description("En Route to Customer")]
        PickedUp = 2,

        [Description("Successfully Delivered")]
        Delivered =3
    }
}
