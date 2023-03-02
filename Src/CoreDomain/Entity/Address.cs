using CoreDomain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.Entity
{
    public class Address
    {
        public int PersonId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string? Address2 { get; set; }

        public string City { get; set; } = string.Empty;

        public AddressType AddressType { get; set; }
    }
}
