using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEb_PhysicalPerson_API.Models
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Your number length must be 9")]
        public string Number { get; set; }
        public int? PersonId { get; set; }
        public Person Person { get; set; }
    }
}
