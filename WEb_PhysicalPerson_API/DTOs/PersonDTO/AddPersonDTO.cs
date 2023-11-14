using System.ComponentModel.DataAnnotations;
using WEb_PhysicalPerson_API.Attributes;
using WEb_PhysicalPerson_API.DTOs.PersonDTO;
using WEb_PhysicalPerson_API.Enums;
using WEb_PhysicalPerson_API.Models;

namespace WEb_PhysicalPerson_API.DTOs.PersonDTO
{
    public class AddPersonDTO
    {
        [Required]
        [StringLength(52, MinimumLength = 2, ErrorMessage = "Your name length must be between 2 and 52")]
        [LanguageValidation]
        public string Name { get; set; }

        [Required]
        [StringLength(52, MinimumLength = 2, ErrorMessage = "Your surname length must be between 2 and 52")]
        [LanguageValidation]
        public string LastName { get; set; }

        [Required]
        public Gender GenderType { get; set; }

        [DateOfBirth(MinAge = 18, ErrorMessage = "Minimum age is 18")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Your cardId length must be 11")]
        public string PersonalIdNumber { get; set; }

        [Required]
        public int CityId { get; set; }
        public string Photo { get; set; }

    }

}
