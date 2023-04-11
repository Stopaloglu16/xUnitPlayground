using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreDomain.Entity
{
    public class Person : BaseEntity<int>
    {
        public Person()
        {

            AddressList = new List<Address>();
        }

        public Person(int Id, string FirstName, string LastName)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            //AddressList = new HashSet<Address>();
            AddressList = new List<Address>();
        }



        [Required]
        [MinLength(5)]
        public string FirstName { get; set; }

        public string LastName { get; set; } = string.Empty;

        [InverseProperty("PersonAddress")]
        public virtual ICollection<Address> AddressList { get; set; } = new List<Address>();


    }
}
