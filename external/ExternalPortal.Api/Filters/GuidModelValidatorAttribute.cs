using System;
using System.ComponentModel.DataAnnotations;

namespace ExternalPortal.Api.Filters
{
    public class GuidModelValidatorAttribute : ValidationAttribute
    {
        private const string ErrMessage = "is not a Guid";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string == false)
                return new ValidationResult(ErrMessage);

            var str = (string) value;
            if (string.IsNullOrEmpty(str))
                return new ValidationResult(ErrMessage);

            if (Guid.TryParse(str, out _) == false)
                return new ValidationResult(ErrMessage);

            return ValidationResult.Success;
        }
    }
}