using CoreDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnitExamples
{
    public class ObjectCompare
    {
        private readonly Person person1;
        private readonly Person person2;
        private readonly Address address1;

        public ObjectCompare( )
        {
            person1 = new Person() { Id = 1, FirstName = "Jack", LastName = "White" };
            person2 = new Person() { Id = 2, FirstName = "John", LastName = "White" };
        }     

        [Fact]
        public void ObjectComparisons()
        {

            Assert.NotSame( person1, person2 );

            Assert.IsType<Person>(person2);
            Assert.IsNotType<Person>(address1);
        }
    }
}
