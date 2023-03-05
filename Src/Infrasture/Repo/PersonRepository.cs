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

        public Task<PersonDto> CreatePerson(PersonDto createRequest)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PersonDto>> GetList()
        {
            throw new NotImplementedException();
        }
    }
}
