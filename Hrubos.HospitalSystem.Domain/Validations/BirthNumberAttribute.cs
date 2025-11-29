using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Hrubos.HospitalSystem.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class BirthNumberAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) // pokud je hodnota prázdná
            {
                return ValidationResult.Success;
            }
            else if (value is string input)
            {
                input = input.Trim();

                if (input == String.Empty)
                {
                    return ValidationResult.Success;
                }

                // Kontrola formátu rodného čísla
                // Formát: 6 číslic + lomítko + 3 nebo 4 číslice
                if (!Regex.IsMatch(input, @"^\d{6}/\d{3,4}$"))
                {
                    return new ValidationResult($"Pole {validationContext.MemberName} musí být ve formátu XXXXXX/XXXX.");
                }

                string cleanNumber = input.Replace("/", ""); // odebrání lomítka

                if (cleanNumber.Length == 10)
                {
                    if (!long.TryParse(cleanNumber, out long number))
                    {
                        return new ValidationResult($"Pole {validationContext.MemberName} musí obsahovat pouze číslice.");
                    }

                    // Kontrola dělitelnosti 11 (pouze pro 10místná čísla)
                    if (number % 11 != 0)
                    {
                        return new ValidationResult($"Pole {validationContext.MemberName} musí obsahovat platné rodné číslo.");
                    }
                }

                return ValidationResult.Success;
            }

            throw new NotImplementedException($"Atribut {nameof(BirthNumberAttribute)} není implementován pro typ: {value.GetType()}");
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (context.Attributes.ContainsKey("data-val") == false)
                context.Attributes.Add("data-val", "true");

            context.Attributes.Add("data-val-birthnumber", $"Pole {context.ModelMetadata.Name} obsahuje neplatné rodné číslo.");
        }
    }
}
