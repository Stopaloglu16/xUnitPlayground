using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.Entity
{
    public class Person
    {

        public Person() {
            AddressList = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public ICollection<Address> AddressList { get; set; } 


    }
}
