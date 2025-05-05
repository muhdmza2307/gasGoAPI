using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasGo.Common.Enums;

namespace GasGo.Data.Entities
{
    public class UserVehicle : EntityBase
    {
        public Guid UserRoleId { get; set; }
        public string PlateNumber { get; set; } = null!;
        public FuelTypeEnum FuelTypeId { get; set; }

        public UserRole UserRole { get; set; } = null!;
        public ICollection<Order>? CustomerOrders { get; set; }
        public ICollection<Order>? DriverAssignments { get; set; }
    }
}
