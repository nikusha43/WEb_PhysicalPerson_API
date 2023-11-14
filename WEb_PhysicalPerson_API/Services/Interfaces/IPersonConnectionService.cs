using WEb_PhysicalPerson_API.DTOs.ConnectedPersonDTO;

namespace WEb_PhysicalPerson_API.Services.Interfaces
{
    public interface IPersonConnectionService
    {
        Task<bool> AddPersonConnection(ConnectedPersonDTO connectionDTO);
        Task<bool> DeletePersonConnection(int personId, int connectionPersonId);
        Task<List<ConnectedPersonDTO>> GetAllPersonConnections();
    }
}
