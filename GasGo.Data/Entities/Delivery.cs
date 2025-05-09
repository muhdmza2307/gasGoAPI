using System;
using GasGo.Common.Enums;

namespace GasGo.Data.Entities
{
    public class Delivery : EntityBase
    {
        public Guid DriverVehicleId { get; set; }
        public Guid OrderId { get; set; }
        public FuelDeliveryStatus StatusId { get; set; }
        public DateTime ScheduledTime { get; set; }

        public DeliveryStatus Status { get; set; } = null!;
        public UserVehicle DriverVehicle { get; set; } = null!;
        public Order Order { get; set; } = null!;
    }
}