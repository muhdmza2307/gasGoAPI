using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasGo.Common.Options
{
    public class SqlServerOption
    {
        public string ServerName { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Port { get; set; } = null!;
        public bool UseIntegratedSecurity { get; set; }
    }
}
