using Bogus;
using EntityPerson = CoreDomain.Entity;
using Bogus.Extensions.UnitedKingdom;

namespace xUnitBogus
{
    public class Fakers
    {

        public Faker<EntityPerson.Person> GetPersonGenerator()
        {
            var addressFaker = GetAddressGenerator();

            var personFake = new Faker<EntityPerson.Person>()
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.LastName, f => f.Person.LastName)
                .RuleFor(p => p.AddressList, f => f.Make(2, () => addressFaker.Generate(1).First()));

            return personFake;
        }


        public Faker<EntityPerson.Address> GetAddressGenerator()
        {
            var faker = new Faker("en_GB");

            var addressFake = new Faker<EntityPerson.Address>()
                //.RuleFor(p => p.da , f => f.Address.CountryOfUnitedKingdom()) // .StreetName())
                .RuleFor(p => p.Address1, f => f.Address.StreetName())
                .RuleFor(p => p.Address2, f => f.Address.SecondaryAddress().OrNull(f, .5f))
                .RuleFor(p => p.City, f => f.Address.City())
                .RuleFor(p => p.Country, f => f.Address.Country())
                .RuleFor(p => p.CountryCode, f => f.Address.CountryCode())
                .RuleFor(p => p.Postcode, f => f.Address.ZipCode());

            

            return addressFake;
        }

    }
}
