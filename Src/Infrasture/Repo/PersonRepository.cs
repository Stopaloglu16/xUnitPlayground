using AutoMapper;
using AutoMapper.QueryableExtensions;
using CoreDomain.Aggregate;
using CoreDomain.Entity;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Person> CreatePerson(Person createRequest)
        {
            try
            {
                

                var rr =  await _dbContext.Persons.AddAsync(createRequest);
                await _dbContext.SaveChangesAsync();

                return createRequest;
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }

        public async Task<IEnumerable<PersonDto>> GetList()
        {

            List<PersonDto> myRtn = new List<PersonDto>();
            try
            {
                var myList = await GetAll().ToListAsync();

                foreach (var item in myList)
                {

                    myRtn.Add(new PersonDto { Id = item.Id, FirstName = item.FirstName, LastName = item.LastName });

                }

                return myRtn;
            }
            catch (Exception ex)
            {
                return new List<PersonDto>();
            }

        }

        
    }
}
