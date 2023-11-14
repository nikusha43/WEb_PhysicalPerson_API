using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WEb_PhysicalPerson_API.Attributes
{
    public class LanguageValidation : ValidationAttribute
    {

        Regex regexObj = new Regex(@"^[a-zA-Z]+$");
        string symbols = "აბგდევზთიკლმნოპრსტუფქღყშჩცძწჭხჯჰ";

        public override bool IsValid(object? value)
        {
            Match match = regexObj.Match(value as string);
            var result = value.ToString().Where(o => symbols.Any(s => s == o)).Count() == value.ToString().Length;

            if (!match.Success)
            {
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
