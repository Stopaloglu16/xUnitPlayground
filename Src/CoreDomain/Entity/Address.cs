using CoreDomain.Enum;

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
