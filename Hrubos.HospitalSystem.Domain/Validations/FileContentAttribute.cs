using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Hrubos.HospitalSystem.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class FileContentAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string[] _allowedContentTypes;
        public FileContentAttribute(params string[] allowedContentTypes)
        {
            _allowedContentTypes = allowedContentTypes;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            else if (value is IFormFile formFile)
            {
                string fileContentType = formFile.ContentType.ToLower();

                bool valid = _allowedContentTypes.Any(t => fileContentType.Contains(t.ToLower()));

                if (valid)
                    return ValidationResult.Success;

                return new ValidationResult($"Pole {validationContext.MemberName} musí být jeden z těcho typů: {string.Join(", ", _allowedContentTypes)}.");
            }
            else
            {
                throw new NotImplementedException($"Atribut {nameof(FileContentAttribute)} není implementován pro typ: {value.GetType()}");
            }
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if (!context.Attributes.ContainsKey("data-val"))
                context.Attributes.Add("data-val", "true");

            context.Attributes.Add("data-val-filecontent", $"Pole {context.ModelMetadata.Name} musí být jeden z těcho typů: {string.Join(", ", _allowedContentTypes)}.");
            context.Attributes.Add("data-val-filecontent-types", string.Join(",", _allowedContentTypes));
        }
    }
}
