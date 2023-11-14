using System.ComponentModel.DataAnnotations;
using WEb_PhysicalPerson_API.Models;

namespace WEb_PhysicalPerson_API.DTOs.PhoneNumberDTO
{
    public class GetPhoneDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Your number length must be 9")]
        public string Number { get; set; }
        public int? PersonId { get; set; }

    }
}
