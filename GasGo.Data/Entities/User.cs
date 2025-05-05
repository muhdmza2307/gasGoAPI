using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasGo.Data.Entities
{
    public class User : EntityBase
    {
        public string Name { get; set; } = null!;
        public string ContactNo { get; set; } = null!;
        public string ExternalUserId { get; set; } = null!;

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
