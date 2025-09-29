using System.ComponentModel.DataAnnotations.Schema;

namespace Hrubos.HospitalSystem.Domain.Entities
{
    [Table(nameof(DoctorPatient))]
    public class DoctorPatient : Entity<int>
    {
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
