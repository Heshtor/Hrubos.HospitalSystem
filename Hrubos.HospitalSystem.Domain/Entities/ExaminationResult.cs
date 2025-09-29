using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    public class ExaminationResult : Entity<int>
    {
        [Required]
        public string Description { get; set; }

        public string? Values { get; set; }

        public string? Attachment { get; set; }

        [ForeignKey(nameof(Examination))]
        public int ExaminationId { get; set; }
        public Examination? Examination { get; set; }
    }
}
