using System.ComponentModel.DataAnnotations;

namespace WEb_PhysicalPerson_API.Attributes
{
    public class DateOfBirthAttribute : ValidationAttribute
    {
        public int MinAge { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var val = (DateTime)value;

            if (val.AddYears(MinAge) <= DateTime.Now)
                return true;

            return false;
        }
    }

}
