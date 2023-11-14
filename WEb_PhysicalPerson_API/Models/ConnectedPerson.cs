using WEb_PhysicalPerson_API.Enums;

namespace WEb_PhysicalPerson_API.Models
{
    public class ConnectedPerson
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int connectionPersonId { get; set; }
        public ConnectionType ConnectionType { get; set; }
    }

}
