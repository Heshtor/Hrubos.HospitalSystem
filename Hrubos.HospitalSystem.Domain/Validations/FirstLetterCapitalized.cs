using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Hrubos.HospitalSystem.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class FirstLetterCapitalizedAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            else if (value is string text)
            {
                if (text == String.Empty)
                {
                    return ValidationResult.Success;
                }

                if (char.IsUpper(text.First()))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"Pole {validationContext.MemberName} neobsahuje první písmeno velké.123");
                }
            }
            else
            {
                throw new NotImplementedException($"Atribut {nameof(FirstLetterCapitalizedAttribute)} není implemetován pro typ: {value.GetType()}");
            }
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context.Attributes.ContainsKey("data-val") == false)
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-firstlettercap", $"Pole {context.ModelMetadata.Name} neobsahuje první písmeno velké.");
        }
    }
}
