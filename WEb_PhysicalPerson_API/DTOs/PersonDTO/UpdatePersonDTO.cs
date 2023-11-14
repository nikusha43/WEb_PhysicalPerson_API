using System.ComponentModel.DataAnnotations;
using WEb_PhysicalPerson_API.Attributes;
using WEb_PhysicalPerson_API.Enums;
using WEb_PhysicalPerson_API.Models;

namespace WEb_PhysicalPerson_API.DTOs
{
    public class UpdatePersonDTO
    {
        [StringLength(52, MinimumLength = 2, ErrorMessage = "Your name length must be between 2 and 52")]
        [LanguageValidation]
        public string Name { get; set; }

        [StringLength(52, MinimumLength = 2, ErrorMessage = "Your surname length must be between 2 and 52")]
        [LanguageValidation]
        public string LastName { get; set; }

        public Gender? GenderType { get; set; }

        [DateOfBirth(MinAge = 18, ErrorMessage = "Minimum age is 18")]
        public DateTime? BirthDate { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "Your cardId length must be 11")]
        public string PersonalIdNumber { get; set; }

        public int? CityId { get; set; }

    }
}
