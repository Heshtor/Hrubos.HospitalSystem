using Hrubos.HospitalSystem.Domain.Validations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    [Table(nameof(ExaminationResult))]
    public class ExaminationResult : Entity<int>
    {
        [Required]
        public string Description { get; set; }

        public string? Values { get; set; }

        public string? AttachmentSrc { get; set; }

        [NotMapped]
        [FileContent("image", "pdf")]
        public IFormFile? Attachment { get; set; }

        [ForeignKey(nameof(Examination))]
        public int ExaminationId { get; set; }

        public Examination? Examination { get; set; }
    }
}
