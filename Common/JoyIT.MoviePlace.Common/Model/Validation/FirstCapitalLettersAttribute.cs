using System.ComponentModel.DataAnnotations;

namespace JoyIT.MoviePlace.Common.Model.Validation
{
    public class FirstCapitalLettersAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(value?.ToString())) return ValidationResult.Success;

            var words = value.ToString().Split(" ");

            if (words.Length > 0)
            {
                foreach (var word in words)
                {
                    var firstLetter = word.Trim()[0].ToString();
                    if (firstLetter != firstLetter.ToUpper()) return new ValidationResult("Las primeras letras de las palabras ingresadas deben estar en mayúscula.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
