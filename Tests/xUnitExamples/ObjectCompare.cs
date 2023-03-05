using CoreDomain.Aggregate;
using CoreDomain.Entity;
using CoreDomain.Service;

namespace xUnitExamples
{
    public class ObjectCompare
    {
        private readonly Person person1;
        private readonly Person person2;
        private readonly Address address1;
        private readonly PersonService personService;

        public ObjectCompare()
        {
            person1 = new Person() { Id = 1, FirstName = "Jack", LastName = "White" };
            person2 = new Person() { Id = 2, FirstName = "John", LastName = "White" };
            this.personService = new PersonService();
        }

        [Fact]
        public void ObjectComparisons()
        {

            Assert.NotSame(person1, person2);

            Assert.IsType<Person>(person2);
            Assert.IsNotType<Person>(address1);
        }

        [Fact]
        public void ObjectMapComparisons()
        {
            var personDto = personService.GetPersonDto();

            Assert.Equal(1, personDto.Id);
            Assert.IsType<PersonDto>(personDto);

        }


        [Fact]
        public void ObjectException1_Fail()
        {
            //var personDto = personService.GetPersonDtoException1(1, null, "test");

            //Assert.IsType<PersonDto>(personDto);

            var ex1 = Assert.ThrowsAny<ArgumentException>(() => personService.GetPersonDtoException1(1, "ee", "test"));



        }

        [Fact]
        public void ObjectException1_Pass()
        {
            var personDto = personService.GetPersonDtoException1(1, "Michelle", "test");

            Assert.IsType<PersonDto>(personDto);

        }


        [Fact]
        public void ObjectException2()
        {
            var personDto = personService.GetPersonDtoException2();

            Assert.Null(personDto.FirstName);


            Assert.IsType<PersonDto>(personDto);

        }


    }
}
