using WEb_PhysicalPerson_API.DTOs.PhoneNumberDTO;

namespace WEb_PhysicalPerson_API.Services.Interfaces
{
    public interface IPhoneService
    {
        Task<List<GetPhoneDTO>> GetAllPhones();
        Task<GetPhoneDTO> GetPhoneByPersonId(int PersonId);
        Task<GetPhoneDTO> AddPhoneNumber(AddPhoneDTO Newphone, int personId);
        Task<GetPhoneDTO> UpdatePhoneNumber(int Person_Id, UpdatePhoneDTO Updatedphone);
        Task<bool> DeletePhoneNumber(int phoneId);

    }
}
