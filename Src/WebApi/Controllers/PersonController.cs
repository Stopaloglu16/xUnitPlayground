using CoreDomain.Aggregate;
using CoreDomain.Entity;
using Infrasture.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonRepository _repo;
        private readonly ILogger _logger;

        public PersonController(IPersonRepository repo, ILogger logger = null)
        {
            _repo = repo;
            _logger = logger;
            //_repo.FailedDatabaseRequest += Repo_FailedDatabaseRequest;
        }

        [HttpGet]
        public  IEnumerable<Person> Get(bool IsActive)
        {


            return _repo.GetAll();
        }


        [HttpPost]
        public async Task<PersonDto> Create(PersonDto person)
        {

            return await _repo.CreatePerson(person);
        }

    }
}
