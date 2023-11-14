using WEb_PhysicalPerson_API.Enums;

namespace WEb_PhysicalPerson_API.DTOs.ConnectedPersonDTO
{
    public class ConnectedPersonDTO
    {
        public int personId { get; set; }
        public int connectionPersonId { get; set; }
        public ConnectionType ConnectionType { get; set; }
    }

}
