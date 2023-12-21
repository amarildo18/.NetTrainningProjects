using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController :ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;
        public PersonController(ILogger<PersonController> logger, IPersonService personService) 
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var people = _personService.GetAll();

            return Ok(people);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(long id)
        {
            var person = _personService.GetById(id);
            if (person == null)
            {
                return BadRequest("Invalid operation");
            }

            return Ok(person);
        }

        [HttpPost]
        public ActionResult<Person> Create([FromBody] Person person)
        {
             
            if(person == null)
            {
                return BadRequest();
            }

            return Ok(_personService.Create(person));
        }

        [HttpPut]
        public ActionResult<Person> Update([FromBody] Person person)
        {

            if (person == null)
            {
                return BadRequest();
            }

            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteById(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
