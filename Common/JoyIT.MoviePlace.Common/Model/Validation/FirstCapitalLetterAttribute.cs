using System.ComponentModel.DataAnnotations;

namespace JoyIT.MoviePlace.Common.Model.Validation
{
    public class FirstCapitalLetterAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(value?.ToString())) return ValidationResult.Success;

            var firstLetter = value.ToString()[0].ToString();

            if (firstLetter != firstLetter.ToUpper()) return new ValidationResult("La primera letra debe ser mayúscula.");

            return ValidationResult.Success;
        }
    }
}
