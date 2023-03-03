using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.Entity
{
    public class Person
    {
        public Person()
        {

            AddressList = new HashSet<Address>();
        }

        public Person(int Id, string FirstName, string LastName) {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            AddressList = new HashSet<Address>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(20)]
        public string FirstName { get; set; }

        public string LastName { get; set; } = string.Empty;

        public ICollection<Address> AddressList { get; set; } 


    }
}
