using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasGo.Common.Enums;

namespace GasGo.Data.Entities
{
    public class OrderStatus
    {
        public FuelOrderStatus Id { get; set; }
        public string Description { get; set; } = null!;

        public ICollection<Order>? Orders { get; set; }
    }
}
