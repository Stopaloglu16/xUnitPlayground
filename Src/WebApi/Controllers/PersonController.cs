using CoreDomain.Aggregate;
using CoreDomain.Entity;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private readonly IPersonService _service;

        private readonly ILogger _logger;

      

        public PersonController(IPersonService personService, ILogger logger = null)
        {
            _service = personService;
            _logger = logger;
            
        }

        [HttpGet]
        public async Task<IEnumerable<PersonDto>> Get(bool IsActive)
        {
            return await _service.GetList();
        }


        [HttpGet("{Id}")]
        public async Task<ActionResult<Person>> GetById(int Id)
        {

           var person = await _service.GetByIdAsync(Id);

           return Ok(person);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create(PersonDto createRequest)
        {
            try
            {
                var rrId = await _service.Add(createRequest);
                return Ok(rrId);
            }
            catch (Exception ex)
            {
                throw;
            }
        }




    }





}
