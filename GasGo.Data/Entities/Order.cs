using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasGo.Common.Enums;

namespace GasGo.Data.Entities
{
    public class Order : EntityBase
    {
        public Guid CustomerVehicleId { get; set; }
        public Guid DriverVehicleId { get; set; }
        public FuelOrderPackage PackageId { get; set; }
        public FuelOrderStatus StatusId { get; set; }

        public OrderPackage Package { get; set; } = null!;
        public OrderStatus Status { get; set; } = null!;
        public UserVehicle CustomerVehicle { get; set; } = null!;
        public UserVehicle DriverVehicle { get; set; } = null!;
    }
}
