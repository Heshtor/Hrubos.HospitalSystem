using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    [Table(nameof(Vaccination))]
    public class Vaccination : Entity<int>
    {
        [ForeignKey(nameof(VaccineType))]
        public int VaccineTypeId { get; set; }
        public VaccineType? VaccineType { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        public DateTime? NextDose { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
