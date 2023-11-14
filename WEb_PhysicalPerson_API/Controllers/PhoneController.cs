using Microsoft.AspNetCore.Mvc;
using WEb_PhysicalPerson_API.Data;
using WEb_PhysicalPerson_API.DTOs.ConnectedPersonDTO;
using WEb_PhysicalPerson_API.DTOs.PhoneNumberDTO;
using WEb_PhysicalPerson_API.Services.Interfaces;

namespace WEb_PhysicalPerson_API.Controllers
{
    [Route("api/phones")]
    [ApiController]
    public class PhoneController : Controller
    {
        private readonly IPhoneService _phoneSer;
        private readonly ApplicationDbContext _Db;

        public PhoneController(IPhoneService phoneSer, ApplicationDbContext applicationDb)
        {
            _Db = applicationDb;
            _phoneSer = phoneSer;
        }

        [HttpGet/*("{GetAll}")*/]
        public async Task<ActionResult<List<GetPhoneDTO>>> GetAllPhones()
        {
            return await _phoneSer.GetAllPhones();
        }

        [HttpGet("{GetBypersonId}")]
        public async Task<ActionResult<GetPhoneDTO>> GetPhoneByPersonId(int personId)
        {
           return await _phoneSer.GetPhoneByPersonId(personId);
        }

        [HttpPost("{Add}")]
        public async Task<ActionResult<GetPhoneDTO>> AddPhoneNumber([FromBody] AddPhoneDTO Newphone, int personId)
        {
            return await _phoneSer.AddPhoneNumber(Newphone, personId);
        }


        [HttpPut("{phoneId}")]
        public async Task<IActionResult> UpdatePhoneNumber(int phoneId, UpdatePhoneDTO Updatedphone)
        {
            var response = await _phoneSer.UpdatePhoneNumber(phoneId, Updatedphone);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }


        [HttpDelete("{Delete}")]
        public async Task<ActionResult<bool>>DeletePhoneNumber(int phoneId)
        {
            var response = await _phoneSer.DeletePhoneNumber(phoneId);

            if (response == false)
            {
                return NotFound(response);
            }
            return Ok(response);

        }
    }

}

