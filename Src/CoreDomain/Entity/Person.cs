using System.ComponentModel.DataAnnotations;

namespace CoreDomain.Entity
{
    public class Person : BaseEntity<int>
    {
        public Person()
        {

            AddressList = new HashSet<Address>();
        }

        public Person(int Id, string FirstName, string LastName)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            AddressList = new HashSet<Address>();
        }



        [Required]
        [MinLength(5)]
        public string FirstName { get; set; }

        public string LastName { get; set; } = string.Empty;

        public ICollection<Address> AddressList { get; set; }


    }
}
