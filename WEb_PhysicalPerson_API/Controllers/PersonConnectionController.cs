using Microsoft.AspNetCore.Mvc;
using WEb_PhysicalPerson_API.DTOs;
using WEb_PhysicalPerson_API.DTOs.ConnectedPersonDTO;
using WEb_PhysicalPerson_API.Services.Implemetations;
using WEb_PhysicalPerson_API.Services.Interfaces;

namespace WEb_PhysicalPerson_API.Controllers
{
    public class PersonConnectionController : Controller
    {
        private readonly IPersonConnectionService _PersonConnService;
        public PersonConnectionController(IPersonConnectionService personService)
        {
            _PersonConnService = personService;
        }

        [HttpGet("Get-All-connections")]
        public async Task<ActionResult<List<ConnectedPersonDTO>>> GetAll()
        {
            return await _PersonConnService.GetAllPersonConnections();
        }

        [HttpPost("add-connection")]
        public async Task<IActionResult> AddPersonConnection([FromBody] ConnectedPersonDTO connectionDTO)
        {
            try
            {

                bool added = await _PersonConnService.AddPersonConnection(connectionDTO);

                if (added)
                {

                    return Ok("Connection added successfully.");
                }
                else
                {

                    return BadRequest("Failed to add connection. Check if persons exist or if the connection already exists.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpDelete("{personId}/connections/{connectionPersonId}")]
        public async Task<IActionResult> DeleteConnection(int personId, int connectionPersonId)
        {
            var result = await _PersonConnService.DeletePersonConnection(personId, connectionPersonId);

            if (result)
            {
                return NoContent(); // 204 No Content
            }
            else
            {
                return NotFound("Connection not found or could not be deleted.");
            }
        }


    }
}
