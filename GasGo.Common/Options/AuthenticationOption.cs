using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasGo.Common.Options
{
    public class AuthenticationOption
    {
        public string Authority { get; set; } = null!;
        public bool ValidateIssuer { get; set; }
        public IEnumerable<string> ValidIssuers { get; set; } = null!;
        public bool ValidateAudience { get; set; }
        public IEnumerable<string> ValidAudiences { get; set; } = null!;
        public bool ValidateLifetime { get; set; }
        public bool ValidateIssuerSigningKey { get; set; }
        public string MetadataAddress { get; set; } = null!;

    }
}
