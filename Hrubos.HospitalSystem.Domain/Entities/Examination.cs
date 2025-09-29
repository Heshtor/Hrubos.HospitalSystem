using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    [Table(nameof(Examination))]
    public class Examination : Entity<int>
    {
        [Required]
        public DateTime DateTime { get; set; }

        public string? Notes { get; set; }

        [ForeignKey(nameof(ExaminationType))]
        public int ExaminationTypeId { get; set; }
        public ExaminationType? ExaminationType { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        public ExaminationResult? Result { get; set; }
    }
}
