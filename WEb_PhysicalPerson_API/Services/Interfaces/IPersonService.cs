using System.ComponentModel;
using WEb_PhysicalPerson_API.DTOs;
using WEb_PhysicalPerson_API.DTOs.PersonDTO;

namespace WEb_PhysicalPerson_API.Services.Interfaces
{
    public interface IPersonService
    {
        Task<List<GetPersonDTO>> GetAllPersons();
        Task<GetPersonDTO> GetPersonById(int personId);
        Task<GetPersonDTO> AddPerson(AddPersonDTO newPerson);
        Task<GetPersonDTO> UpdatePerson(int personId, UpdatePersonDTO updatedPerson);
        Task<bool> DeletePerson(int personId);


    }
}
