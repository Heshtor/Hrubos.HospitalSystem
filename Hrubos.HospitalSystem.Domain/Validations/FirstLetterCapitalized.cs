using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Hrubos.HospitalSystem.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class FirstLetterCapitalizedAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            else if (value is string text)
            {
                if (text == String.Empty)
                    return ValidationResult.Success;

                if (char.IsUpper(text.First()))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"The {validationContext.MemberName} field does not contain the first capital letter.");
                }
            }
            else
            {
                throw new NotImplementedException($"The {nameof(FirstLetterCapitalizedAttribute)} is not implemented for the type: {value.GetType()}");
            }
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context.Attributes.ContainsKey("data-val") == false)
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-firstlettercap", $"The {context.ModelMetadata.Name} field does not contain the first capital letter.");
        }
    }
}
