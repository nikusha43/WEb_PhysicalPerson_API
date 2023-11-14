using Microsoft.AspNetCore.Mvc;
using WEb_PhysicalPerson_API.DTOs;
using WEb_PhysicalPerson_API.DTOs.PersonDTO;
using WEb_PhysicalPerson_API.Services.Interfaces;

namespace WEb_PhysicalPerson_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        public PersonController(IPersonService personService)
        {
                _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPersonDTO>>> GetAll()
        {
            return await _personService.GetAllPersons();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetPersonDTO>> GetSinglePerson(int id)
        {
            return await _personService.GetPersonById(id);
        }

        [HttpPost]
        public async Task<ActionResult<GetPersonDTO>> CreatePerson(AddPersonDTO newperson)
        {
            return await _personService.AddPerson(newperson);
        }

        [HttpPut]
        public async Task<ActionResult<GetPersonDTO>> UpdatePerson(int personId, UpdatePersonDTO updatedPerson)
        {
            var response = await _personService.UpdatePerson(personId, updatedPerson);

            if (response == null)
            {
                return NotFound(response);
            }

            return response;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePerson(int id)
        {
            var response = await _personService.DeletePerson(id);
            if (response == false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

       

    }

}

