using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasGo.Data.Entities
{
    public class OrderAddress : EntityBase
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Street { get; set; } = null!;
        public string State { get; set; } = null!;
        public string PostalCode { get; set; } = null!;

        public Order Order { get; set; } = null!;
    }
}
