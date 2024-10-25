using CoreDomain.Aggregate;
using CoreDomain.Entity;
using Infrasture.Repo;

namespace WebApi.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        public PersonService(IPersonRepository _person )
        {
            personRepository = _person;
        }

        public async Task<int> Add(PersonDto createRequest)
        {
            var newPerson = await personRepository.AddAsync(new Person() { FirstName = createRequest.FirstName, LastName = createRequest.LastName });

            return newPerson.Id;    
        }

        public async Task<PersonDto> GetByIdAsync(int Id)
        {
            var myPerson = await personRepository.GetByIdAsync(Id);
            
            return new PersonDto() {  Id = myPerson.Id, FirstName = myPerson.FirstName, LastName = myPerson.LastName };

        }

        public async Task<IEnumerable<PersonDto>> GetList()
        {
            return await personRepository.GetList();
        }
    }
}
