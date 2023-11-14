using WEb_PhysicalPerson_API.Enums;
using WEb_PhysicalPerson_API.Models;

namespace WEb_PhysicalPerson_API.DTOs
{
    public class GetPersonDTO
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string LastName { get; set; }
            public Gender GenderType { get; set; }
            public DateTime BirthDate { get; set; }
            public string PersonalIdNumber { get; set; }
            public int CityId { get; set; }  

    }
}
