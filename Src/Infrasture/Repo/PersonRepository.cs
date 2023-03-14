using AutoMapper;
using CoreDomain.Aggregate;
using CoreDomain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrasture.Repo
{
    public class PersonRepository : EfCoreRepository<Person>, IPersonRepository
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PersonRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PersonDto> CreatePerson(PersonDto createRequest)
        {
         var newPerson = await _dbContext.AddAsync(new Person() { Id = createRequest.Id, FirstName = createRequest.FirstName, LastName = createRequest.LastName });

            return createRequest;

        }

        public Task<IEnumerable<PersonDto>> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
