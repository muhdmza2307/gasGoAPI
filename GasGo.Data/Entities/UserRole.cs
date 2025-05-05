using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GasGo.Common.Enums;

namespace GasGo.Data.Entities
{
    public class UserRole : EntityBase
    {
        public RoleEnum RoleId { get; set; }
        public Guid UserId { get; set; }


        public Role Role { get; set; } = null!;
        public User User { get; set; } = null!;
        public ICollection<UserVehicle> UserVehicles { get; set; }
    }
}
