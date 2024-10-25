using CoreDomain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDomain.Entity;

public class Address : BaseEntity<int>
{
    [ForeignKey("PersonAddress")]
    public int PersonId { get; set; }
    public Person PersonAddress { get; set; }


    public string Name { get; set; } = string.Empty;
    public string Address1 { get; set; } = string.Empty;
    public string? Address2 { get; set; }

    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string Postcode { get; set; } = string.Empty;

    public AddressType AddressType { get; set; }
}
