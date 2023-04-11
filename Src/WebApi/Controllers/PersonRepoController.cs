using AutoMapper;
using CoreDomain.Aggregate;
using CoreDomain.Entity;
using Infrasture.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonRepoController : ControllerBase
    {

     
        private readonly ILogger _logger;

        private readonly IPersonRepository _personRepository;


        public PersonRepoController(IPersonRepository personRepository, ILogger logger = null)
        {
            _personRepository = personRepository;
            _logger = logger;

        }

        [HttpGet]
        public async Task<IEnumerable<Person>> Get(bool IsActive)
        {
            return await _personRepository.GetAll().ToListAsync();
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<Person>> GetById(int Id)
        {
            
            return await _personRepository.GetByIdAsync(Id);

            //var person = await _service.GetByIdAsync(Id);

            //return Ok(person);
        }


        [HttpPost]
        public async Task<Person> Create(Person createRequest)
        {

            return await _personRepository.AddAsync(createRequest); 
            

        }




    }





}
