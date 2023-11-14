using System.ComponentModel.DataAnnotations;
using WEb_PhysicalPerson_API.Attributes;
using WEb_PhysicalPerson_API.Enums;

namespace WEb_PhysicalPerson_API.Models
{
    public class Person
    {
        public int Id { get; set; }

        [StringLength(52, MinimumLength = 2, ErrorMessage = "Your name length must be between 2 and 52")]
        [Required]
        [LanguageValidation]
        public string Name { get; set; }

        [StringLength(52, MinimumLength = 2, ErrorMessage = "Your surname length must be between 2 and 52")]
        [Required]
        [LanguageValidation]
        public string LastName { get; set; }

        public Gender GenderType { get; set; }
        [DateOfBirth(MinAge = 18, ErrorMessage = "Minimum age is 18")]
        public DateTime BirthDate { get; set; }
        public List<Phone> Phone { get; set; }
        public List<ConnectedPerson> RelatedPersons { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "Your cardId length must be 11")]
        [Required]
        public string PersonalIdNumber { get; set; }
        public int CityId { get; set; }
        public string Photo { get; set; }
    }
}
