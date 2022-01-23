using BlazorCRUDApp.Server.Models;
using BlazorCRUDApp.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUDApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<List<Person>> GetAll()
        {
            return await _personService.GetAllPersons();
        }

        [HttpGet("{id}")]
        public async Task<Person> Get(int id)
        {
            return await _personService.GetPerson(id);
        }

        [HttpPost]
        public async Task<Person> AddPerson([FromBody] Person person)
        {
           return await _personService.AddPerson(person);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeletePerson(int id)
        {
            await _personService.DeletePerson(id); return true;
        }

        [HttpPut("{id}")]
        public async Task<bool> UpdatePerson(int id, [FromBody] Person Object)
        {
            await _personService.UpdatePerson(id, Object); return true;
        }
    }
}
