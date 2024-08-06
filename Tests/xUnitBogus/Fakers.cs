using Bogus;
using EntityPerson = CoreDomain.Entity;

namespace xUnitBogus
{
    public class Fakers
    {

        public Faker<EntityPerson.Person> GetPersonGenerator()
        {
            var personFake = new Faker<EntityPerson.Person>()
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.LastName, f => f.Person.LastName);

            //personFake.Generate(10);

            return personFake;
        }

    }
}
