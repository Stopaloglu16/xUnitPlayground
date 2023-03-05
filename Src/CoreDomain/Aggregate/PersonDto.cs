using CoreDomain.Entity;
using System.ComponentModel.DataAnnotations;

namespace CoreDomain.Aggregate
{
    public class PersonDto : IMapFrom<Person>
    {
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }
        public string LastName { get; set; }
    }
}
