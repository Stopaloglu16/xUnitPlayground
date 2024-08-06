using AutoMapper;
using Bogus;
using Infrasture.Repo;
using Microsoft.EntityFrameworkCore;
using EntityPerson = CoreDomain.Entity;

namespace xUnitBogus
{
    public class PersonRepoTest
    {

        public ApplicationDbContext DbContext { get; private set; }
        public IMapper Mapper { get; private set; }
        public PersonRepository PersonRepository { get; private set; }


        public PersonRepoTest()
        {
            // Set up in-memory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            DbContext = new ApplicationDbContext(options);
           

            // Initialize the repository
            PersonRepository = new PersonRepository(DbContext, null);

            // Seed the database if needed
            //SeedDatabase();
        }


        [Fact]
        public void Test1()
        {
            //Arrange
            EntityPerson.Person person = new();
            Fakers _fakers = new Fakers();

            //Act
            var personList = _fakers.GetPersonGenerator().Generate(10);

            foreach (var item in personList)
            {
                PersonRepository.AddAsync(item);
            }

            var personListDb = PersonRepository.GetAll();

            //Assert
            Assert.Equal(10, personList.Count);

        }


    }
}