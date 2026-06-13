
using System.ComponentModel.DataAnnotations;

namespace LearningBasics
{
    public class GenderValidationAttribute : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var gender = value as string;
            if (gender == null)
            {
                return new ValidationResult("Gender can be M F or O");
            }
            if (gender.Equals("M", StringComparison.OrdinalIgnoreCase)
                || gender.Equals("F", StringComparison.OrdinalIgnoreCase)
                || gender.Equals("O", StringComparison.OrdinalIgnoreCase)
                )
            {
                 return ValidationResult.Success;
            }

            return new ValidationResult("Gender can be M F or O");
        }

    }
}